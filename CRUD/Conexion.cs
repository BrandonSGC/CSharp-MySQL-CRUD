using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "tienda";
            string usuario = "root";
            string contrasena = "root";

            string cadenaConexion = $"Database={bd};Data Source={servidor};User Id={usuario};Password={contrasena}";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            } catch (MySqlException ex)
            {               
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
