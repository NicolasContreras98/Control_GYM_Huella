using System;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormAjustes : Form
    {
        private string metodoOriginal;
        private bool cambiosAplicadosSinGuardar = false;

        public FormAjustes()
        {
            InitializeComponent();
        }

        private void FormAjustes_Load(object sender, EventArgs e)
        {

        }

        public void LoadArtificial()
        {
            CargarCombobox();
            CargarPreferencias();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string metodoNuevo = cbMetodoVerificacion.SelectedItem.ToString();
            bool requiereReinicio = metodoNuevo != metodoOriginal;

            Properties.Settings.Default.MetodoVerificacion = metodoNuevo;
            Properties.Settings.Default.Save();

            metodoOriginal = metodoNuevo;
            cambiosAplicadosSinGuardar = false; // ahora ya está guardado

            MessageBox.Show("Cambios guardados correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (requiereReinicio)
            {
                DialogResult resultado = MessageBox.Show("Se requiere reiniciar el programa para aplicar los cambios. ¿Desea reiniciar ahora?",
                                                         "Reinicio requerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }

            btnGuardar.Enabled = false;
            btnAplicar.Enabled = false;
            btnReestablecer.Enabled = true;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            string metodoNuevo = cbMetodoVerificacion.SelectedItem.ToString();

            if (metodoNuevo != metodoOriginal)
            {
                // Aplicar en tiempo de ejecución (esto depende de cómo usás MetodoVerificacion)
                // No guardamos aún, solo marcamos como aplicado
                cambiosAplicadosSinGuardar = true;

                //MessageBox.Show("Los cambios se han aplicado temporalmente. Para conservarlos, presione 'Guardar'.",
                //                "Aplicar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnGuardar.Enabled = true; // el usuario puede guardar si quiere
            }

            btnAplicar.Enabled = false;
            btnReestablecer.Enabled = true;
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas restablecer los valores predeterminados?",
                                                  "Restablecer ajustes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string valorPorDefecto = "Lector de huellas";
                string valorActual = cbMetodoVerificacion.SelectedItem.ToString();

                // Solo cambiamos si es diferente
                if (valorActual != valorPorDefecto)
                {
                    cbMetodoVerificacion.SelectedItem = valorPorDefecto;
                    Properties.Settings.Default.MetodoVerificacion = valorPorDefecto;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Los ajustes han sido restablecidos. Algunos cambios requieren reiniciar el programa para aplicarse.",
                                    "Restablecido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Solo ahora activamos los botones, porque hay cambios
                    btnGuardar.Enabled = true;
                    btnAplicar.Enabled = true;
                    btnReestablecer.Enabled = false;
                }
                else
                {
                    // Ya está en el valor por defecto
                    MessageBox.Show("Los ajustes ya están en su valor predeterminado.",
                                    "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnGuardar.Enabled = false;
                    btnAplicar.Enabled = false;
                }

                // Importante: no actualizamos metodoOriginal aquí
                // Así detectamos si hubo realmente un cambio para que btnGuardar lo maneje correctamente
            }
        }

        private void cbMetodoVerificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si cambió el método, se habilita el botón Guardar
            if (cbMetodoVerificacion.SelectedItem.ToString() != metodoOriginal)
            {
                btnGuardar.Enabled = true;
                btnAplicar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void CargarPreferencias()
        {
            // Cargar valores actuales desde Settings
            cbMetodoVerificacion.SelectedItem = Properties.Settings.Default.MetodoVerificacion;

            // Guardar valores originales para comparar cambios
            metodoOriginal = Properties.Settings.Default.MetodoVerificacion;

            // Al inicio, el botón guardar y aplicar está deshabilitado
            btnGuardar.Enabled = false;
            btnAplicar.Enabled = false;
            btnReestablecer.Enabled = true;
        }

        private void CargarCombobox()
        {
            cbMetodoVerificacion.Items.Add("Teclado numérico");
            cbMetodoVerificacion.Items.Add("Lector de huellas");
        }

        private void FormAjustes_Leave(object sender, EventArgs e)
        {
            if (cambiosAplicadosSinGuardar)
            {
                DialogResult result = MessageBox.Show("Hay cambios aplicados que no han sido guardados. ¿Desea guardarlos antes de salir?",
                                                      "Cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnGuardar.PerformClick();
                }

                // Si dice "No", no hacemos nada, pero no podemos impedir que salga
            }
        }
    }
}
