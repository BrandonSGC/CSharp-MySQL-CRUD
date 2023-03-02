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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            double precio_publico =double.Parse(txtPrecioPublico.Text);
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
                MessageBox.Show("Error al Guardar");
            }
            finally
            {
                conexionBD.Close();
                limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

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
