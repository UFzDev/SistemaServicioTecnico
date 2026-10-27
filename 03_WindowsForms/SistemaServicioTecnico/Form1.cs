using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaServicioTecnico.DAL;

namespace SistemaServicioTecnico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = ConexionBD.CrearConexion())
                {
                    con.Open();
                    MessageBox.Show("Conexión exitosa a SQL Server: " + con.Database,
                                    "Prueba de Comunicación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fallo de conexión SQL (Error " + ex.Number + "): " + ex.Message,
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message,
                                "Excepción",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
