using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Threading;

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
        string GetAllUsersDataURL = "https://jfrodriguez.pw/slimrest/api/getAllUsersData"; 
        string DisableUserURL = "https://jfrodriguez.pw/slimrest/api/disableUser";
        string EnableUserURL = "https://jfrodriguez.pw/slimrest/api/enableUser";
        string AddNewUserURL = "https://jfrodriguez.pw/slimrest/api/AddUser";
        string AddAlgURL = "https://jfrodriguez.pw/slimrest/api/AddAlg";
        string GetUserAlgURL = "https://jfrodriguez.pw/slimrest/api/GetUserAlg";
        string UpdateAUserURL = "https://jfrodriguez.pw/slimrest/api/UpdateAUser";
        string DeleteAlgURL = "https://jfrodriguez.pw/slimrest/api/DeleteAlg";
        string GetAllPrescriptionsURL = "https://jfrodriguez.pw/slimrest/api/GetAllPrescriptions";
        string GetPrescriptionControlsURL = "https://jfrodriguez.pw/slimrest/api/GetControlFromPrescription";
        string CheckBeforeInsertPrescriptionURL = "https://jfrodriguez.pw/slimrest/api/CheckBeforeInserPresc";
        string AddPrescriptionURL = "https://jfrodriguez.pw/slimrest/api/AddPrescription";
        string AddTimeURL = "https://jfrodriguez.pw/slimrest/api/AddPrescTime"; 
        string GetPrescriptionIDURL = "https://jfrodriguez.pw/slimrest/api/GetPrescriptionID"; 
        string DeletePrescriptionURL = "https://jfrodriguez.pw/slimrest/api/DeletePrescription";
        string DeleteTimeURL = "https://jfrodriguez.pw/slimrest/api/DeleteTime";
        string GetPrescTimeURL = "https://jfrodriguez.pw/slimrest/api/GetPrescriptionsTimetable";
        string UpdatePrescriptionURL = "https://jfrodriguez.pw/slimrest/api/UpdatePrescription"; 
        string SendEmailURL = "https://jfrodriguez.pw/slimrest/api/SendEmail";

        string defApikey = "eadmghacdg";

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
                throw new Exception("Error obteniendo los datos del usuario");
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
                throw new Exception("Error obteniendo los datos usuarios inactivos");
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
                throw new Exception("Error al actualizar la contraseña");
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
                throw new Exception("Error al actualizar usuario");
            }
        }

        //Actualiza los datos de un usuario
        public bool UpdateModUserData(string Name, string FApl, string SApl, string FNac,string Type, string account,string email)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("theaccount",account));
                postData.Add(new KeyValuePair<string, string>("fnac", FNac));
                postData.Add(new KeyValuePair<string, string>("fsur", FApl));
                postData.Add(new KeyValuePair<string, string>("ssur", SApl));
                postData.Add(new KeyValuePair<string, string>("name", Name));
                postData.Add(new KeyValuePair<string, string>("email", email));
                postData.Add(new KeyValuePair<string, string>("type", Type));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(UpdateAUserURL, content).Result;
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
                throw new Exception("Error al actualizar usuario");
            }
        }

        //Agregar un usuario
        public bool InsertUserData(string Name, string FApl, string SApl, string FNac, string Type, string account,string email)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("newaccount", account));
                postData.Add(new KeyValuePair<string, string>("fsur", FApl));
                postData.Add(new KeyValuePair<string, string>("ssur", SApl));
                postData.Add(new KeyValuePair<string, string>("fnac", FNac));
                postData.Add(new KeyValuePair<string, string>("type", Type));
                postData.Add(new KeyValuePair<string, string>("email", email));
                postData.Add(new KeyValuePair<string, string>("pass", Session.StringToMD5(account+"NEWUSER"+DateTime.Now.ToShortDateString())));
                postData.Add(new KeyValuePair<string, string>("name", Name));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PostAsync(AddNewUserURL, content).Result;
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
                throw new Exception("Error al añadir el nuevo usuario");
            }
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
        public string GetAllUsersData()
        {
            Session.GettingData = true;
            try
            {
                string usertype = "";
                if (Session.UserType == UserType.Admin)
                    usertype = "Admin";
                else
                    usertype = "Medico";
                var builder = new UriBuilder(GetAllUsersDataURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["type"] = usertype;
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

        //Disables User
        public bool DisableUser(string account)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("todisable", account));
                
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(DisableUserURL, content).Result;
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
                throw new Exception("Error al deshabilitar usuario");
            }
        }

        //Enables User
        public bool EnableUser(string account)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("toenable", account));

                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(EnableUserURL, content).Result;
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
                throw new Exception("Error al habilitar usuario");
            }
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
                throw new Exception("Error obteniendo los medicamentos");
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
                throw new Exception("Error al eliminar el medicamento");
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
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("theaccount", account));
                postData.Add(new KeyValuePair<string, string>("med", medicament));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PostAsync(AddAlgURL, content).Result;
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
                throw new Exception("Error al añadir la alergia");
            }
        }

        //Eliminar alergia para un usuario
        public bool DeleteAlg(string account, string medicament)
        {

            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(DeleteAlgURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["theaccount"] = account;
                query["med"] = medicament;
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
                throw new Exception("Error al eliminar alergia");
            }
        }

        //Obtiene las alergias de un usuario
        public string GetUserAlg(string account)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetUserAlgURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["theaccount"] = account;
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
                throw new Exception("Error al obtener las alergias del usuario");
            }

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
                throw new Exception("Error al actualizar el estado del mensaje");
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
                throw new Exception("Error al insertar mensaje");
            }
        }

        //Enviar un mensaje por correo electrónico
        public void SendEmailToUser(string subject, string message, string patient)
        {
            Session.GettingData = true;
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("apikey", defApikey));
                postData.Add(new KeyValuePair<string, string>("for", patient));
                postData.Add(new KeyValuePair<string, string>("subject", subject));
                postData.Add(new KeyValuePair<string, string>("message", message));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(SendEmailURL, content).Result;
                    Session.GettingData = false;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al enviar mensaje");
            }

        }

        #endregion

        #region Recetas
        public string GetAllPrescriptions()
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetAllPrescriptionsURL);
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
                throw new Exception("Error obteniendo las recetas");
            }
        }

        public string GetAllRecControl(int idRec)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetPrescriptionControlsURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["id"] = "" + idRec;
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
                throw new Exception("Error obteniendo las tomas de la receta");
            }
        }

        public string GetAllHours(int idRec)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(GetPrescTimeURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["id"] = "" + idRec;
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
                throw new Exception("Error obteniendo las horas de la receta");
            }
        }

        public bool DeleteRecepie(Prescription thepresct)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(DeletePrescriptionURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["id"] = "" + thepresct.getId();
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
                            InsertMsg(thepresct.Paciente, "Eliminacion de receta", "Se ha eliminaro su receta con el medicamento " + thepresct.Medicamento + " que comenzaba el día " + thepresct.FechaInicio +
                                " y terminaba el día " + thepresct.FechaFin);
                            SendEmailToUser("Eliminacion de receta", "Se ha eliminaro su receta con el medicamento " + thepresct.Medicamento + " que comenzaba el día " + thepresct.FechaInicio +
                                        " y terminaba el día " + thepresct.FechaFin, thepresct.Paciente);
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
                throw new Exception("Error al eliminar la receta");
            }               
        }

        public string CheckBeforeAddPresciption(string patient, string medicament, string FInic)
        {
            try
            {
                var builder = new UriBuilder(CheckBeforeInsertPrescriptionURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["patient"] = patient;
                query["med"] = medicament;
                query["fstart"] = FInic;
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

        public bool AddRecepie(string patient, string medic, string medicament, string FIni, string FEnd, string Amm, List<string> Time)
        {
            Session.GettingData = true;
            try
            {
                string fstartformated = DateTime.Parse(FIni).ToString("yyyy-MM-dd");
                string fendformated = DateTime.Parse(FEnd).ToString("yyyy-MM-dd");
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("patient", patient));
                postData.Add(new KeyValuePair<string, string>("medic", medic));
                postData.Add(new KeyValuePair<string, string>("med", medicament));
                postData.Add(new KeyValuePair<string, string>("finic", fstartformated));
                postData.Add(new KeyValuePair<string, string>("fend", fendformated));
                postData.Add(new KeyValuePair<string, string>("Amm", Amm));            
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PostAsync(AddPrescriptionURL, content).Result;
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string hours = string.Empty;
                        int ID = getPrescriptionID(patient, medic, medicament, fstartformated, fendformated);
                        foreach (string tmp in Time)
                        {
                            hours += "[**]" + tmp;
                            InsertHour(ID, tmp.Split(':')[0], tmp.Split(':')[1]);
                        }
                        string msg = "Se ha añadido una nueva receta para usted.[**]-Medicamento: " + medicament +
                            "[**]-Dosis: " + Amm + "[**]-Fecha de inicio: " + FIni + "[**]-Fecha fin: " + FEnd + "[**]-Horario de tomas diarias:" + hours;

                        InsertMsg(patient, "Nueva receta", msg);
                        SendEmailToUser("Receta", msg.Replace("[**]", "\r\n"), patient);
                        Session.GettingData = false;
                        return true;
                    }
                    else
                    {
                        Session.GettingData = false;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.GettingData = false;
                throw new Exception("Error al añadir la nueva receta");
            }
        }

        public int getPrescriptionID(string patient,string medic,string medicament,string FIni,string FEnd)
        {
            try
            {
                var builder = new UriBuilder(GetPrescriptionIDURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["patient"] = patient;
                query["medic"] = medic;
                query["med"] = medicament;
                query["finic"] = FIni;
                query["fend"] = FEnd;
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
                                JObject jobject = JObject.Parse(result);
                                JToken jdata = jobject["data"];
                                int temp = int.Parse(jdata[0]["ID"].ToString());
                                return temp;
                            }
                        }
                        else
                        {
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

        public void InsertHour(int ID, string hour, string min)
        {
            Session.GettingData = true;

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("account", Session.Account));
            postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
            postData.Add(new KeyValuePair<string, string>("idpresc", "" + ID));
            postData.Add(new KeyValuePair<string, string>("hour", hour));
            postData.Add(new KeyValuePair<string, string>("min", min));
            HttpContent content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 10);
            using (client)
            {
                HttpResponseMessage response = client.PostAsync(AddTimeURL, content).Result;
                Session.GettingData = false;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }

        }

        public bool DeletetHour(int ID, string hour, string min)
        {
            Session.GettingData = true;
            try
            {
                var builder = new UriBuilder(DeleteTimeURL);
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["account"] = Session.Account;
                query["apikey"] = Session.Apikey;
                query["id"] = "" + ID;
                query["hour"] = hour;
                query["minute"] = min;
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
                throw new Exception("Error al eliminar hora");
            }
        }  

        public bool ModRecepie(int RecId, string patient, string medicament, string FIni, string FEnd, string Amm, List<string> newTime, List<string> delTime, List<string> totalTime)
        {
            Session.GettingData = true;
            
            try
            {
                foreach (string tmp in delTime)
                {
                    DeletetHour(RecId, tmp.Split(':')[0], tmp.Split(':')[1]);
                    Thread.Sleep(200);
                }

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("account", Session.Account));
                postData.Add(new KeyValuePair<string, string>("apikey", Session.Apikey));
                postData.Add(new KeyValuePair<string, string>("finic", FIni));
                postData.Add(new KeyValuePair<string, string>("fend", FEnd));
                postData.Add(new KeyValuePair<string, string>("am", Amm));
                postData.Add(new KeyValuePair<string, string>("id", "" + RecId));
                HttpContent content = new FormUrlEncodedContent(postData);
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 10);
                using (client)
                {
                    HttpResponseMessage response = client.PutAsync(UpdatePrescriptionURL, content).Result;
                    Session.GettingData = false;
                    if (response.IsSuccessStatusCode)
                    {

                        string hours = string.Empty;
                        foreach (string tmp in totalTime)
                        {
                            hours += "[**]" + tmp;
                        }
                        string msg = "Se ha modificado una receta suya. [**]Datos nuevos:[**]-Medicamento: " + medicament +
                            "[**]-Dosis: " + Amm + "[**]-Fecha de inicio: " + FIni + "[**]-Fecha fin: " + FEnd + "[**]-Horario de tomas diarias:" + hours;

                        InsertMsg(patient, "Modificación de receta", msg);
                        SendEmailToUser("Modificación de receta", msg.Replace("[**]", "\r\n"), patient);
                        foreach (string tmp in newTime)
                        {
                            InsertHour(RecId, tmp.Split(':')[0], tmp.Split(':')[1]);
                            Thread.Sleep(200);
                        }
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
                throw new Exception("Error al actualizar la receta");
            }
        }

        #endregion
    }
}
