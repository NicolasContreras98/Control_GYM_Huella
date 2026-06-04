using Control_Gym.Capa_de_presentacion;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Control_Gym
{
    public partial class FormContenedor : Form
    {
        private FormChequeo formChequeo;
        private FormSocio formSocio;
        private FormMembresias formMembresias;
        private FormVentas formVentas;
        private FormCaja formCaja;
        private FormAdministracion formAdministracion;
        private FormAsistencia formAsistencia;
        private FormAjustes formAjustes;

        private readonly Color colorDefault = Color.FromArgb(80, 80, 80);
        private readonly Color colorSeleccionado = Color.FromArgb(192, 64, 0);

        private Button botonSeleccionado = null;

        public FormContenedor()
        {
            InitializeComponent();

            formChequeo = new FormChequeo(this);

            string relativePath = @"Iconos\control-gym-logo.png";
            string absolutePath = Path.Combine(Application.StartupPath, relativePath);

            RoundedPictureBox roundedPictureBox = new RoundedPictureBox
            {
                CornerRadius = 80, // Establece el radio de las esquinas
                Image = Image.FromFile(absolutePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 200,
                Height = 200,
                Location = new Point(5, 5)
            };

            this.Controls.Add(roundedPictureBox);

            ConfigurarAccesoSegunRol();
        }

        private void FormContenedor_Load(object sender, EventArgs e)
        {
            try
            {
                formChequeo.LoadArtificial();
                AbrirFormEnPanel(formChequeo);
                SeleccionarBoton(btnVerificacion);
                labelDNI.Text = SesionUsuario.DniEmpleado.ToString();
                labelNombre.Text = SesionUsuario.Nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario de contenedor: " + ex.Message);
            }
        }

        public void SeleccionarBoton(Button boton)
        {
            // Restablecer el color de fondo de los demás botones
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackColor = colorDefault;
            }

            // Cambiar el color de fondo del botón seleccionado
            boton.BackColor = colorSeleccionado;
            botonSeleccionado = boton;
        }

        public void SeleccionarBotonMembresias()
        {
            if (btnMembresias != null) // Asumiendo que 'botonMembresias' es el botón de membresías
            {
                // Restablecer el color de fondo de los demás botones
                if (botonSeleccionado != null)
                {
                    botonSeleccionado.BackColor = colorDefault;
                }

                // Cambiar el color de fondo del botón de membresías
                btnMembresias.BackColor = colorSeleccionado;
                botonSeleccionado = btnMembresias;
            }
        }

        public void ConfigurarAccesoSegunRol()
        {
            if (SesionUsuario.Rol == "Empleado")
            {
                // Deshabilitar botones o funcionalidades para empleados
                btnMembresias.Enabled = false;
                btnCaja.Enabled = false;
                btnAdministracion.Enabled = false;
                btnAsistencia.Enabled = false;
                btnAjustes.Enabled = false;
                // Otros accesos restringidos
            }
            else if (SesionUsuario.Rol == "Administrador")
            {
                // Administrador tiene acceso completo, no hay que deshabilitar nada
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mover la ventana: " + ex.Message);
            }
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al minimizar la ventana: " + ex.Message);
            }
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                iconrestaurar.Visible = false;
                iconmaximizar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la ventana: " + ex.Message);
            }
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                iconrestaurar.Visible = true;
                iconmaximizar.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al maximizar la ventana: " + ex.Message);
            }
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("¿Está seguro de que desea salir del programa?", "Confirmación de salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la ventana: " + ex.Message);
            }
        }

        public void AbrirFormEnPanel(Form formHijo)
        {
            try
            {
                // Ocultar todos los formularios actualmente en el panel
                foreach (Control control in panelContenedor.Controls)
                {
                    if (control is Form formActual)
                    {
                        formActual.Hide();
                    }
                }

                // Verificar si el formulario ya está en el panel y mostrarlo
                if (!panelContenedor.Controls.Contains(formHijo))
                {
                    formHijo.TopLevel = false;
                    formHijo.Dock = DockStyle.Fill;
                    panelContenedor.Controls.Add(formHijo);
                }

                formHijo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario hijo: " + ex.Message);
            }
        }

        public void AbrirFormMembresias(int dni)
        {
            FormMembresias formMembresias = new FormMembresias(dni);
            AbrirFormEnPanel(formMembresias);
        }

        private void btnVerificacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (formChequeo == null || formChequeo.IsDisposed)
                {
                    formChequeo = new FormChequeo(this);
                }

                AbrirFormEnPanel(formChequeo);
                formChequeo.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de socios: " + ex.Message);
            }
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            try
            {
                if (formSocio == null || formSocio.IsDisposed)
                {
                    formSocio = new FormSocio(this);
                }

                AbrirFormEnPanel(formSocio);
                formSocio.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de socios: " + ex.Message);
            }
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMembresias == null || formMembresias.IsDisposed)
                {
                    formMembresias = new FormMembresias();
                }

                AbrirFormEnPanel(formMembresias);
                formMembresias.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de membresías: " + ex.Message);
            }
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (formAsistencia == null || formAsistencia.IsDisposed)
                {
                    formAsistencia = new FormAsistencia();
                }

                AbrirFormEnPanel(formAsistencia);
                formAsistencia.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de asistencia: " + ex.Message);
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (formVentas == null || formVentas.IsDisposed)
                {
                    formVentas = new FormVentas(SesionUsuario.DniEmpleado, SesionUsuario.Nombre);
                }

                AbrirFormEnPanel(formVentas);
                formVentas.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de ventas: " + ex.Message);
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (formCaja == null || formCaja.IsDisposed)
                {
                    formCaja = new FormCaja();
                }

                AbrirFormEnPanel(formCaja);
                formCaja.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);

                labelDNI.Text = SesionUsuario.DniEmpleado.ToString();
                labelNombre.Text = SesionUsuario.Nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario de contenedor: " + ex.Message);
            }
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            try
            {
                if (formAdministracion == null || formAdministracion.IsDisposed)
                {
                    formAdministracion = new FormAdministracion();
                }

                AbrirFormEnPanel(formAdministracion);
                formAdministracion.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de administración: " + ex.Message);
            }
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            try
            {
                if (formAjustes == null || formAjustes.IsDisposed)
                {
                    formAjustes = new FormAjustes();
                }

                AbrirFormEnPanel(formAjustes);
                formAjustes.LoadArtificial();

                Button boton = sender as Button;
                CambiarColorBotonSeleccionado(boton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de administración: " + ex.Message);
            }
        }

        private void CambiarColorBotonSeleccionado(Button boton)
        {
            // Restablecer el color de fondo de los demás botones
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackColor = colorDefault;
            }

            // Cambiar el color de fondo del botón seleccionado
            boton.BackColor = colorSeleccionado;
            botonSeleccionado = boton;
        }

        private void pbCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Cerrar sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
