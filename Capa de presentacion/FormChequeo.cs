using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using libzkfpcsharp;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Sample;
using System.Collections.Generic;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormChequeo : Form
    {
        private CTipoMembresia cTipoMembresia = new CTipoMembresia();
        private CMembresiaD cMembresiaD = new CMembresiaD();
        private CChequeoD cChequeoD = new CChequeoD();

        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        byte[] FPBuffer;
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        Thread captureThread = null;
        private int mfpWidth = 0;
        private int mfpHeight = 0;

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public FormChequeo()
        {
            InitializeComponent();
        }

        private void FormChequeo_Load(object sender, EventArgs e)
        {
            // Inicializar el lector de huellas al cargar el formulario
            int ret = zkfp2.Init();
            if (ret != zkfperrdef.ZKFP_ERR_OK)
            {
                MessageBox.Show("Error al inicializar el dispositivo de huellas: " + ret);
                return;
            }

            // Obtener el dispositivo y la base de datos
            if ((mDevHandle = zkfp2.OpenDevice(0)) == IntPtr.Zero)
            {
                MessageBox.Show("Error al abrir el dispositivo de huellas");
                return;
            }

            if ((mDBHandle = zkfp2.DBInit()) == IntPtr.Zero)
            {
                MessageBox.Show("Error al inicializar la base de datos de huellas");
                zkfp2.CloseDevice(mDevHandle);
                return;
            }

            // Obtener el tamaño de la huella
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            // Iniciar el hilo de captura de huellas
            captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
        }

        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(this.Handle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    MemoryStream ms = new MemoryStream();
                    BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                    Bitmap bmp = new Bitmap(ms);
                    this.picFPImg.Image = bmp;

                    // Aquí reemplazamos la identificación local por una búsqueda en la base de datos SQL
                    int idSocio = BuscarHuellaEnBaseDeDatos(CapTmp);
                    if (idSocio > 0)
                    {
                        VerificarMembresia(idSocio);
                    }
                    else
                    {
                        MessageBox.Show("Socio no encontrado. Intente de nuevo.");
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        // Método que busca la huella en la base de datos SQL
        private int BuscarHuellaEnBaseDeDatos(byte[] huellaCapturada)
        {
            // Aquí realizas la búsqueda en la base de datos SQL
            // Retorna el idSocio si encuentra una coincidencia, o 0 si no la encuentra
            return cChequeoD.buscarPorHuella(huellaCapturada);
        }


        private void VerificarMembresia(int idSocio)
        {
            // Buscar el socio por su ID (fid es el idSocio en la base de datos)
            string[] resultado = cChequeoD.buscarPorIdSocio(idSocio);

            if (resultado.Length > 0)
            {
                lblNombreCompleto.Text = $"{resultado[0]} {resultado[1]}"; // Nombre y apellido
                lblInicio.Text = resultado[2]; // Fecha de inicio
                lblFin.Text = resultado[3]; // Fecha de fin
                lblDiasRestantes.Text = resultado[4]; // Días restantes

                int diasRestantes = Convert.ToInt32(resultado[4]);
                if (diasRestantes > 5)
                {
                    pbYes.Visible = true;
                    pbNo.Visible = false;
                    pbWarning.Visible = false;
                }
                else if (diasRestantes <= 5 && diasRestantes >= 1)
                {
                    pbWarning.Visible = true;
                    pbYes.Visible = false;
                    pbNo.Visible = false;
                }
                else
                {
                    pbNo.Visible = true;
                    pbYes.Visible = false;
                    pbWarning.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("El socio no tiene una membresía activa.");
            }
        }

        private void FormChequeo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cerrar el dispositivo de huellas y detener el hilo de captura
            bIsTimeToDie = true;
            Thread.Sleep(1000);
            captureThread.Join();
            zkfp2.CloseDevice(mDevHandle);
            zkfp2.Terminate();
        }

        private void limpiarLabels()
        {
            lblNombreCompleto.Text = "";
            lblInicio.Text = "00/00";
            lblFin.Text = "00/00";
            lblDiasRestantes.Text = "00";
            cmbTipoMembresia.Visible = false;
            lblTipoMembresia.Visible = false;
        }

        /*private void cmbTipoMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CTipoMembresia tipoSeleccionado = (CTipoMembresia)cmbTipoMembresia.SelectedItem;
                int cod_tipo_membresia = tipoSeleccionado.cod_tipo_membresia;
                cTipoMembresia.cod_tipo_membresia = cod_tipo_membresia;

                if (dni_global != 0)
                {
                    timer1.Stop();
                    timer1.Start();

                    if (cMembresiaD.TieneTipoMembresia(dni_global, cTipoMembresia.cod_tipo_membresia))
                    {
                        CChequeoD cChequeoD = new CChequeoD();
                        string[] resultado = cChequeoD.buscarPorDni(dni_global, cTipoMembresia.cod_tipo_membresia);

                        if (resultado.Length > 0)
                        {
                            if (Convert.ToInt32(resultado[2]) <= 5 && Convert.ToInt32(resultado[2]) >= 1)
                            {
                                lblInicio.Text = resultado[0];
                                lblFin.Text = resultado[1];
                                lblDiasRestantes.Text = resultado[2];

                                pbNeutro.Visible = false;
                                pbYes.Visible = false;
                                pbNo.Visible = false;
                                pbWarning.Visible = true;
                            }
                            else if (Convert.ToInt32(resultado[2]) > 5)
                            {
                                lblInicio.Text = resultado[0];
                                lblFin.Text = resultado[1];
                                lblDiasRestantes.Text = resultado[2];

                                pbNeutro.Visible = false;
                                pbYes.Visible = true;
                                pbNo.Visible = false;
                                pbWarning.Visible = false;
                            }
                            else
                            {
                                lblInicio.Text = resultado[0];
                                lblFin.Text = resultado[1];
                                lblDiasRestantes.Text = resultado[2];

                                pbNeutro.Visible = false;
                                pbYes.Visible = false;
                                pbWarning.Visible = false;
                                pbNo.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El socio no tiene esta membresía","alerta",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar un tipo de membresía: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDni.Text != "")
                {

                    int dni = Convert.ToInt32(txtDni.Text);

                    dni_global = dni;

                    

                    txtDni.Text = "";

                    string[] resultado = cChequeoD.buscarPorDni(dni);
                    int cant_tipo_membresia = cChequeoD.ContarTiposMembresia(dni);

                    cmbTipoMembresia.Visible = false;
                    lblTipoMembresia.Visible = false;

                    if (cant_tipo_membresia > 1)
                    {
                        cmbTipoMembresia.Visible = true;
                        lblTipoMembresia.Visible = true;
                    }

                    timer1.Stop();
                    timer1.Start();

                    if (resultado.Length > 0)
                    {
                        try
                        {
                            List<CTipoMembresia> tipos = cTipoMembresia.traerTiposDelSocio(dni);
                            cmbTipoMembresia.DataSource = tipos;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar los tipos de membresía: " + ex.Message);
                        }

                        try
                        {
                            ClsSocio[] socio = cChequeoD.traerDatosDeSocioPorDni(dni);
                            lblNombreCompleto.Text = socio[0].Nombre + " " + socio[0].Apellido;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar los tipos de membresía: " + ex.Message);
                        }

                        if (Convert.ToInt32(resultado[2]) <= 5 && Convert.ToInt32(resultado[2]) >= 1)
                        {
                            lblInicio.Text = resultado[0];
                            lblFin.Text = resultado[1];
                            lblDiasRestantes.Text = resultado[2];

                            pbNeutro.Visible = false;
                            pbYes.Visible = false;
                            pbNo.Visible = false;
                            pbWarning.Visible = true;
                        }
                        else if (Convert.ToInt32(resultado[2]) > 5)
                        {
                            lblInicio.Text = resultado[0];
                            lblFin.Text = resultado[1];
                            lblDiasRestantes.Text = resultado[2];

                            pbNeutro.Visible = false;
                            pbYes.Visible = true;
                            pbNo.Visible = false;
                            pbWarning.Visible = false;
                        }
                        else
                        {
                            lblInicio.Text = resultado[0];
                            lblFin.Text = resultado[1];
                            lblDiasRestantes.Text = resultado[2];

                            pbNeutro.Visible = false;
                            pbYes.Visible = false;
                            pbWarning.Visible = false;
                            pbNo.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("el DNI ingresado no existe.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        limpiarLabels();
                        pbNeutro.Visible = true;
                        pbYes.Visible = false;
                        pbNo.Visible = false;
                        pbWarning.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("El campo está vacío, ingrese un DNI", "error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el DNI del socio: " + ex.Message);
            }
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            pbYes.Visible = false;
            pbNo.Visible = false;
            pbWarning.Visible = false;
            pbNeutro.Visible = true;

            limpiarLabels();
        }

        private void cmbTipoMembresia_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Deshabilita el menú contextual al hacer clic derecho en el ComboBox
                ((ComboBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void cmbTipoMembresia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
