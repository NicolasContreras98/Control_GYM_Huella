using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormContenedor2 : Form
    {
        public FormContenedor2()
        {
            InitializeComponent();
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

        private void FormContenedor2_Load(object sender, EventArgs e)
        {
            try
            {                
                AbrirFormEnPanel(new FormChequeo());
                pictureBox1.Visible = false;
                lblVolver.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario Contenedor2: " + ex.Message);
            }
        }


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la aplicación: " + ex.Message);
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

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //ReleaseCapture();
                //SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mover la ventana: " + ex.Message);
            }
        }

        private void pbAdministradores_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormAcceso());
                pictureBox1.Visible = true;
                lblVolver.Visible = true;
                pbAdministradores.Visible = false;
                lblAdministradores.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de acceso: " + ex.Message);
            }
        }
        private FormChequeo ObtenerFormChequeo()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormChequeo)
                {
                    return (FormChequeo)form; // Devuelve la instancia de FormSocio si está abierta
                }
            }
            return null;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                //AbrirFormEnPanel(new FormChequeo());
                FormChequeo formChequeo = ObtenerFormChequeo();
                AbrirFormEnPanel(formChequeo);
                pictureBox1.Visible = false;
                lblVolver.Visible = false;
                pbAdministradores.Visible = true;
                lblAdministradores.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al volver al formulario de chequeo: " + ex.Message);
            }
        }
    }
}
