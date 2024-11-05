using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormTipoProductos : Form
    {
        public FormTipoProductos()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CTipoProducto cTipoProducto = new CTipoProducto();
                int cod = Convert.ToInt32(txtCod.Text);
                string nombre = txtNombre.Text;
                cTipoProducto.EliminarProducto(cod, nombre);
                dgvTipoProducto.DataSource = cTipoProducto.MostrarTipoProducto();

                limpiarCampos();
                cancelarActualizar();
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlException && sqlException.Number == 547)
                {
                    MessageBox.Show("No se puede eliminar el tipo de producto porque tiene productos relacionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el tipo de producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtNombre.Text != ""))
                {
                    CTipoProducto cTipoProducto = new CTipoProducto();
                    string nombre = txtNombre.Text.Trim();
                    cTipoProducto.AgregarTipoProducto(nombre);
                    dgvTipoProducto.DataSource = cTipoProducto.MostrarTipoProducto();
                    limpiarCampos();
                    cancelarActualizar();
                }
                else
                {
                    MessageBox.Show("Por favor, complete el campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el tipo de producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                CTipoProducto cTipoProducto = new CTipoProducto();
                int cod = Convert.ToInt32(txtCod.Text);
                string nombre = txtNombre.Text;
                cTipoProducto.ActualizarProducto(cod, nombre);
                dgvTipoProducto.DataSource = cTipoProducto.MostrarTipoProducto();
                limpiarCampos();
                cancelarActualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el tipo de producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormTipoProductos_Load(object sender, EventArgs e)
        {
            cancelarActualizar();

            CTipoProducto cTipoProducto = new CTipoProducto();
            dgvTipoProducto.DataSource = cTipoProducto.MostrarTipoProducto();
            dgvTipoProducto.Columns[0].HeaderText = "Código";
            dgvTipoProducto.Columns[1].HeaderText = "Nombre";
            dgvTipoProducto.AutoResizeColumns();
            dgvTipoProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipoProducto.Columns[0].Width = 50;
        }

        private void cancelarActualizar()
        {
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            btnCancelar.Visible = false;
        }

        private void limpiarCampos()
        {
            txtCod.Text = "";
            txtNombre.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            cancelarActualizar();
        }

        private void dgvTipoProducto_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTipoProducto.SelectedRows.Count > 0)
            {
                txtCod.Text = dgvTipoProducto.Rows[e.RowIndex].Cells["cod_tipo_producto"].FormattedValue.ToString();
                txtNombre.Text = dgvTipoProducto.Rows[e.RowIndex].Cells["nombre"].FormattedValue.ToString();
                btnEliminar.Visible = true;
                btnModificar.Visible = true;
                btnAgregar.Visible = false;
                btnCancelar.Visible = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtCod_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dgvTipoProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

