using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace Farmacop
{
    //Esta clase se encargará de realizar las conexiones a la base de datos

    public class DAO
    {
        string loginURL = "https://jfrodriguez.pw/slimrest/api/Login";
        string UserdataURL = "https://jfrodriguez.pw/slimrest/api/Userdata";
        string GetNewMessagesURL = "https://jfrodriguez.pw/slimrest/api/NotReadedMessages";
        string GetReceibedMessagesURL = "https://jfrodriguez.pw/slimrest/api/ReceibedMessages";
        string GetSendedMessagesURL = "https://jfrodriguez.pw/slimrest/api/SendedMessages";
        string GetNotValidatedUsersURL = "https://jfrodriguez.pw/slimrest/api/getNotPatientUnvalidated"; 
        string ValidateUserURL = "https://jfrodriguez.pw/slimrest/api/Validate";
        string GetNoPatientUsersURL = "https://jfrodriguez.pw/slimrest/api/GetNoPatientUser";
        string RestpassURL = "https://jfrodriguez.pw/slimrest/api/restpass";
        string UpdatePasswordURL = "https://jfrodriguez.pw/slimrest/api/UpdatePassword";
        string UpdateMyUserDataURL = "https://jfrodriguez.pw/slimrest/api/UpdateUser";
        string GetMedicamentsDataURL = "https://jfrodriguez.pw/slimrest/api/GetAllMedicamentsData"; 
        string UpdateMedicamentURL = "https://jfrodriguez.pw/slimrest/api/UpdateMedicament";
        string AddMedicamentURL = "https://jfrodriguez.pw/slimrest/api/AddMedicament";
        string DeleteMedicamentURL = "https://jfrodriguez.pw/slimrest/api/DeleteMedicament";
        string ReadMessageURL = "https://jfrodriguez.pw/slimrest/api/ReadMessage";
        string AddMessageURL = "https://jfrodriguez.pw/slimrest/api/AddMessage";
        string GetAllUsersAccountURL = "https://jfrodriguez.pw/slimrest/api/getAllUsersAccount";

        string defApikey = "eadmghacdg";

        MySqlConnection conexion;

        #region Usuarios
        //Obtiene las credenciales del usuario indicado
        public string GetCredentials(string account)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(loginURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = account;
                query["apikey"] = defApikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error obteniendo los datos de conexion");
            }
        }

        //Obtiene las credenciales del usuario indicado
        public string GetUserEmail(string account)
        {
            Session.GettingData = true;
            string data = "";
            string sql = "select correo from Usuarios where Cuenta like \"" + account + "\" and Validada = 1";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        data = DataReader["correo"].ToString();
                    }
                    catch (Exception e) { throw new Exception("Error al conectar al servidor."); }
                }

            DataReader.Close();
            Session.GettingData = false;
            return data;
        }

        //Obtiene los datos del usuario en cuestión
        public string GetUserData(string account)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(UserdataURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = account;
                query["apikey"] = Session.Apikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error obteniendo los datos de conexion");
            }
        }

        //Validada un usuario desde el formulario de activación del login
        public bool ActivateUserWithPass(string account, string pass)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", account));
                postData.Add(new KeyValuePair<string, string>("apikey", defApikey));
                postData.Add(new KeyValuePair<string, string>("password", Session.StringToMD5(pass)));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(ValidateUserURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al activar usuario");
            }
        }

        //Obtiene las cuentas que no están activadas y no son pacientes para poder activarlas en el formulario de activación debajo de la pantalla de login
        public string GetNonActiveUserEMailForRegist()
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetNotValidatedUsersURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["apikey"] = defApikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error obteniendo los datos de conexion");
            }
        }

        //Obtiene las cuentas que pueden recuperar su contraseña
        public string GetUserAccountToRecPass()
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetNoPatientUsersURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["apikey"] = defApikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al obtener las cuentas");
            }
        }

        //Realiza la operacion de recuperado de contraseña
        public bool RecPass(string account, int code)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(RestpassURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = account;
                query["code"] = "" + code;
                query["npass"] = Session.StringToMD5("" + code);
                query["apikey"] = defApikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                return true;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la operación");
            }
        }

        //Actualiza la contraseña de tu usuario
        public bool UpdateUserPassWord(string newPass)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("password", newPass));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(UpdatePasswordURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al activar usuario");
            }
        }

        //Actualiza los datos de tu usuario
        public bool UpdateUserData(string Name, string FApl, string SApl, string FNac,string Email)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("date", FNac));
                postData.Add(new KeyValuePair<string, string>("fsur", FApl));
                postData.Add(new KeyValuePair<string, string>("ssur", SApl));
                postData.Add(new KeyValuePair<string, string>("name", Name));
                postData.Add(new KeyValuePair<string, string>("email", Email));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(UpdateMyUserDataURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        Session.GettingData = false;
                        return true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al activar usuario");
            }
        }

        //Actualiza los datos de un usuario
        public bool UpdateModUserData(string Name, string FApl, string SApl, string FNac,string Type, string account,string email)
        {
            Session.GettingData = true;
            string sql = "update Usuarios set Nombre = \"" + Name + "\", correo = \"" + email + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\', Tipo = \'" + Type + "\' where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            Session.GettingData = false;
            return qr > 0;
        }

        //Agregar un usuario
        public bool InsertUserData(string Name, string FApl, string SApl, string FNac, string Type, string account,string email)
        {
            Session.GettingData = true;
            string sql = "Insert into Usuarios set Cuenta = \"" + account + "\", Nombre = \"" + Name + "\", correo = \"" + email + "\", Apellido1 = \"" + FApl + "\", Apellido2 = \"" + SApl + "\", FechaNac = \'" + FNac + "\', Tipo = \'" + Type + "\', Contrasena = \"" + Session.StringToMD5(account+Name+"NewUser"+new Random().Next(100)) + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            Session.GettingData = false;
            return qr > 0;
        }

        //Obtiene todos los nombres de los usuarios menos el de la sesion
        public string GetAllUsersNameAccount()
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetAllUsersAccountURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error obteniendo los datos de los usuarios");
            }
        }

        //Obtiene todos los usuarios para la tabla de Usuarios
        public List<User> GetAllUsersData()
        {
            Session.GettingData = true;
            List<User> Users = new List<User>();
            string sql = "";
            if (Session.UserType == UserType.Admin)
                sql = "select Cuenta,Nombre,Apellido1,Apellido2,FechaNac,correo,Tipo,Deshabilitada from Usuarios where Validada = 1 and Cuenta not like \"" + Session.Account + "\"";
            else
                sql = "select Cuenta,Nombre,Apellido1,Apellido2,FechaNac,correo,Tipo,Deshabilitada from Usuarios where Validada = 1 and Cuenta not like \"" + Session.Account + "\" and Tipo not like \"Admin\" and Tipo not like \"Medico\"";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader DataReader = cmd.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    try
                    {
                        Users.Add(new User(DataReader["Nombre"].ToString(), DataReader["Apellido1"].ToString(), DataReader["Apellido2"].ToString(), DataReader["Cuenta"].ToString(),
                            DateTime.Parse(DataReader["FechaNac"].ToString()).ToString("dd/MM/yyyy"), DataReader["Tipo"].ToString(), DataReader["Deshabilitada"].ToString().Equals("False"), DataReader["correo"].ToString()));
                    }
                    catch (Exception e) { throw; }
                }

            DataReader.Close();
            Session.GettingData = false;
            return Users;
        }

        //Disables User
        public bool DisableUser(string account)
        {
            Session.GettingData = true;
            string sql = "update Usuarios set Deshabilitada = 1 where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            Session.GettingData = false;
            return qr > 0;
        }

        //Enables User
        public bool EnableUser(string account)
        {
            Session.GettingData = true;
            string sql = "update Usuarios set Deshabilitada = 0 where Cuenta like \"" + account + "\"";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            Session.GettingData = false;
            return qr > 0;
        }
        #endregion

        #region Medicamentos
        //Obtiene todos los medicamentos de la base de datos
        public string GetAllMedicaments()
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetMedicamentsDataURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error obteniendo los datos de conexion");
            }
        }

        //Elimina el medicamento a partir del nombre que se le indique
        public bool DeleteMedicament(string name)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(DeleteMedicamentURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["medname"] = name;
                builder.Query = query.ToString();
                string url = builder.ToString();
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.DeleteAsync(url).Result)
                    {
                        Session.GettingData = false;
                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al añadir el nuevo medicamento");
            }
        }

        //Inserta un medicamento
        public bool InsertMedicament(string name, string type)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("newname", name));
                postData.Add(new KeyValuePair<string, string>("newtype", type));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PostAsync(AddMedicamentURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al añadir el nuevo medicamento");
            }
        }

        //Modifica un medicamento
        public bool UpdateMedicament(string oldname, string newname, string type)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("newname", newname));
                postData.Add(new KeyValuePair<string, string>("oldname", oldname));
                postData.Add(new KeyValuePair<string, string>("newtype", type));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(UpdateMedicamentURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al actualizar el medicamento");
            }
        }
        #endregion

        #region Alergias

        //Insertar alergia para un usuario
        public bool InsertAlg(string account, string medicament)
        {
            Session.GettingData = true;
            string sql = "insert into Alergias values (\"" + account + "\", (select ID from Medicamentos where Nombre like \"" + medicament + "\"))";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            Session.GettingData = false;
            return qr > 0;
        }

        //Eliminar alergia para un usuario
        public bool DeleteAlg(string account, string medicament)
        {
            Session.GettingData = true;
            string sql = "delete from Alergias where Cuenta like \"" + account + "\" and ID_Medicamento = (select ID from Medicamentos where Nombre like \"" + medicament + "\")";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
            Session.GettingData = false;
            return qr > 0;
        }

        public List<string> GetUserAlg(string account)
        {
            Session.GettingData = true;
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
            Session.GettingData = false;
            return AlgList;
        }

        #endregion

        #region Mensajes
        //Obtiene los mensajes enviados
        public string GetAllSendedMessages()
        {
            try
            {
                var builder = new UriBuilder(GetSendedMessagesURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Obtiene los mensajes recibidos
        public string GetAllReceivedMessages()
        {
            try
            {
                var builder = new UriBuilder(GetReceibedMessagesURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        //Obtiene los mensajes no leidos
        public string GetNewMessages()
        {
            try
            {
                var builder = new UriBuilder(GetNewMessagesURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                builder.Query = query.ToString();
                string url = builder.ToString();

                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string result = content.ReadAsStringAsync().Result;
                                Session.GettingData = false;
                                return result;
                            }
                        }
                        else
                        {
                            Session.GettingData = false;
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Actualiza a leido el mensaje
        public bool SetReaded(int msgId)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("id", "" + msgId));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(ReadMessageURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al activar usuario");
            }
        }
        //Insertar mensaje
        public bool InsertMsg(string Receiver, string Subject, string Message)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("to", Receiver));
                postData.Add(new KeyValuePair<string, string>("subject", Subject));
                postData.Add(new KeyValuePair<string, string>("message", Message.Replace("\r\n","[**]")));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PostAsync(AddMessageURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al activar usuario");
            }
        }

        #endregion

        #region Recetas
        public List<Prescription> GetAllRecepies()
        {
            Session.GettingData = true;
            List<Prescription> Recepies = new List<Prescription>();
            string sql = "select re.ID,re.Paciente,re.Medico,re.FechaInic,re.FechaFin,me.Nombre as Medicamento,re.Dosis from Recetas as re " + 
                " left join Medicamentos as me on re.ID_Medicamento = me.ID";

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        Recepies.Add(new Prescription(int.Parse(DataReader["ID"].ToString()), DataReader["Paciente"].ToString(), DataReader["Medico"].ToString(),
                            DateTime.Parse(DataReader["FechaInic"].ToString()).ToShortDateString(), DateTime.Parse(DataReader["FechaFin"].ToString()).ToShortDateString(),
                            DataReader["Medicamento"].ToString(), int.Parse(DataReader["Dosis"].ToString())));
                    }
                    catch (Exception e) { throw new Exception("Error al obtener las recetas."); }
                }

            DataReader.Close();

            foreach (Prescription temp in Recepies)
            {
                temp.SetRControl(GetAllRecControl(temp.getId()));
                temp.SetTimes(GetAllHours(temp.getId()));
            }
            Session.GettingData = false;
            return Recepies;
        }

        public List<Taken> GetAllRecControl(int idRec)
        {
            Session.GettingData = true;
            List<Taken> RControl = new List<Taken>();
            string sql = "select Fecha,Hora,Minuto,Tomada from Rec_Control where ID_Receta = " + idRec;

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        RControl.Add(new Taken(DateTime.Parse(DataReader["Fecha"].ToString()).ToShortDateString(), int.Parse(DataReader["Hora"].ToString()).ToString("00") + ":" + int.Parse(DataReader["Minuto"].ToString()).ToString("00"), DataReader["Tomada"].ToString().Equals("1")));
                    }
                    catch (Exception e) { throw new Exception("Error al conectar al servidor."); }
                }

            DataReader.Close();

            Session.GettingData = false;
            return RControl;
        }

        public List<string> GetAllHours(int idRec)
        {
            Session.GettingData = true;
            List<string> Horas = new List<string>();
            string sql = "select Hora,Minuto from Horas where ID_Receta = " + idRec;

            MySqlCommand cmd = new MySqlCommand(sql, conexion); //Comando de consulta sql
            MySqlDataReader DataReader = cmd.ExecuteReader();      //Lector de consulta sql

            if (DataReader.HasRows)  //Si tiene filas lee el contenido y devuelve las credenciales
                while (DataReader.Read())
                {
                    try
                    {
                        Horas.Add(int.Parse(DataReader["Hora"].ToString()).ToString("00") + ":" + int.Parse(DataReader["Minuto"].ToString()).ToString("00"));
                    }
                    catch (Exception e) { throw new Exception("Error al conectar al servidor."); }
                }

            DataReader.Close();
            Session.GettingData = false;
            return Horas;
        }

        public bool DeleteRecepie(Prescription recepie)
        {
            Session.GettingData = true;
            string sqlc = "delete from Rec_Control where ID_Receta = " + recepie.getId();
            MySqlCommand cmdc = new MySqlCommand(sqlc, conexion);
            int qr = cmdc.ExecuteNonQuery();

            string sqlh = "delete from Horas where ID_Receta = " + recepie.getId();
            MySqlCommand cmdh = new MySqlCommand(sqlh, conexion);
            int qrh = cmdh.ExecuteNonQuery();

            string sql = "delete from Recetas where ID = " + recepie.getId();
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qrr = cmd.ExecuteNonQuery();

            if (qrr > 0)
            {
                InsertMsg(recepie.Paciente, "Eliminacion de receta", "Se ha eliminaro su receta con el medicamento " + recepie.Medicamento + " que comenzaba el día " + recepie.FechaInicio +
                    " y terminaba el día " + recepie.FechaFin);
                //Session.SendEmail("Eliminacion de receta", "Se ha eliminaro su receta con el medicamento " + recepie.Medicamento + " que comenzaba el día " + recepie.FechaInicio +
                  //  " y terminaba el día " + recepie.FechaFin, GetUserEmail(recepie.Paciente));
            }

            Session.GettingData = false;
            return qrr > 0;
        }

        public bool AddRecepie(string patient, string medic, string medicament, string FIni, string FEnd, string Amm,List<string> Time)
        {
            Session.GettingData = true;
            string fInicFormat = DateTime.Parse(FIni).ToString("yyyy-MM-dd");
            string fEndFormat = DateTime.Parse(FEnd).ToString("yyyy-MM-dd");
            string sqlCheck = "select * from Recetas where Paciente like '" + patient +
                "' and ID_Medicamento = (select ID from Medicamentos where Nombre like '" + medicament + "') and FechaFin >= '" + fInicFormat + "'";
            MySqlCommand comCheck = new MySqlCommand(sqlCheck, conexion);
            MySqlDataReader rows = comCheck.ExecuteReader();

            if (!rows.HasRows)
            {
                rows.Close();
                string sql = "insert into Recetas (Paciente,Medico,FechaInic,FechaFin,ID_Medicamento,Dosis) values ('" + patient + "','" + medic + "','" + fInicFormat +
                    "','" + fEndFormat + "', (select ID from Medicamentos where Nombre like '" + medicament + "')," + Amm + ")";
                MySqlCommand com = new MySqlCommand(sql, conexion);
                int qr = com.ExecuteNonQuery();

                if (qr > 0)
                {
                    int ID = getRecepieID(patient, Session.Account, medicament, fInicFormat, fEndFormat);
                    string hours = string.Empty;
                    foreach (string tmp in Time)
                    {
                        hours += "[**]" + tmp;
                        InsertHour(ID, tmp.Split(':')[0], tmp.Split(':')[1]);
                    }
                    string msg = "Se ha añadido una nueva receta para usted.[**]-Medicamento: " + medicament +
                        "[**]-Dosis: " + Amm + "[**]-Fecha de inicio: " + FIni + "[**]-Fecha fin: " + FEnd + "[**]-Horario de tomas diarias:" + hours;

                    InsertMsg(patient, "Nueva receta", msg);
                    //Session.SendEmail("Receta", msg.Replace("[**]", "\r\n"), GetUserEmail(patient));
                    Session.GettingData = false;
                    return true;
                }
                else
                {
                    Session.GettingData = false;
                    return false;
                }
            
            }
            else
            {
                rows.Close();
                Session.GettingData = false;
                throw new Exception("Ya existe una receta activa para ese usuario con el medicamento indicado en la fecha de inicio asignada");
            }

        }

        public int getRecepieID(string patient,string medic,string medicament,string FIni,string FEnd)
        {
            string sqlCheck = "select ID from Recetas where Paciente like '" + patient +
                "' and ID_Medicamento = (select ID from Medicamentos where Nombre like '" + medicament + "') and FechaInic = '" + FIni
                + "' and FechaFin = '" + FEnd + "'";
            MySqlCommand comCheck = new MySqlCommand(sqlCheck, conexion);
            MySqlDataReader rows = comCheck.ExecuteReader();
            if (rows.Read())
            {
                int Id = int.Parse(rows["ID"].ToString());
                rows.Close();
                return Id;
            }
            return 0;

        }

        public void InsertHour(int ID,string hour,string min)
        {
            string sql = "insert into Horas values (" + ID + ",'"+ hour+"','" + min +"')";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
        }

        public void DeletetHour(int ID, string hour, string min)
        {
            string sql = "delete from Horas where ID_Receta = " + ID + " and Hora = " + hour + " and Minuto = " + min;
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            int qr = cmd.ExecuteNonQuery();
        }

        public void DeleteOldControl(int ID, string hour, string min)
        {
            string sql = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha > '" + DateTime.Now.ToString("yyyy-MM-dd")+ "' and Hora = " + hour;
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.ExecuteNonQuery();

            string sql2 = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                "' and Hora = " + hour + " and Hora > " + DateTime.Now.TimeOfDay.Hours;// + " and Minuto > " + DateTime.Now.TimeOfDay.Minutes;
            MySqlCommand cmd2 = new MySqlCommand(sql2, conexion);
            cmd2.ExecuteNonQuery();

            string sql3 = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                "' and Hora = " + hour + " and Hora = " + DateTime.Now.TimeOfDay.Hours + " and Minuto > " + DateTime.Now.TimeOfDay.Minutes;
            MySqlCommand cmd3 = new MySqlCommand(sql3, conexion);
            cmd3.ExecuteNonQuery();

        }

        public void DeleteNewControl(int ID, string hour, string min)
        {
            string sql = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha < '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.ExecuteNonQuery();

            string sql2 = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                "' and Hora < " + DateTime.Now.TimeOfDay.Hours;
            MySqlCommand cmd2 = new MySqlCommand(sql2, conexion);
            cmd2.ExecuteNonQuery();

            string sql3 = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                "' and Hora = " + DateTime.Now.TimeOfDay.Hours + " and Minuto < " + DateTime.Now.TimeOfDay.Minutes;
            MySqlCommand cmd3 = new MySqlCommand(sql3, conexion);
            cmd2.ExecuteNonQuery();
        }

        public void ControlTableSincronization(int ID, string EndDate, bool isBigger, List<string> hours)
        {
            if (isBigger)
            {
                DateTime endDateTime = DateTime.Parse(EndDate);
                DateTime DateData;
                foreach (string time in hours)
                {
                    DateData = DateTime.Now;
                    while (DateData <= endDateTime)
                    {
                        try
                        {
                            string sql = "insert into Rec_Control where values (" + ID + ", '" + DateData.ToString("yyyy-MM-dd") + "'," + time.Split(':')[0] + ", " + time.Split(':')[1] + ", 0)";
                            MySqlCommand cmd = new MySqlCommand(sql, conexion);
                            cmd.ExecuteNonQuery();
                        }
                        catch(Exception e) { }
                        DateData = DateData.AddDays(1);
                    }
                }
            }
            else
            {
                string sql = "delete from Rec_Control where ID_Receta = " + ID + " and Fecha > '" + DateTime.Parse(EndDate).ToString("yyyy-MM-dd") + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
            }
        }

        public bool ModRecepie(int RecId,string patient, string medicament, string FIni, string FEnd, string oldEndDate, string Amm, List<string> newTime, List<string> delTime, List<string> totalTime, List<string> stayTime)
        {
            Session.GettingData = true;
            string fInicFormat = DateTime.Parse(FIni).ToString("yyyy-MM-dd");
            string fEndFormat = DateTime.Parse(FEnd).ToString("yyyy-MM-dd");
            string sqlCheck = "select * from Recetas where ID <> " + RecId  + " and Paciente like '" + patient +
                "' and ID_Medicamento = (select ID from Medicamentos where Nombre like '" + medicament + "') and FechaInic <= '" + fEndFormat + "'";
            MySqlCommand comCheck = new MySqlCommand(sqlCheck, conexion);
            MySqlDataReader rows = comCheck.ExecuteReader();
            if (!rows.HasRows)
            {
                rows.Close();
                string sql = "update Recetas set FechaInic = '" + fInicFormat + "' , FechaFin = '" + fEndFormat + "' , ID_Medicamento = (select ID from Medicamentos where Nombre like '"
                + medicament + "'), Dosis = " + Amm + " where ID = " + RecId;
                MySqlCommand com = new MySqlCommand(sql, conexion);
                int qr = com.ExecuteNonQuery();

                if (qr > 0)
                {
                    foreach (string tmp in delTime)
                    {
                        DeletetHour(RecId, tmp.Split(':')[0], tmp.Split(':')[1]);
                        DeleteOldControl(RecId, tmp.Split(':')[0], tmp.Split(':')[1]);
                    }

                    foreach (string tmp in newTime)
                    {
                        InsertHour(RecId, tmp.Split(':')[0], tmp.Split(':')[1]);
                        DeleteNewControl(RecId, tmp.Split(':')[0], tmp.Split(':')[1]);
                    }

                    if(DateTime.Parse(FEnd) > DateTime.Parse(oldEndDate))
                    {
                        ControlTableSincronization(RecId,FEnd,true,stayTime);
                    }
                    else if (DateTime.Parse(FEnd) < DateTime.Parse(oldEndDate))
                    {
                        ControlTableSincronization(RecId, FEnd, false, null);
                    }


                    string hours = string.Empty;
                    foreach (string tmp in totalTime)
                    {
                        hours += "[**]" + tmp;
                    }
                    string msg = "Se ha modificado una receta suya. [**]Datos nuevos:[**]-Medicamento: " + medicament +
                        "[**]-Dosis: " + Amm + "[**]-Fecha de inicio: " + FIni + "[**]-Fecha fin: " + FEnd + "[**]-Horario de tomas diarias:" + hours;

                    InsertMsg(patient, "Modificación de receta", msg);
                    Session.GettingData = false;
                    //Session.SendEmail("Modificación de receta", msg.Replace("[**]", "\r\n"), GetUserEmail(patient));
                    return true;
                }
                else
                {
                    Session.GettingData = false;
                    return false;
                }
            }
            else
            {
                rows.Close();
                Session.GettingData = false;
                throw new Exception("Ya existe una receta activa para ese usuario con el medicamento indicado en la fecha de inicio asignada");
            }
        }

        #endregion
    }
}
