using Control_Gym.Capa_de_presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym
{
    public partial class FormAdministracion : Form
    {

        public FormAdministracion()
        {
            InitializeComponent();
            CambiarColorBotonPanelYLabel(btnEmpleados, panelEmpleados, labelEmpleados);
        }

        private void ResetearColoresBotones()
        {
            btnEmpleados.BackColor = Color.FromArgb(64, 64, 64);
            btnTiposMembresia.BackColor = Color.FromArgb(64, 64, 64);
            btnProveedores.BackColor = Color.FromArgb(64, 64, 64);
            btnProductos.BackColor = Color.FromArgb(64, 64, 64);
            btnTiposProducto.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void ResetearColoresPaneles()
        {
            panelEmpleados.BackColor = Color.FromArgb(64, 64, 64);
            panelTiposMembresia.BackColor = Color.FromArgb(64, 64, 64);
            panelProveedores.BackColor = Color.FromArgb(64, 64, 64);
            panelProductos.BackColor = Color.FromArgb(64, 64, 64);
            panelTiposProducto.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void ResetearColoresLabels()
        {
            labelEmpleados.BackColor = Color.FromArgb(64, 64, 64);
            labelTiposMembresia.BackColor = Color.FromArgb(64, 64, 64);
            labelProveedores.BackColor = Color.FromArgb(64, 64, 64);
            labelProductos.BackColor = Color.FromArgb(64, 64, 64);
            labelTiposProducto.BackColor = Color.FromArgb(64, 64, 64);
        }


        private void CambiarColorBotonPanelYLabel(Button boton, Panel panel, Label label)
        {
            ResetearColoresBotones(); // Resetea los colores de todos los botones
            ResetearColoresPaneles(); // Resetea los colores de todos los paneles
            ResetearColoresLabels();  // Resetea los colores de todos los labels
            boton.BackColor = Color.FromArgb(192, 64, 0); // Cambia el color del botón clickeado
            panel.BackColor = Color.FromArgb(192, 64, 0); // Cambia el color del panel asociado
            label.BackColor = Color.FromArgb(192, 64, 0); // Cambia el color del label asociado
        }


        public void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                try
                {
                    this.panelContenedor.Controls.RemoveAt(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el formulario: " + ex.Message);
                }
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormEmpleados());
                CambiarColorBotonPanelYLabel(btnEmpleados, panelEmpleados, labelEmpleados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de empleados: " + ex.Message);
            }
        }

        private void btnTiposMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormTipoMembresia());
                CambiarColorBotonPanelYLabel(btnTiposMembresia, panelTiposMembresia, labelTiposMembresia); // Cambia el color del botón y su panel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de tipos de membresía: " + ex.Message);
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormProveedores());
                CambiarColorBotonPanelYLabel(btnProveedores, panelProveedores, labelProveedores); // Cambia el color del botón y su panel
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de proveedores: " + ex.Message);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormProductos());
                CambiarColorBotonPanelYLabel(btnProductos, panelProductos, labelProductos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de productos: " + ex.Message);
            }
        }

        private void btnTiposProducto_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormTipoProductos());
                CambiarColorBotonPanelYLabel(btnTiposProducto, panelTiposProducto, labelTiposProducto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario de tipos de productos: " + ex.Message);
            }
        }

        private void FormAdministracion_Load(object sender, EventArgs e)
        {
            try
            {
                AbrirFormEnPanel(new FormEmpleados());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario de empleados: " + ex.Message);
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
