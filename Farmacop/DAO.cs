using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Farmacop
{
    //Esta clase se encargará de realizar las conexiones a la base de datos

    public class DAO
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
        public string GetCredentials(string email)
        {
            string data = null;
            string sql = "select Correo,Contrasena,Tipo from Usuarios where Correo like \"" + email +"\" and Validada = 1";

            MySqlCommand cmd = new MySqlCommand(sql,conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if(DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["Correo"].ToString() + ":" + DataReader["Contrasena"].ToString() + ":" + DataReader["Tipo"].ToString();
                    }
                    catch (Exception e) { throw new Exception("Error al conectar al servidor."); }
            }

            DataReader.Close();
            return data;
        }

        #region Usuarios
        //Obtiene los datos del usuario en cuestión
        public string GetUserData(string email)
        {
            string data = null;
            string sql = "select Correo,Contrasena,Tipo,Nombre,Apellido1,Apellido2,FechaNac from Usuarios where Correo like \"" + email + "\" and Validada = 1";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["Nombre"].ToString() + ";" + DataReader["Apellido1"].ToString() + ";" + DataReader["Apellido2"].ToString() + ";" +
                            DataReader["Correo"].ToString() + ";" + DataReader["Contrasena"].ToString() + ";" + DataReader["FechaNac"].ToString() + ";" + DataReader["Tipo"].ToString();
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return data;
        }

        //Validada un usuario desde el formulario de activación del login
        public bool ActivateUserWithPass(string email, string pass)
        {
            string sql = "update Usuarios set Validada = 1, Contrasena = \"" + Sesion.StringToMD5(pass) + "\" where Correo like \"" + email + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Obtiene las cuentas que no están activadas y no son pacientes para poder activarlas en el formulario de activación debajo de la pantalla de login
        public List<string> GetNonActiveUserEMailForRegist()
        {
            List<string> EmailList = new List<string>();
            string sql = "select Correo from Usuarios where Validada = 0 and Tipo not like \"Paciente\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();     

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        EmailList.Add(DataReader["Correo"].ToString());
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return EmailList;
        }

        //Actualiza la contraseña de un usuario
        public bool UpdateUserPassWord(string email, string newPass)
        {
            string sql = "update Usuarios set Contrasena = \"" + newPass + "\" where Correo like \""+ email +"\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Actualiza los datos de un usuario
        public bool UpdateUserData(string Name, string FApl, string SApl, string FNac, string email)
        {
            string sql = "update Usuarios set Nombre = \"" + Name + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\' where Correo like \"" + email + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Actualiza los datos de un usuario
        public bool UpdateModUserData(string Name, string FApl, string SApl, string FNac,string Type, string email)
        {
            string sql = "update Usuarios set Nombre = \"" + Name + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\', Tipo = \'" + Type + "\' where Correo like \"" + email + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Agregar un usuario
        public bool InsertUserData(string Name, string FApl, string SApl, string FNac, string Type, string email)
        {
            string sql = "Insert into Usuarios set Correo = \"" + email + "\", Nombre = \"" + Name + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\', Tipo = \'" + Type + "\', Contrasena = \"" + Sesion.StringToMD5(email+Name+"NewUser") + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Obtiene todos los correos de los usuarios menos el de la sesion
        public List<string> GetAllUsersEmail()
        {
            List<string> emails = new List<string>();
            string sql = "select Correo from Usuarios where Validada = 1 and Correo not like \"" + Sesion.Email + "\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        emails.Add(DataReader["Correo"].ToString());
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();

            return emails;
        }

        //Obtiene todos los usuarios para la tabla de Usuarios
        public List<User> GetAllUsersData()
        {
            List<User> Users = new List<User>();
            string sql = "";
            if (Sesion.UserType == UserType.Admin)
                sql = "select Correo,Nombre,Apellido1,Apellido2,FechaNac,Tipo,Deshabilitada from Usuarios where Validada = 1 and Correo not like \"" + Sesion.Email + "\"";
            else
                sql = "select Correo,Nombre,Apellido1,Apellido2,FechaNac,Tipo,Deshabilitada from Usuarios where Validada = 1 and Correo not like \"" + Sesion.Email + "\" and Tipo not like \"Admin\" and Tipo not like \"Medico\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        Users.Add(new User(DataReader["Nombre"].ToString(), DataReader["Apellido1"].ToString(), DataReader["Apellido2"].ToString(), DataReader["Correo"].ToString(),
                            DateTime.Parse(DataReader["FechaNac"].ToString()).ToString("dd/MM/yyyy"), DataReader["Tipo"].ToString(), DataReader["Deshabilitada"].ToString().Equals("False")));
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();

            return Users;
        }

        //Disables User
        public bool DisableUser(string email)
        {
            string sql = "update Usuarios set Deshabilitada = 1 where Correo like \"" + email + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Enables User
        public bool EnableUser(string email)
        {
            string sql = "update Usuarios set Deshabilitada = 0 where Correo like \"" + email + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }
        #endregion

        #region Medicamentos
        //Obtiene todos los medicamentos de la base de datos
        public List<Medicament> GetAllMedicaments()
        {
            List<Medicament> MedicamentList = null;
            string sql = "select Nombre,Tipo from Medicamentos";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)
            {
                MedicamentList = new List<Medicament>();
                while (DataReader.Read())
                {
                    Medicament Tmp = new Medicament(DataReader.GetString("Nombre"),DataReader.GetString("Tipo"));
                    MedicamentList.Add(Tmp);
                }
            }
            
            DataReader.Close();
            return MedicamentList;
        }

        //Elimina el medicamento a partir del nombre que se le indique
        public bool DeleteMedicament(string name)
        {
            string sql = "delete from Medicamentos where Nombre like \"" + name + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = 0;
            try {
                qr = cmd.ExecuteNonQuery();
            }
            catch(Exception e) { }
            return qr > 0;
        }

        //Inserta un medicamento
        public bool InsertMedicament(string name, string type)
        {
            string sql = "insert into Medicamentos (Nombre,Tipo) values (\"" + name + "\", \"" + type +"\")";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Modifica un medicamento
        public bool UpdateMedicament(string oldname, string newname, string type)
        {
            string sql = "update Medicamentos set Nombre = \"" + newname + "\", Tipo = \"" + type + "\" where Nombre like \"" + oldname + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }
        #endregion

        #region Mensajes
        //Obtiene los mensajes enviados
        public List<Message> GetAllSendedMessages(string email)
        {
            List<Message> LMessages = new List<Message>();
            string sql = "select ID, Correo_Envia, Correo_Recibe, Asunto, Mensaje, Leido from Mensajes where Correo_Envia like \'" + email + "\' order by ID DESC";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        LMessages.Add(new Message(int.Parse(DataReader["ID"].ToString()), DataReader["Correo_Envia"].ToString(), DataReader["Correo_Recibe"].ToString(),
                        DataReader["Asunto"].ToString(), DataReader["Mensaje"].ToString(), DataReader["Leido"].ToString().Equals("True")));
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return LMessages;
        }
        //Obtiene los mensajes recibidos
        public List<Message> GetAllReceivedMessages(string email)
        {
            List<Message> LMessages = new List<Message>();
            string sql = "select ID, Correo_Envia, Correo_Recibe, Asunto, Mensaje, Leido from Mensajes where Correo_Recibe like \'" + email + "\' order by ID DESC";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        LMessages.Add(new Message(int.Parse(DataReader["ID"].ToString()), DataReader["Correo_Envia"].ToString(), DataReader["Correo_Recibe"].ToString(),
                            DataReader["Asunto"].ToString(), DataReader["Mensaje"].ToString(), DataReader["Leido"].ToString().Equals("True")));
                    }
                    catch(Exception e) { throw; }
                }

            DataReader.Close();
            return LMessages;
        }
        //Actualiza a leido el mensaje
        public bool SetReaded(int msgId)
        {
            string sql = "update Mensajes set Leido = 1 where ID = " + msgId + "";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }
        //Insertar mensaje
        public bool InsertMsg(string Sender, string Receiver, string Matter, string Message)
        {
            string sql = "insert into Mensajes (Correo_Envia, Correo_Recibe, Asunto, Mensaje) values (\"" + Sender + "\",\"" + Receiver + "\",\"" + Matter + "\",\"" + Message + "\")";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        #endregion
    }
}
