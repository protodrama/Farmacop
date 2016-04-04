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
    public partial class UsersPanel : UserControl
    {
        DataGridViewButtonColumn BtnDeleteColumn;
        DataGridViewButtonColumn BtnModifyColumn;
        public UsersPanel()
        {
            InitializeComponent();
            GetData();
            Center();
        }

        public void Center()
        {
            foreach(Control c in this.Controls){
                c.Left = this.Width / 2 - c.Width / 2;
            }
        }

        public void GetData()
        {
            Sesion.UserList = Sesion.DBConnection.GetAllUsersData();
            UsersGridView.DataSource = Sesion.UserList;
            UsersGridView.Columns[2].Width = 150;
            UsersGridView.Columns[1].Width = 150;

            BtnModifyColumn = new DataGridViewButtonColumn()
            {
                Name = "Modify",
                Width = 80,
                HeaderText = "Modificar",
                Text = "Modificar",
                UseColumnTextForButtonValue = true
            };
            UsersGridView.Columns.Add(BtnModifyColumn);
            UsersGridView.Width += BtnModifyColumn.Width;
            UsersGridView.Left = (this.Width / 2) - (UsersGridView.Width / 2);

            if (Sesion.UserType == UserType.Administrador)
            {
                BtnDeleteColumn = new DataGridViewButtonColumn()
                {
                    Name = "Delete",
                    Width = 80,
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                UsersGridView.Columns.Add(BtnDeleteColumn);
                UsersGridView.Width += BtnDeleteColumn.Width;
                UsersGridView.Left = (this.Width / 2) - (UsersGridView.Width / 2);
            }
            UsersGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            UsersGridView.EnableHeadersVisualStyles = false;

        }
    }
}
