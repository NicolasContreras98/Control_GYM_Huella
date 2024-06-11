using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Control_Gym.Capa_de_presentacion;
using System.IO;

namespace Control_Gym
{
    public partial class FormContenedor : Form
    {
        public FormContenedor()
        {
            InitializeComponent();

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
        }
        private int dni_empleado;
        private string nombre;

        private Color colorMouseOver = Color.FromArgb(65, 65, 68);
        private Color colorDefault = Color.FromArgb(0, 122, 204);
        private Color colorSeleccionado = Color.FromArgb(45, 45, 48);

        private Button botonSeleccionado = null;


        public FormContenedor(int dni_empleado, string nombre)
        {
            InitializeComponent();
            this.dni_empleado = dni_empleado;
            this.nombre = nombre;
        }

        // Evento Click: Cambiar el color de fondo del botón seleccionado
        private void boton_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            // Restablecer el color de fondo de los demás botones
            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackColor = colorDefault;
            }

            // Cambiar el color de fondo del botón seleccionado
            boton.BackColor = colorSeleccionado;
            botonSeleccionado = boton;
        }

        // Evento MouseEnter: Cambiar el color de fondo cuando el ratón entra en el botón
        private void boton_MouseEnter(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton != botonSeleccionado) // Solo cambiar el color si el botón no está seleccionado
            {
                boton.BackColor = colorMouseOver;
            }
        }

        // Evento MouseLeave: Restaurar el color de fondo original cuando el ratón sale del botón
        private void boton_MouseLeave(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton != botonSeleccionado) // Solo restaurar el color si el botón no está seleccionado
            {
                boton.BackColor = colorDefault;
            }
        }

        //

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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (MenuVertical.Width == 250)
                {
                    MenuVertical.Width = 50;
                }
                else
                    MenuVertical.Width = 250;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el ancho del menú: " + ex.Message);
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la ventana: " + ex.Message);
            }
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            try
            {
                if (this.panelContenedor.Controls.Count > 0)
                    this.panelContenedor.Controls.RemoveAt(0);
                Form fh = Formhijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(fh);
                this.panelContenedor.Tag = fh;
                fh.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario hijo: " + ex.Message);
            }
        }

        //

        private void btnSocios_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormSocio());

                Button boton = sender as Button;

                // Restablecer el color de fondo de los demás botones
                if (botonSeleccionado != null)
                {
                    botonSeleccionado.BackColor = colorDefault;
                }

                // Cambiar el color de fondo del botón seleccionado
                boton.BackColor = colorSeleccionado;
                botonSeleccionado = boton;
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
                AbrirFormEnPanel(new FormMembresias());

                Button boton = sender as Button;

                // Restablecer el color de fondo de los demás botones
                if (botonSeleccionado != null)
                {
                    botonSeleccionado.BackColor = colorDefault;
                }

                // Cambiar el color de fondo del botón seleccionado
                boton.BackColor = colorSeleccionado;
                botonSeleccionado = boton;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de membresías: " + ex.Message);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormVentas(dni_empleado, nombre));

                Button boton = sender as Button;

                // Restablecer el color de fondo de los demás botones
                if (botonSeleccionado != null)
                {
                    botonSeleccionado.BackColor = colorDefault;
                }

                // Cambiar el color de fondo del botón seleccionado
                boton.BackColor = colorSeleccionado;
                botonSeleccionado = boton;
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
                AbrirFormEnPanel(new FormCaja());

                Button boton = sender as Button;

                // Restablecer el color de fondo de los demás botones
                if (botonSeleccionado != null)
                {
                    botonSeleccionado.BackColor = colorDefault;
                }

                // Cambiar el color de fondo del botón seleccionado
                boton.BackColor = colorSeleccionado;
                botonSeleccionado = boton;

                lblDNI.Text = this.dni_empleado.ToString();
                lblNombre.Text = this.nombre;
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
                AbrirFormEnPanel(new FormAdministracion());

                Button boton = sender as Button;

                // Restablecer el color de fondo de los demás botones
                if (botonSeleccionado != null)
                {
                    botonSeleccionado.BackColor = colorDefault;
                }

                // Cambiar el color de fondo del botón seleccionado
                boton.BackColor = colorSeleccionado;
                botonSeleccionado = boton;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de administración: " + ex.Message);
            }
        }



        private void FormContenedor_Load(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormSocio());
                lblDNI.Text = this.dni_empleado.ToString();
                lblNombre.Text = this.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario de contenedor: " + ex.Message);
            }
        }

    }
}
