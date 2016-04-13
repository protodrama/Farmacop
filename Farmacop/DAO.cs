﻿using System;
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
        private bool _connected;

        #region Conexion y desconexion
        public bool IsConnected
        {
            get
            {
                return _connected;
            }

            set
            {
                _connected = value;
            }
        }

        public bool Connect(string srv, string db, string user, string pwd)
        {
            string cadenaConexion = "server=" + srv + "; Port=3306; database=" + db + "; "
                + "userid=" + user + "; " + "pwd=" + pwd + ";";
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open(); //conexión habilitada
                IsConnected = true;
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

        public void Disconnect()
        {
            conexion.Close();
            IsConnected = false;
            conexion = null;
        }
        #endregion

        #region Usuarios
        //Obtiene las credenciales del usuario indicado
        public string GetCredentials(string account)
        {
            string data = null;
            string sql = "select Cuenta,Contrasena,Tipo from Usuarios where Cuenta like \"" + account + "\" and Validada = 1 and Conectada = 0";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["Cuenta"].ToString() + ":" + DataReader["Contrasena"].ToString() + ":" + DataReader["Tipo"].ToString();
                    }
                    catch (Exception e) { throw new Exception("Error al conectar al servidor."); }
                }

            DataReader.Close();
            return data;
        }

        //Actualiza la conexion a true
        public bool UserConnect(string account)
        {
            string sql = "update Usuarios set Conectada = 1 where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Actualiza la conexion a true
        public bool UserDisconnect(string account)
        {
            string sql = "update Usuarios set Conectada = 0 where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Obtiene los datos del usuario en cuestión
        public string GetUserData(string account)
        {
            string data = null;
            string sql = "select Cuenta,Contrasena,Tipo,Nombre,Apellido1,Apellido2,FechaNac from Usuarios where Cuenta like \"" + account + "\" and Validada = 1";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["Nombre"].ToString() + ";" + DataReader["Apellido1"].ToString() + ";" + DataReader["Apellido2"].ToString() + ";" +
                            DataReader["Cuenta"].ToString() + ";" + DataReader["Contrasena"].ToString() + ";" + DataReader["FechaNac"].ToString() + ";" + DataReader["Tipo"].ToString();
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return data;
        }

        //Validada un usuario desde el formulario de activación del login
        public bool ActivateUserWithPass(string account, string pass)
        {
            string sql = "update Usuarios set Validada = 1, Contrasena = \"" + Sesion.StringToMD5(pass) + "\" where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Obtiene las cuentas que no están activadas y no son pacientes para poder activarlas en el formulario de activación debajo de la pantalla de login
        public List<string> GetNonActiveUserEMailForRegist()
        {
            List<string> EmailList = new List<string>();
            string sql = "select Cuenta from Usuarios where Validada = 0 and Tipo not like \"Paciente\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();     

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        EmailList.Add(DataReader["Cuenta"].ToString());
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return EmailList;
        }

        //Actualiza la contraseña de un usuario
        public bool UpdateUserPassWord(string account, string newPass)
        {
            string sql = "update Usuarios set Contrasena = \"" + newPass + "\" where Cuenta like \"" + account +"\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Actualiza los datos de un usuario
        public bool UpdateUserData(string Name, string FApl, string SApl, string FNac, string account)
        {
            string sql = "update Usuarios set Nombre = \"" + Name + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\' where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Actualiza los datos de un usuario
        public bool UpdateModUserData(string Name, string FApl, string SApl, string FNac,string Type, string account)
        {
            string sql = "update Usuarios set Nombre = \"" + Name + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\', Tipo = \'" + Type + "\' where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Agregar un usuario
        public bool InsertUserData(string Name, string FApl, string SApl, string FNac, string Type, string account)
        {
            string sql = "Insert into Usuarios set Cuenta = \"" + account + "\", Nombre = \"" + Name + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\', Tipo = \'" + Type + "\', Contrasena = \"" + Sesion.StringToMD5(account+Name+"NewUser"+new Random().Next(100)) + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Obtiene todos los correos de los usuarios menos el de la sesion
        public List<string> GetAllUsersNameAccount()
        {
            List<string> emails = new List<string>();
            string sql = "select Cuenta from Usuarios where Validada = 1 and Cuenta not like \"" + Sesion.Account + "\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        emails.Add(DataReader["Cuenta"].ToString());
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
                sql = "select Cuenta,Nombre,Apellido1,Apellido2,FechaNac,Tipo,Deshabilitada from Usuarios where Validada = 1 and Cuenta not like \"" + Sesion.Account + "\"";
            else
                sql = "select Cuenta,Nombre,Apellido1,Apellido2,FechaNac,Tipo,Deshabilitada from Usuarios where Validada = 1 and Cuenta not like \"" + Sesion.Account + "\" and Tipo not like \"Admin\" and Tipo not like \"Medico\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        Users.Add(new User(DataReader["Nombre"].ToString(), DataReader["Apellido1"].ToString(), DataReader["Apellido2"].ToString(), DataReader["Cuenta"].ToString(),
                            DateTime.Parse(DataReader["FechaNac"].ToString()).ToString("dd/MM/yyyy"), DataReader["Tipo"].ToString(), DataReader["Deshabilitada"].ToString().Equals("False")));
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();

            return Users;
        }

        //Disables User
        public bool DisableUser(string account)
        {
            string sql = "update Usuarios set Deshabilitada = 1 where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Enables User
        public bool EnableUser(string account)
        {
            string sql = "update Usuarios set Deshabilitada = 0 where Cuenta like \"" + account + "\"";
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

        //Modifica el tipo de un medicamento
        public bool UpdateTypeMedicament(string name, string type)
        {
            string sql = "update Medicamentos set Tipo = \"" + type + "\" where Nombre like \"" + name + "\"";
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

        #region Alergias

        //Insertar alergia para un usuario
        public bool InsertAlg(string account, string medicament)
        {
            string sql = "insert into Alergias values (\"" + account + "\", (select ID from Medicamentos where Nombre like \"" + medicament + "\"))";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        //Eliminar alergia para un usuario
        public bool DeleteAlg(string account, string medicament)
        {
            string sql = "delete from Alergias where Cuenta like \"" + account + "\" and ID_Medicamento = (select ID from Medicamentos where Nombre like \"" + medicament + "\")";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        public List<string> GetUserAlg(string account)
        {
            List<string> AlgList = new List<string>();
            string sql = "select Nombre from Medicamentos where ID in (select ID_Medicamento from Alergias where Cuenta like '" + account + "')";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    AlgList.Add(DataReader.GetString("Nombre"));
                }
            }

            DataReader.Close();
            return AlgList;
        }

        #endregion

        #region Mensajes
        //Obtiene los mensajes enviados
        public List<Message> GetAllSendedMessages(string account)
        {
            List<Message> LMessages = new List<Message>();
            string sql = "select ID, Cuenta_Envia, Cuenta_Recibe, Asunto, Mensaje, Leido from Mensajes where Cuenta_Envia like \'" + account + "\' order by ID DESC";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        LMessages.Add(new Message(int.Parse(DataReader["ID"].ToString()), DataReader["Cuenta_Envia"].ToString(), DataReader["Cuenta_Recibe"].ToString(),
                        DataReader["Asunto"].ToString(), DataReader["Mensaje"].ToString(), DataReader["Leido"].ToString().Equals("True")));
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            return LMessages;
        }
        //Obtiene los mensajes recibidos
        public List<Message> GetAllReceivedMessages(string account)
        {
            List<Message> LMessages = new List<Message>();
            string sql = "select ID, Cuenta_Envia, Cuenta_Recibe, Asunto, Mensaje, Leido from Mensajes where Cuenta_Recibe like \'" + account + "\' order by ID DESC";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        LMessages.Add(new Message(int.Parse(DataReader["ID"].ToString()), DataReader["Cuenta_Envia"].ToString(), DataReader["Cuenta_Recibe"].ToString(),
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
            string sql = "insert into Mensajes (Cuenta_Envia, Cuenta_Recibe, Asunto, Mensaje) values (\"" + Sender + "\",\"" + Receiver + "\",\"" + Matter + "\",\"" + Message + "\")";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            return qr > 0;
        }

        #endregion

        #region Recetas
        public List<Recepie> GetAllRecepies()
        {
            List<Recepie> Recepies = new List<Recepie>();
            string sql = "select re.ID,re.Paciente,re.Medico,re.FechaInic,re.FechaFin,me.Nombre as Medicamento,re.Dosis from Recetas as re " + 
                " left join Medicamentos as me on re.ID_Medicamento = me.ID";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        Recepies.Add(new Recepie(int.Parse(DataReader["ID"].ToString()), DataReader["Paciente"].ToString(), DataReader["Medico"].ToString(),
                            DateTime.Parse(DataReader["FechaInic"].ToString()).ToShortDateString(), DateTime.Parse(DataReader["FechaFin"].ToString()).ToShortDateString(),
                            DataReader["Medicamento"].ToString(), int.Parse(DataReader["Dosis"].ToString())));
                    }
                    catch (Exception e) { throw new Exception("Error al obtener las recetas."); }
                }

            DataReader.Close();

            foreach (Recepie temp in Recepies)
                temp.SetRControl(GetAllRecControl(temp.getId()));

            return Recepies;
        }

        public List<Taken> GetAllRecControl(int idRec)
        {
            List<Taken> RControl = new List<Taken>();
            string sql = "select Fecha,Hora,Minuto,Tomada from Rec_Control where ID_Receta = " + idRec;

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        RControl.Add(new Taken(DateTime.Parse(DataReader["Fecha"].ToString()).ToShortDateString(), DataReader["Hora"].ToString() +":" + DataReader["Minuto"].ToString(), DataReader["Tomada"].ToString().Equals("1")));
                    }
                    catch (Exception e) { throw new Exception("Error al conectar al servidor."); }
                }

            DataReader.Close();


            return RControl;
        }



        #endregion
    }
}
