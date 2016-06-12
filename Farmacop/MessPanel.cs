using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Farmacop
{
    //Control que contiene todo lo referido a mensajes en el entorno
    public partial class MessPanel : UserControl
    {
        List<Message> ReceivedReadedMessages;
        List<Message> ReceivedNonReadedMessages;
        bool ShowingReadedMessages;
        bool ShowingReceibedMessages;

        public MessPanel()
        {
            InitializeComponent();
            ShowingReadedMessages = false;
            ShowingReceibedMessages = true;
            GetData();
            SetTableSize();
        }

        //Obtiene los mensajes desde el servidor
        public void GetData()
        {
            try
            {
                if (!txtSender.Text.Trim().Equals("") || !txtReader.Text.Trim().Equals(""))
                    FilterMessages();
                else
                    GetAll();
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los mensajes. Consulte al administrador.\n " + e.Message);
            }
            MessGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            MessGridView.EnableHeadersVisualStyles = false;
            
        }

        //Lee los datos de los mensajes recibidos desde el servidor
        public List<Message> GetMessages(string data)
        {
            List<Message> messagesList = new List<Message>();
            JObject jsonobject = JObject.Parse(data);
            JToken jsondata = jsonobject["data"];

            for(int i = 0; i < jsondata.Count<JToken>(); i++)
            {
                JToken temp = jsondata[i];
                Message mtemp = new Message(int.Parse(temp["ID"].ToString()), temp["emisor"].ToString(),
                    temp["receptor"].ToString(), temp["Asunto"].ToString(), (temp["Mensaje"].ToString()).Replace("[**]","\r\n"), int.Parse(temp["Leido"].ToString()) == 1);
                messagesList.Add(mtemp);
            }
            return messagesList;
        }

        //Agrega columnas extra para la manipulación de los datos de la tabla de mensajes
        public void SetTableSize()
        {
            int size = 0;
            foreach(DataGridViewColumn tmp in MessGridView.Columns)
            {
                tmp.Width *= 2;
                size += tmp.Width;
            }
            MessGridView.Width = size + 15;
            MessGridView.Left = this.Width / 2 - MessGridView.Width / 2;
        }

        //Cambia la lista de mensajes mostrados
        private void chbxSended_CheckedChanged(object sender, EventArgs e)
        {
            ShowingReceibedMessages = !ShowingReceibedMessages;
            chbxReaded.Enabled = ShowingReceibedMessages;
            GetData();
        }

        //Cambia la lista de mensajes mostrados
        private void chbxReaded_CheckedChanged(object sender, EventArgs e)
        {
            ShowingReadedMessages = !ShowingReadedMessages;
            GetData();
        }

        //Controla la pulsación sobre los mensajes 
        private void MessGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ShowingReceibedMessages)
            {
                if (ShowingReadedMessages)
                    new MessageForm(ReceivedReadedMessages[e.RowIndex], false).ShowDialog();
                else
                {
                    if (e.RowIndex >= 0)
                    {
                        Session.DBConnection.SetReaded(ReceivedNonReadedMessages[e.RowIndex].Id());
                        new MessageForm(ReceivedNonReadedMessages[e.RowIndex], false).ShowDialog();
                    }
                }
            }
            else
                new MessageForm(Session.SendedMessages[e.RowIndex], true).ShowDialog();
            GetData();
        }

        //Abre el formulario para agregar un mensaje nuevo
        private void btnNewMsg_Click(object sender, EventArgs e)
        {
            new NewMsgForm().ShowDialog();
            GetData();
        }

        //Comprueba los datos indroducidos antes de filtrar los mensajes
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(!txtSender.Text.Trim().Equals("") || !txtReader.Text.Trim().Equals(""))
                FilterMessages();
        }
        
        //Filtra los mensajes que se muestran en ese momento
        public void FilterMessages()
        {
            try
            {
                Session.ReceivedMessages = GetMessages(Session.DBConnection.GetAllReceivedMessages());
                Session.SendedMessages = GetMessages(Session.DBConnection.GetAllSendedMessages());
                if (ShowingReceibedMessages)
                {
                    if (ShowingReadedMessages)
                    {
                        lblInfo.Text = "Mostrando mensajes recibidos leídos";
                        ReceivedReadedMessages = new List<Message>();
                        foreach (Message tmp in Session.ReceivedMessages)
                        {
                            if (tmp.IsReaded() && tmp.Emisor.ToLower().Contains(txtSender.Text.ToLower()) && tmp.Receptor.ToLower().Contains(txtReader.Text.ToLower()))
                                ReceivedReadedMessages.Add(tmp);
                        }
                        MessGridView.DataSource = ReceivedReadedMessages;
                    }
                    else
                    {
                        lblInfo.Text = "Mostrando mensajes recibidos";
                        ReceivedNonReadedMessages = new List<Message>();
                        foreach (Message tmp in Session.ReceivedMessages)
                        {
                            if (!tmp.IsReaded() && tmp.Emisor.ToLower().Contains(txtSender.Text.ToLower()) && tmp.Receptor.ToLower().Contains(txtReader.Text.ToLower()))
                                ReceivedNonReadedMessages.Add(tmp);
                        }
                        MessGridView.DataSource = ReceivedNonReadedMessages;
                    }
                }
                else
                {
                    lblInfo.Text = "Mostrando mensajes enviados";
                    List<Message> filtered = new List<Message>();
                    foreach (Message tmp in Session.SendedMessages)
                    {
                        if (tmp.Emisor.ToLower().Contains(txtSender.Text.ToLower()) && tmp.Receptor.ToLower().Contains(txtReader.Text.ToLower()))
                            filtered.Add(tmp);
                    }
                    MessGridView.DataSource = filtered;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los mensajes. Consulte al administrador.\n " + ex.Message);
            }
            MessGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            MessGridView.EnableHeadersVisualStyles = false;
        }

        //Obtiene todos los mensajes en los que participe el usuario de la sesión
        public void GetAll()
        {
            Session.ReceivedMessages = GetMessages(Session.DBConnection.GetAllReceivedMessages());
            Session.SendedMessages = GetMessages(Session.DBConnection.GetAllSendedMessages());
            if (ShowingReceibedMessages)
            {
                if (ShowingReadedMessages)
                {
                    lblInfo.Text = "Mostrando mensajes recibidos leídos";
                    ReceivedReadedMessages = new List<Message>();
                    foreach (Message tmp in Session.ReceivedMessages)
                    {
                        if (tmp.IsReaded())
                            ReceivedReadedMessages.Add(tmp);
                    }
                    MessGridView.DataSource = ReceivedReadedMessages;
                }
                else
                {
                    lblInfo.Text = "Mostrando mensajes recibidos";
                    ReceivedNonReadedMessages = new List<Message>();
                    foreach (Message tmp in Session.ReceivedMessages)
                    {
                        if (!tmp.IsReaded())
                            ReceivedNonReadedMessages.Add(tmp);
                    }
                    MessGridView.DataSource = ReceivedNonReadedMessages;
                }
            }
            else
            {
                lblInfo.Text = "Mostrando mensajes enviados";
                MessGridView.DataSource = Session.SendedMessages;
            }
        }

        //Limpia el filtro de mensajes
        private void btnClean_Click(object sender, EventArgs e)
        {
            txtSender.Text = "";
            txtReader.Text = "";
            GetData();
        }
    }
}
