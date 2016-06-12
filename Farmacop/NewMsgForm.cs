using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
    //Formulario utilizado para mandar mensajes internos a cualquier usuario del entorno
    public partial class NewMsgForm : Form
    {
        List<string> Accounts;

        //Constructor general del formulario
        public NewMsgForm()
        {
            InitializeComponent();
            try
            {
                Accounts = ReadData(Session.DBConnection.GetAllUsersNameAccount());
                var source = new AutoCompleteStringCollection();
                source.AddRange(Accounts.ToArray());
                txtReceiver.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtReceiver.AutoCompleteCustomSource = source;
                txtReceiver.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los usuarios. Consulte al administrador");
                this.Close();
            }
        }

        //Lee los datos de los nombres de cuenta recibidos desde el servidor
        public List<string> ReadData(string data)
        {
            List<string> userslist = new List<string>();
            JObject jsonobject = JObject.Parse(data);
            JToken jsondata = jsonobject["data"];

            for (int i = 0; i < jsondata.Count<JToken>(); i++)
            {
                JToken temp = jsondata[i];
                userslist.Add(temp["Cuenta"].ToString());
            }
            return userslist;
        }

        //Constructor utilizado para abrir el formulario y responder a un mensaje
        public NewMsgForm(string Sender,string matter)
        {
            InitializeComponent();
            txtReceiver.Text = Sender;
            txtReceiver.ReadOnly = true;
            txtMatter.Text = matter;
        }

        //Comprueba los datos introducidos y envía el mensaje
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (CheckAccount())
            {
                if (!txtMatter.Text.Trim().Equals("") && !txtMsg.Text.Trim().Equals("") && !txtReceiver.Text.Trim().Equals(""))
                {
                    try
                    {
                        if (Session.DBConnection.InsertMsg(txtReceiver.Text, txtMatter.Text, txtMsg.Text))
                        {
                            MessageBox.Show("Mensaje enviado con éxito.");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Error al enviar el mensaje");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al enviar el mensaje. Compruebe su conexión");
                    }
                }
                else
                    MessageBox.Show("Se deben rellenar todos los campos para enviar el mensaje");
            }
            else
                MessageBox.Show("El nombre de cuenta indicado no es correcto.");
        }

        //Cierra el formulario
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Lanza la comprobación del usuario
        private void txtReceiver_Leave(object sender, EventArgs e)
        {
            if (!CheckAccount())
            {
                MessageBox.Show("El nombre de cuenta indicado no es correcto.");
            }
        }
        
        //Comprueba el nombre del usuario destinatario
        private bool CheckAccount()
        {
            if (txtReceiver.Text.Equals(""))
                return true;
            if (Accounts != null)
            {
                if (!Accounts.Contains(txtReceiver.Text))
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
    }
}
