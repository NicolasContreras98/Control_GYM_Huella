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
using AxZKFPEngXControl;
using System.Text.RegularExpressions;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormChequeo : Form
    {        
        private const int TEMPLATE_SIZE = 2048;
        private const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        private CTipoMembresia cTipoMembresia = new CTipoMembresia();        
        private CHuellaD cHuellaD = new CHuellaD();
        private CSociosD cSociosD = new CSociosD();

        private IntPtr formHandle = IntPtr.Zero;
        private bool isTimeToDie = false;
        private byte[] FPBuffer;        
        private byte[] RegTmp = new byte[TEMPLATE_SIZE];        
        private int cbCapTmp = TEMPLATE_SIZE;
        private int regTempLen = 0;
        private int fid = Program.idSocioSeleccionado;
        private int mfpWidth = 0;
        private int mfpHeight = 0;
        private Thread captureThread = null;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        
        public FormChequeo()
        {
            InitializeComponent();
        }

        private void FormChequeo_Load(object sender, EventArgs e)
        {
            formHandle = this.Handle;
            InitializeDevice();
        }

        private void InitializeDevice()
        {
            Program.fpInstance.Finalize();
            Program.fpInstance.CloseDevice();
            int initializeResult = Program.fpInstance.Initialize();

            if (zkfp.ZKFP_ERR_OK == initializeResult)
            {
                int deviceCount = zkfp2.GetDeviceCount();
                if (deviceCount > 0)
                {
                    OpenDevice(0);
                }
                else
                {
                    Program.fpInstance.Finalize();
                    MessageBox.Show("No hay dispositivos conectados.");
                }
            }
            else
            {
                MessageBox.Show($"Error al inicializar el dispositivo (Código de error: {initializeResult}).");
            }
        }

        private void OpenDevice(int deviceIndex)
        {
            int openDeviceResult = Program.fpInstance.OpenDevice(deviceIndex);
            if (zkfp.ZKFP_ERR_OK != openDeviceResult)
            {
                MessageBox.Show($"No se puede conectar con el dispositivo (Código de error: {openDeviceResult}).");
                return;
            }

            Program.RegisterCount = 0;
            regTempLen = 0;
            fid = Program.idSocioSeleccionado;

            for (int i = 0; i < Program.REGISTER_FINGER_COUNT; i++)
            {
                Program.RegTmps[i] = new byte[TEMPLATE_SIZE];
            }

            SetDeviceParameters();

            FPBuffer = new byte[mfpWidth * mfpHeight];

            captureThread = new Thread(DoCapture)
            {
                IsBackground = true
            };
            captureThread.Start();

            isTimeToDie = false;

            MessageBox.Show("Dispositivo conectado. Número de serie: " + Program.fpInstance.devSn);
        }

        private void SetDeviceParameters()
        {
            byte[] paramValue = new byte[4];
            int size = 4;

            Program.fpInstance.GetParameters(1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            Program.fpInstance.GetParameters(2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);
        }

        private void DoCapture()
        {
            try
            {
                while (!isTimeToDie)
                {
                    cbCapTmp = TEMPLATE_SIZE;
                    int ret = Program.fpInstance.AcquireFingerprint(FPBuffer, Program.CapTmp, ref cbCapTmp);

                    if (ret == zkfp.ZKFP_ERR_OK)
                    {
                        SendMessage(formHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al capturar la huella: {ex.Message}");
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == MESSAGE_CAPTURED_OK)
            {
                DisplayFingerPrintImage();
                if (Program.isRegistering)
                {
                    HandleRegistration();
                }
                else
                {
                    HandleVerification();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void DisplayFingerPrintImage()
        {
            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                picFPImg.Image = new Bitmap(ms);                
            }
        }

        private void DisplayFingerPrintImage(PictureBox pictureBox)
        {
            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                pictureBox.Image = new Bitmap(ms);
            }
        }

        private FormSocio ObtenerFormSocio()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormSocio)
                {
                    return (FormSocio)form; // Devuelve la instancia de FormSocio si está abierta
                }
            }
            return null; 
        }

        private void HandleRegistration()
        {
            FormSocio formSocio = ObtenerFormSocio();

            if (formSocio != null) // Verificar si se encontró la instancia
            {
                if (formSocio.picHuella != null)
                {
                    DisplayFingerPrintImage(formSocio.picHuella); // Mostrar la huella en el PictureBox de FormSocio
                }
                else
                {
                    MessageBox.Show("El PictureBox picHuella no está inicializado.");
                }
            }
            else
            {
                MessageBox.Show("FormSocio no está abierto.");
            }

            int score = 0;
            int ret = Program.fpInstance.Identify(Program.CapTmp, ref fid, ref  score);
            
            if (zkfp.ZKFP_ERR_OK == ret)
            {
                Program.fpInstance.DelRegTemplate(fid);
            }

            if (Program.RegTmps == null)
            {
                Program.RegTmps = new byte[Program.REGISTER_FINGER_COUNT][];
            }

            if (Program.RegisterCount > 0 && Program.fpInstance.Match(Program.CapTmp, Program.RegTmps[Program.RegisterCount - 1]) <= 0)
            {
                MessageBox.Show("Por favor, use el mismo dedo " + Program.REGISTER_FINGER_COUNT + " veces para el registro.");
                return;
            }

            Array.Copy(Program.CapTmp, Program.RegTmps[Program.RegisterCount], cbCapTmp);
            Program.RegisterCount++;
            formSocio.textRes.Text = $"Por favor, presiona el mismo dedo {Program.REGISTER_FINGER_COUNT - Program.RegisterCount} veces más";

            if (Program.RegisterCount >= Program.REGISTER_FINGER_COUNT)
            {
                FinalizeRegistration();
            }
        }
        
        private void FinalizeRegistration()
        {
            FormSocio formSocio = ObtenerFormSocio();

            Program.RegisterCount = 0;
            
            int ret = Program.fpInstance.GenerateRegTemplate(Program.RegTmps[0], Program.RegTmps[1], Program.RegTmps[2], RegTmp, ref regTempLen);

            // Verifica si la plantilla se generó correctamente
            if (zkfp.ZKFP_ERR_OK == ret)
            {
                // Intentar agregar la plantilla
                fid = Program.idSocioSeleccionado; // este fid tiene que ser único 
                ret = Program.fpInstance.AddRegTemplate(fid, RegTmp);
                if (zkfp.ZKFP_ERR_OK == ret)
                {
                    if(Program.idSocioSeleccionado > 0)
                    {
                        if(cHuellaD.GuardarHuella(Program.idSocioSeleccionado, RegTmp))
                        {
                            MessageBox.Show("Huella digital registrada correctamente.");
                            formSocio.textRes.Text = "";
                            formSocio.btnCancelarRegHuella.Visible = false;
                            formSocio.btnRegistrarHuella.Visible = false;
                            formSocio.btnRegistrarHuella.Enabled = true;
                            formSocio.dgvSocios.Enabled = true;
                            formSocio.picHuella.Image = null;
                            Program.isRegistering = false;
                            Program.isIdentifying = true;
                        } 
                    }
                    else { MessageBox.Show("Primero selecciona el usuario!");}
                }
                else
                {
                    MessageBox.Show($"Error al agregar la plantilla. Código de error: {ret}");
                }
            }
            else
            {
                MessageBox.Show($"Error al generar la plantilla de huella digital. Código de error: {ret}");
            }
        }
        int idSocioEncontrado = -1;
        private void HandleVerification()
        {
            List<(int id_socio, byte[] huella)> huellasDB = cHuellaD.ObtenerHuellasDesdeDB();

            bool verificacionExitosa = false;

            // Recorrer todas las huellas almacenadas y compararlas con la huella capturada
            foreach (var (idSocio, huellaGuardada) in huellasDB)
            {
                int ret = Program.fpInstance.Match(Program.CapTmp, huellaGuardada);

                if (ret > 0) // Coincidencia encontrada
                {
                    verificacionExitosa = true;
                    idSocioEncontrado = idSocio;
                    break;
                }
            }

            if (verificacionExitosa)
            {
                timer1.Stop();
                timer1.Start();
                lblFeedBack.Text = "";
                lblTipoMembresia.Visible = true;
                cmbTipoMembresia.Visible = true;

                ClsSocio[] socioEncontrado = cSociosD.ObtenerDatosSocio(idSocioEncontrado);
                lblNombreCompleto.Text = $"{socioEncontrado[0].Nombre} {socioEncontrado[0].Apellido}";

                lblInicio.Text = socioEncontrado[0].Fecha_Inicio.HasValue
                    ? socioEncontrado[0].Fecha_Inicio.Value.ToString("dd/MM")
                    : "";

                lblFin.Text = socioEncontrado[0].Fecha_Fin.HasValue
                    ? socioEncontrado[0].Fecha_Fin.Value.ToString("dd/MM")
                    : "";

                DateTime fecha_actual = DateTime.Today;

                if (socioEncontrado[0].Fecha_Fin != null && socioEncontrado[0].Fecha_Inicio != null)
                {
                    DateTime fecha_fin = socioEncontrado[0].Fecha_Fin.HasValue ? socioEncontrado[0].Fecha_Fin.Value : DateTime.Now;
                    TimeSpan diferencia = fecha_fin - fecha_actual;
                    int dias_restantes = diferencia.Days;

                    lblDiasRestantes.Text = dias_restantes.ToString();
                    if (socioEncontrado[0].Tipos_membresias != null)
                    {
                        cmbTipoMembresia.DataSource = socioEncontrado[0].Tipos_membresias;
                        
                    }
                    if (Convert.ToInt32(dias_restantes) <= 5 && Convert.ToInt32(dias_restantes) >= 1)
                    {
                        pbNeutro.Visible = false;
                        pbYes.Visible = false;
                        pbNo.Visible = false;
                        pbWarning.Visible = true;
                    }
                    else if (Convert.ToInt32(dias_restantes) > 5)
                    {
                        pbNeutro.Visible = false;
                        pbYes.Visible = true;
                        pbNo.Visible = false;
                        pbWarning.Visible = false;
                    }
                    else
                    {                       
                        pbNeutro.Visible = false;
                        pbYes.Visible = false;
                        pbWarning.Visible = false;
                        pbNo.Visible = true;
                    }
                }
                else
                {
                    pbNeutro.Visible = false;
                    pbYes.Visible = false;
                    pbWarning.Visible = false;
                    pbNo.Visible = true;
                    lblDiasRestantes.Text = "";
                    lblFeedBack.Text = "No tiene ninguna membresia";
                }
            }
            else
            {
                MessageBox.Show("Verificación fallida.");
            }
        }

        private void DisconnectDevice()
        {
            try
            {
                if (!isTimeToDie)
                {
                    isTimeToDie = true; // Marca que el hilo debe terminar
                }

                if (captureThread != null && captureThread.IsAlive)
                {
                    captureThread.Join(); // Espera a que el hilo termine de forma segura
                }

                if (zkfp.ZKFP_ERR_OK == Program.fpInstance.CloseDevice())
                {
                    Program.fpInstance.Finalize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desconectar el dispositivo: {ex.Message}");
            }
        }

        private void FormChequeo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectDevice();
        }

        private void FormChequeo_Activated(object sender, EventArgs e)
        {
            Program.isRegistering = false;
            Program.isIdentifying = true;
        }

        private void FormChequeo_Deactivate(object sender, EventArgs e)
        {
            Program.isRegistering = true;
            Program.isIdentifying = false;
        }

        private void cmbTipoMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            lblFeedBack.Text = "";
            lblTipoMembresia.Visible = true;
            cmbTipoMembresia.Visible = true;
            CTipoMembresia tipoSeleccionado = (CTipoMembresia)cmbTipoMembresia.SelectedItem;
            int cod_tipo_membresia = tipoSeleccionado.cod_tipo_membresia;
            cTipoMembresia.cod_tipo_membresia = cod_tipo_membresia;

            ClsSocio[] socioEncontrado = cSociosD.ObtenerDatosSocio(idSocioEncontrado, cod_tipo_membresia); 
            lblNombreCompleto.Text = $"{socioEncontrado[0].Nombre} {socioEncontrado[0].Apellido}";
            lblInicio.Text = socioEncontrado[0].Fecha_Inicio.HasValue
                   ? socioEncontrado[0].Fecha_Inicio.Value.ToString("dd/MM")
                   : "";

            lblFin.Text = socioEncontrado[0].Fecha_Fin.HasValue
                ? socioEncontrado[0].Fecha_Fin.Value.ToString("dd/MM")
                : "";
            DateTime fecha_actual = DateTime.Today;
            if (socioEncontrado[0].Fecha_Fin != null && socioEncontrado[0].Fecha_Inicio != null)
            {
                DateTime fecha_fin = socioEncontrado[0].Fecha_Fin.HasValue ? socioEncontrado[0].Fecha_Fin.Value : DateTime.Now;
                TimeSpan diferencia = fecha_fin - fecha_actual;
                int dias_restantes = diferencia.Days;

                lblDiasRestantes.Text = dias_restantes.ToString();
                if (Convert.ToInt32(dias_restantes) <= 5 && Convert.ToInt32(dias_restantes) >= 1)
                {
                    pbNeutro.Visible = false;
                    pbYes.Visible = false;
                    pbNo.Visible = false;
                    pbWarning.Visible = true;
                }
                else if (Convert.ToInt32(dias_restantes) > 5)
                {
                    pbNeutro.Visible = false;
                    pbYes.Visible = true;
                    pbNo.Visible = false;
                    pbWarning.Visible = false;
                }
                else
                {
                    pbNeutro.Visible = false;
                    pbYes.Visible = false;
                    pbWarning.Visible = false;
                    pbNo.Visible = true;
                }
            }
            else
            {
                lblFeedBack.Text = "No tiene ninguna membresia";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            pbYes.Visible = false;
            pbNo.Visible = false;
            pbWarning.Visible = false;
            pbNeutro.Visible = true;

            limpiarLabels();
        }

        private void limpiarLabels()
        {
            lblNombreCompleto.Text = "";
            lblInicio.Text = "00/00";
            lblFin.Text = "00/00";
            lblDiasRestantes.Text = "00";
            cmbTipoMembresia.Visible = false;
            lblTipoMembresia.Visible = false;
            picFPImg.Image = null;
        }
    }
}
