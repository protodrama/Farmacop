using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacop
{
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

        public void GetData()
        {
            try
            {
                Sesion.ReceivedMessages = Sesion.DBConnection.GetAllReceivedMessages(Sesion.Account);
                Sesion.SendedMessages = Sesion.DBConnection.GetAllSendedMessages(Sesion.Account);
                if (ShowingReceibedMessages)
                {
                    if (ShowingReadedMessages)
                    {
                        lblInfo.Text = "Mostrando mensajes recibidos y leídos";
                        ReceivedReadedMessages = new List<Message>();
                        foreach (Message tmp in Sesion.ReceivedMessages)
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
                        foreach (Message tmp in Sesion.ReceivedMessages)
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
                    MessGridView.DataSource = Sesion.SendedMessages;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los mensajes. Consulte al administrador.\n " + e.Message);
            }
            MessGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            MessGridView.EnableHeadersVisualStyles = false;
        }

        public void SetTableSize()
        {
            int size = 0;
            foreach(DataGridViewColumn tmp in MessGridView.Columns)
            {
                tmp.Width *= 2;
                size += tmp.Width;
            }
            MessGridView.Width = size + 3;
            MessGridView.Left = this.Width / 2 - MessGridView.Width / 2;
        }

        private void chbxSended_CheckedChanged(object sender, EventArgs e)
        {
            ShowingReceibedMessages = !ShowingReceibedMessages;
            chbxReaded.Enabled = ShowingReceibedMessages;
            GetData();
        }

        private void chbxReaded_CheckedChanged(object sender, EventArgs e)
        {
            ShowingReadedMessages = !ShowingReadedMessages;
            GetData();
        }

        private void MessGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ShowingReceibedMessages)
            {
                if (ShowingReadedMessages)
                    new MessageForm(ReceivedReadedMessages[e.RowIndex], false).ShowDialog();
                else
                {
                    Sesion.DBConnection.SetReaded(ReceivedNonReadedMessages[e.RowIndex].Id());
                    new MessageForm(ReceivedNonReadedMessages[e.RowIndex], false).ShowDialog();
                }
            }
            else
                new MessageForm(Sesion.SendedMessages[e.RowIndex], true).ShowDialog();
            GetData();
        }

        private void btnNewMsg_Click(object sender, EventArgs e)
        {
            new NewMsgForm().ShowDialog();
            GetData();
        }
    }
}
