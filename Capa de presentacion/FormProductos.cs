using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormProductos : Form
    {
        CProducto cProducto = new CProducto();

        public FormProductos()
        {
            InitializeComponent();

        }
        private CTipoProducto cTipoProducto = new CTipoProducto();
        private ClsProvedores cProveedor = new ClsProvedores();

        private void FormProductos_Load(object sender, EventArgs e)
        {
            cancelarActualizar();

            try
            {
                DataTable dtProductos = cProducto.ObtenerDatosProductos();
                dgvProductos.DataSource = dtProductos;

                dgvProductos.Columns["cod_proveedor"].Visible = false;
                dgvProductos.Columns["nombre_proveedor"].HeaderText = "Proveedor";
                dgvProductos.Columns["cod_producto"].Visible = false;
                dgvProductos.Columns["cod_tipo_producto"].Visible = false;
                dgvProductos.Columns["nombre_tipo_producto"].HeaderText = "Tipo de Producto";
                dgvProductos.Columns["nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["stock"].HeaderText = "Stock";
                dgvProductos.Columns["precio_venta"].HeaderText = "Precio de venta";
                dgvProductos.Columns["precio_costo"].HeaderText = "Precio de costo";
                dgvProductos.Columns["ganancia"].HeaderText = "Ganancia";
                dgvProductos.Columns["fecha_venc"].HeaderText = "Fecha de venc.";

                List<CTipoProducto> tipos_productos = cTipoProducto.traerTiposProductos();
                cmbTipoProducto.DataSource = tipos_productos;

                List<ClsProvedores> tipos_provedores = cProveedor.traerTiposProveedores();
                cmbProveedor.DataSource = tipos_provedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodProducto.Text))
                {
                    MessageBox.Show("El campo Código de Producto no puede estar vacío.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int cod_producto;

                if (!int.TryParse(txtCodProducto.Text.Trim(), out cod_producto))
                {
                    MessageBox.Show("El campo Código de Producto debe ser un número válido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string cod = txtCodProducto.Text;
                int cod_proveedor = cProveedor.Cod;
                int cod_tipo_producto = cTipoProducto.Cod_tipo_producto;
                string nombre = txtNombre.Text;
                DateTime fecha_venc = dtpFechaVenc.Value;
                decimal precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
                decimal preciocosto = Convert.ToDecimal(txtCosto.Text);
                decimal ganancia = precioventa - preciocosto;
                int stock = Convert.ToInt32(txtStock.Text);

                CProducto CProductoD = new CProducto();
                CProductoD.ModificarProducto(cod, cod_proveedor, cod_tipo_producto, nombre, fecha_venc, preciocosto, precioventa, ganancia, stock);

                DataTable dtProductos = cProducto.ObtenerDatosProductos();
                dgvProductos.DataSource = dtProductos;

                limpiarCampos();
                cancelarActualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCod.Text))
                {
                    MessageBox.Show("Debe seleccionar un producto para eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int cod_producto;

                if (!int.TryParse(txtCod.Text.Trim(), out cod_producto))
                {
                    MessageBox.Show("El campo Código de Producto debe ser un número válido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                CProducto CProductoD = new CProducto();
                string nombre = txtNombre.Text;
                CProductoD.EliminarProducto(cod_producto, nombre);
                DataTable dtProductos = cProducto.ObtenerDatosProductos();
                dgvProductos.DataSource = dtProductos;

                limpiarCampos();
                cancelarActualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los campos obligatorios no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecioVenta.Text) || string.IsNullOrWhiteSpace(txtStock.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos obligatorios.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Obtener los valores de los campos
                int cod_proveedor = cProveedor.Cod;
                int cod_tipo_producto = cTipoProducto.Cod_tipo_producto;
                string nombre = txtNombre.Text.Trim();
                DateTime fecha_venc = dtpFechaVenc.Value;
                decimal preciocosto = Convert.ToDecimal(txtCosto.Text);
                decimal precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
                decimal ganancia = precioventa - preciocosto;
                int stock = Convert.ToInt32(txtStock.Text);

                // Crear una instancia de la clase CProducto y guardar el producto
                CProducto CProductoD = new CProducto();
                CProductoD.GuardarProducto(cod_proveedor, cod_tipo_producto, nombre, fecha_venc, preciocosto, precioventa, ganancia, stock);
                DataTable dtProductos = cProducto.ObtenerDatosProductos();
                dgvProductos.DataSource = dtProductos;

                // Limpiar los campos después de guardar el producto
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedItem != null)
            {
                ClsProvedores proveedorSeleccionado = (ClsProvedores)cmbProveedor.SelectedItem;
                int cod_proveedor = proveedorSeleccionado.Cod;
                cProveedor.Cod = cod_proveedor;
            }
        }

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoProducto.SelectedItem != null)
            {
                CTipoProducto seleccion = (CTipoProducto)cmbTipoProducto.SelectedItem;
                int cod_tipo_producto = seleccion.Cod_tipo_producto;
                cTipoProducto.Cod_tipo_producto = cod_tipo_producto;
            }
        }

        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            try
            {
                CProducto cProducto = new CProducto();
                if (txtBuscar.Text != "")
                {
                    string cod = txtBuscar.Text;
                    dgvProductos.DataSource = cProducto.Filtrar(cod);
                }
                else
                {
                    cProducto.MostrarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CProducto cProducto = new CProducto();
                if (txtBuscar.Text != "")
                {
                    string cod = txtBuscar.Text;
                    dgvProductos.DataSource = cProducto.Filtrar(cod);
                }
                else
                {
                    dgvProductos.DataSource = cProducto.MostrarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto: " + ex.Message);
            }
        }

        private void dgvProductos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    btnCrear.Visible = false;
                    btnModificar.Visible = true;
                    btnEliminar.Visible = true;
                    btnCancelar.Visible = true;

                    DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];
                    txtCodProducto.Text = filaSeleccionada.Cells["cod_producto"].Value.ToString();
                    txtCod.Text = filaSeleccionada.Cells["cod_producto"].Value.ToString();
                    cmbProveedor.Text = filaSeleccionada.Cells["nombre_proveedor"].Value.ToString();
                    cmbTipoProducto.Text = filaSeleccionada.Cells["nombre_tipo_producto"].Value.ToString();
                    txtNombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();
                    txtPrecioVenta.Text = filaSeleccionada.Cells["precio_venta"].Value.ToString();
                    txtCosto.Text = filaSeleccionada.Cells["precio_costo"].Value.ToString();
                    txtGanancia.Text = filaSeleccionada.Cells["ganancia"].Value.ToString();
                    txtStock.Text = filaSeleccionada.Cells["stock"].Value.ToString();
                    dtpFechaVenc.Text = filaSeleccionada.Cells["fecha_venc"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Selecciona una fila en la grilla antes de cargar los datos.", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del producto: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarCampos();
                cancelarActualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar la operación: " + ex.Message);
            }
        }

        private void cancelarActualizar()
        {
            btnCrear.Visible = true;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnCancelar.Visible = false;
        }

        private void limpiarCampos()
        {
            txtCodProducto.Text = "";
            cmbTipoProducto.Text = "";
            cmbProveedor.Text = "";
            txtCod.Text = "";
            txtNombre.Text = "";
            dtpFechaVenc.Text = "";
            txtPrecioVenta.Text = "";
            txtCosto.Text = "";
            txtGanancia.Text = "";
            txtStock.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtPrecioVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtCodProducto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtNombre_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtPrecioVenta_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtCosto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtStock_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TextBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void cmbProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void cmbProveedor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Deshabilita el menú contextual al hacer clic derecho en el ComboBox
                ((ComboBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void cmbTipoProducto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Deshabilita el menú contextual al hacer clic derecho en el ComboBox
                ((ComboBox)sender).ContextMenuStrip = new ContextMenuStrip();
            }
        }

        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}

