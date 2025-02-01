using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormAsistencia : Form
    {
        private ConexionBD conexionBD = ConexionBD.Instancia;
        private readonly CTipoMembresia cTipoMembresia = new CTipoMembresia();


        public FormAsistencia()
        {
            InitializeComponent();
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            CargarDatagrid();
            CargarCBTipoMembresia();
            CargarLabelDiaDeHoy();
            FechaFin7Dias();
            CargarColor();
        }

        public void LoadArtificial()
        {
            CargarDatagrid();
            CargarCBTipoMembresia();
            CargarLabelDiaDeHoy();
            FechaFin7Dias();
            CargarColor();
        }

        public DataTable TraerAsistenciasDelDia()
        {
            // Consulta SQL para obtener las asistencias del día actual con columnas separadas de Fecha y Hora
            string query = @"
        DECLARE @Hoy DATE = CONVERT(DATE, GETDATE());

        SELECT 
            CONVERT(DATE, a.fecha_asistencia) AS 'Fecha',
            CONVERT(TIME, a.fecha_asistencia) AS 'Hora',
            s.dni_socio AS 'DNI Socio',
            (s.nombre + ' ' + s.apellido) AS 'Nombre Completo',
            tm.nombre AS 'Tipo de Membresía',
            DATEDIFF(DAY, @Hoy, m.fecha_fin) AS 'Días Restantes'
        FROM asistencias a
        INNER JOIN socios s ON a.id_socio = s.id_socio
        LEFT JOIN membresias m ON s.id_socio = m.id_socio
            AND @Hoy BETWEEN m.fecha_inicio AND m.fecha_fin
        LEFT JOIN tipos_membresias tm ON m.cod_tipo_membresia = tm.cod_tipo_membresia
        WHERE CONVERT(DATE, a.fecha_asistencia) = @Hoy
        ORDER BY a.fecha_asistencia ASC;
    ";

            DataTable tabla = new DataTable();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                SqlDataReader reader = comando.ExecuteReader();

                // Cargar los datos en el DataTable
                tabla.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en TraerAsistenciasDelDia: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
        }

        public DataTable TraerAsistenciasPorRango(DateTime fechaInicio, DateTime fechaFin, int tipoMembresia)
        {
            // Consulta SQL optimizada para obtener asistencias dentro del rango de fechas
            string query = @"
        DECLARE @Hoy DATE = CONVERT(DATE, GETDATE());

        WITH UltimaAsistencia AS (
            SELECT 
                a.id_socio,
                MAX(a.fecha_asistencia) AS UltimaFechaAsistencia
            FROM asistencias a
            INNER JOIN membresias m ON a.id_socio = m.id_socio 
                AND a.fecha_asistencia BETWEEN m.fecha_inicio AND m.fecha_fin
            WHERE a.fecha_asistencia >= @FechaInicio
                AND a.fecha_asistencia < DATEADD(DAY, 1, @FechaFin)
                AND m.cod_tipo_membresia = @TipoMembresia
            GROUP BY a.id_socio
        )
        SELECT 
            CONVERT(DATE, a.fecha_asistencia) AS 'Fecha',
            CONVERT(TIME, a.fecha_asistencia) AS 'Hora',
            s.dni_socio AS 'DNI Socio',
            (s.nombre + ' ' + s.apellido) AS 'Nombre Completo',
            t.nombre AS 'Tipo de Membresía',
            CASE 
                WHEN a.fecha_asistencia = u.UltimaFechaAsistencia THEN DATEDIFF(DAY, @Hoy, m.fecha_fin)
                ELSE NULL
            END AS 'Días Restantes'
        FROM asistencias a
        INNER JOIN socios s ON a.id_socio = s.id_socio
        INNER JOIN membresias m ON a.id_socio = m.id_socio 
            AND a.fecha_asistencia BETWEEN m.fecha_inicio AND m.fecha_fin
        INNER JOIN tipos_membresias t ON m.cod_tipo_membresia = t.cod_tipo_membresia
        LEFT JOIN UltimaAsistencia u ON a.id_socio = u.id_socio
        WHERE a.fecha_asistencia >= @FechaInicio
            AND a.fecha_asistencia < DATEADD(DAY, 1, @FechaFin)
            AND m.cod_tipo_membresia = @TipoMembresia
        ORDER BY a.fecha_asistencia ASC;
    ";

            DataTable tabla = new DataTable();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());

                // Agregar parámetros de las fechas al comando
                comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin", fechaFin);
                comando.Parameters.AddWithValue("@TipoMembresia", tipoMembresia);

                SqlDataReader reader = comando.ExecuteReader();

                // Cargar los datos en el DataTable
                tabla.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer asistencias: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla;
        }

        private DataTable Buscar(string criterioBusqueda)
        {
            string query = @"
                    SELECT 
                        CONVERT(DATE, a.fecha_asistencia) AS 'Fecha',
                        CONVERT(TIME, a.fecha_asistencia) AS 'Hora',
                        s.dni_socio AS 'DNI Socio',
                        (s.nombre + ' ' + s.apellido) AS 'Nombre Completo',
                        tm.nombre AS 'Tipo de Membresía',
                        DATEDIFF(DAY, GETDATE(), m.fecha_fin) AS 'Días Restantes'
                    FROM asistencias a
                    INNER JOIN socios s ON a.id_socio = s.id_socio
                    LEFT JOIN membresias m ON s.id_socio = m.id_socio
                    LEFT JOIN tipos_membresias tm ON m.cod_tipo_membresia = tm.cod_tipo_membresia
                    WHERE 
                        s.dni_socio LIKE @criterio 
                        OR (s.nombre + ' ' + s.apellido) LIKE @criterio
                    ORDER BY a.fecha_asistencia ASC;
                    ";

            DataTable tabla = new DataTable();

            try
            {
                SqlCommand comando = new SqlCommand(query, conexionBD.AbrirConexion());
                comando.Parameters.AddWithValue("@criterio", "%" + criterioBusqueda + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla); // Llena el DataTable con los resultados de la consulta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar asistencias: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return tabla; // Devuelve el DataTable con los datos filtrados
        }

        private void CargarLabelDiaDeHoy()
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Formatear la fecha al formato: "Viernes, 31 de Enero"
            string diaDeHoy = fechaActual.ToString("dddd, dd MMMM", new System.Globalization.CultureInfo("es-ES"));

            // Crear una instancia de TextInfo para el idioma español
            TextInfo textInfo = new System.Globalization.CultureInfo("es-ES", false).TextInfo;

            // Dividir la cadena en partes
            string[] partes = diaDeHoy.Split(new[] { ' ' }, 3); // Dividir en 3 partes: día, número y "de mes"

            // Convertir solo el nombre del día y el mes a mayúscula
            string dia = textInfo.ToTitleCase(partes[0]); // Nombre del día
            string mes = textInfo.ToTitleCase(partes[2]); // Nombre del mes

            // Unir las partes nuevamente, asegurando que "de" esté en minúscula
            diaDeHoy = $"{dia} {partes[1]} de {mes}";

            // Asignar el texto al label
            lblDiaDeHoy.Text = diaDeHoy;
        }

        public void CargarDatagrid()
        {
            try
            {
                dgvAsistencias.DataSource = TraerAsistenciasDelDia();

                dgvAsistencias.AutoResizeColumns();
                dgvAsistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el datagrid: " + ex.Message);
            }
        }

        public void CargarCBTipoMembresia()
        {
            List<CTipoMembresia> tipos = cTipoMembresia.traerTipos();
            cbTipoMembresia.DataSource = tipos;
            cbTipoMembresia.DisplayMember = "nombre";
            cbTipoMembresia.ValueMember = "cod_tipo_membresia";
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que la fecha de inicio no sea mayor a la fecha de fin
                if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el tipo de membresía seleccionado
                int tipoMembresiaSeleccionado = Convert.ToInt32(cbTipoMembresia.SelectedValue);

                // Llamar a la función para obtener las asistencias filtradas por rango y tipo de membresía
                DataTable asistencias = TraerAsistenciasPorRango(dtpFechaInicio.Value, dtpFechaFin.Value, tipoMembresiaSeleccionado);

                // Asignar el resultado al DataGridView
                dgvAsistencias.DataSource = asistencias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al filtrar las asistencias: " + ex.Message);
            }
        }


        public void FechaFin7Dias()
        {
            // Configurar valores predeterminados
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7); // 7 días antes de hoy
            dtpFechaFin.Value = DateTime.Today; // Día actual
            dtpFechaInicio.ValueChanged += dtpFechaInicio_ValueChanged;
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            // Establece la fecha de inicio a las 00:00 y la fecha de fin a las 23:59
            DateTime fechaInicio = dtpFechaInicio.Value.Date; // Fecha sin hora (00:00)
            dtpFechaInicio.Value = fechaInicio;
            dtpFechaFin.Value = fechaInicio.AddDays(1).AddSeconds(-1); // Mismo día a las 23:59:59
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    // Llama a la función Buscar con el texto del TextBox
                    DataTable tablaAsistencias = Buscar(txtBuscar.Text);
                    dgvAsistencias.DataSource = tablaAsistencias; // Asigna los resultados al DataGridView
                }
                else
                {
                    // Si el campo está vacío, carga las asistencias del día
                    dgvAsistencias.DataSource = TraerAsistenciasDelDia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda: " + ex.Message);
            }
        }

        private void lblDiaDeHoy_Click(object sender, EventArgs e)
        {
            // Generar un color aleatorio
            Random random = new Random();
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            // Cambiar el ForeColor del label
            lblDiaDeHoy.ForeColor = randomColor;

            // Guardar el color en un archivo para que persista
            GuardarColor(randomColor);
        }

        private void GuardarColor(Color color)
        {
            string filePath = Path.Combine(Application.StartupPath, "color_config.txt");
            string colorString = $"{color.R},{color.G},{color.B}";
            File.WriteAllText(filePath, colorString);
        }

        private void CargarColor()
        {
            string filePath = Path.Combine(Application.StartupPath, "color_config.txt");

            if (File.Exists(filePath))
            {
                string colorString = File.ReadAllText(filePath);
                string[] rgb = colorString.Split(',');

                if (rgb.Length == 3 &&
                    int.TryParse(rgb[0], out int r) &&
                    int.TryParse(rgb[1], out int g) &&
                    int.TryParse(rgb[2], out int b))
                {
                    Color savedColor = Color.FromArgb(r, g, b);
                    lblDiaDeHoy.ForeColor = savedColor;
                }
            }
        }

        private void btnAsistenciasDiaActual_Click(object sender, EventArgs e)
        {
            CargarDatagrid();
        }
    }
}
