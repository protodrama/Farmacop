using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Farmacop
{
    //Esta clase se encargará de realizar las conexiones a la base de datos

    class DAO
    {
        //Conexión a base de datos MySql
        private MySqlConnection conexion;

        #region Conexion y desconexion
        public bool Conectar(string srv, string db, string user, string pwd)
        {
            string cadenaConexion = "server=" + srv + "; Port=3306; database=" + db + "; "
                + "userid=" + user + "; " + "pwd=" + pwd + ";";
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open(); //conexión habilitada
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 113: throw new Exception("Error en la conexión");
                    case 1045: throw new Exception("Usuario o contraseña incorrectos");
                    default:
                        throw;
                }
            }
        } 

        public void Desconectar()
        {
            conexion.Close();
            conexion = null;
        }
        #endregion

        //Obtiene las credenciales del usuario indicado
        public string GetCredentials(string correo)
        {
            string data = null;
            string sql = "select Correo,Contrasena,Tipo from Usuarios where Correo like \"" + correo +"\"";

            MySqlCommand cmd = new MySqlCommand(sql,conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if(DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["Correo"].ToString() + ":" + DataReader["Contrasena"].ToString() + ":" + DataReader["Tipo"].ToString();
                    }
                    catch (Exception e) { throw; }
            }

            DataReader.Close();
            return data;
        }

        //Obtiene los datos del usuario en cuestión
        public string GetUserData(string correo)
        {
            string data = null;
            string sql = "select Correo,Contrasena,Tipo,Nombre,Apellido1,Apellido2 from Usuarios where Correo like \"" + correo + "\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["Nombre"].ToString() + ":" + DataReader["Apellido1"].ToString() + ":" + DataReader["Apellido2"].ToString() +
                            DataReader["Correo"].ToString() + ":" + DataReader["Contrasena"].ToString() + ":" + DataReader["Tipo"].ToString();
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return data;
        }
    }
}
