using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            double precio_publico = double.Parse(txtPrecioPublico.Text);
            int existencias = int.Parse(txtExistencias.Text);

            // Creamos la transaccion que queramos.
            string sql = $"INSERT INTO producto (codigo, nombre, descripcion, precio_publico, existencias) VALUES ('{codigo}', '{nombre}', '{descripcion}', '{precio_publico}', '{existencias}')";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {

                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                
                comando.ExecuteNonQuery(); // Ejecutamos el comando.
                MessageBox.Show("Registro Guardado");
            } catch(MySqlException ex)
            {
                MessageBox.Show($"Error al Guardar: {ex}");
            }
            finally
            {
                conexionBD.Close();
                limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtenemos el codigo a buscar
            String codigo = txtCodigo.Text;

            // Creamos un reader
            MySqlDataReader reader = null;

            // Creamos la consulta.

            string sql = $"SELECT id, codigo, nombre, descripcion, precio_publico, existencias FROM producto WHERE codigo = '{codigo}' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader(); // Aqui tenemos ya el resultado de la consulta
                // Validamos
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Visible = true; //423142
                        txtId.Text = reader.GetString(0);
                        txtCodigo.Text = reader.GetString(1);
                        txtNombre.Text = reader.GetString(2);
                        txtDescripcion.Text = reader.GetString(3);
                        txtPrecioPublico.Text = reader.GetString(4);
                        txtExistencias.Text = reader.GetString(5);
                    }
                } else
                {
                    MessageBox.Show("No se encontraron registros.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al Guardar: {ex}");
            }
            finally
            {
                conexionBD.Close();
            }
        }
        
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioPublico.Text = "";
            txtExistencias.Text = "";
        }
    }
}
