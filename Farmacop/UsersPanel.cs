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
        bool UsingActiveUsers = true;
        ModifyUserForm ModifyForm;
        List<User> ActiveUsers;
        List<User> NonActiveUsers;

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
            foreach (Control c in this.Controls)
            {
                c.Left = this.Width / 2 - c.Width / 2;
            }
        }

        public void GetData()
        {
            Sesion.UserList = Sesion.DBConnection.GetAllUsersData();
            ActiveUsers = new List<User>();
            NonActiveUsers = new List<User>();
            foreach (User us in Sesion.UserList)
                if (!us.IsEnabled())
                    ActiveUsers.Add(us);
                else
                    NonActiveUsers.Add(us);

            UsersGridView.DataSource = ActiveUsers;
            UsersGridView.Columns[2].Width = 150;
            UsersGridView.Columns[1].Width = 150;

            if (Sesion.UserType == UserType.Admin)
            {
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

                BtnDeleteColumn = new DataGridViewButtonColumn()
                {
                    Name = "Disable",
                    Width = 80,
                    HeaderText = "Deshabilitar",
                    Text = "Deshabilitar",
                    UseColumnTextForButtonValue = true
                };
                UsersGridView.Columns.Add(BtnDeleteColumn);
                UsersGridView.Width += BtnDeleteColumn.Width;

                UsersGridView.Left = (this.Width / 2) - (UsersGridView.Width / 2);
            }
            UsersGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            UsersGridView.EnableHeadersVisualStyles = false;

        }

        private void UsersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Sesion.UserType == UserType.Admin)
            {
                if (UsersGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    User UserTemp;
                    if (UsingActiveUsers)
                        UserTemp = ActiveUsers[e.RowIndex];
                    else
                        UserTemp = NonActiveUsers[e.RowIndex];
                    if (UsersGridView.Columns[e.ColumnIndex].Name.Equals("Modify"))
                    {
                        //Modificar
                        ModifyForm = new ModifyUserForm();
                        ModifyForm.ShowDialog();
                    }
                    else
                    {
                        //Habilitar
                        if (DialogResult.Yes == MessageBox.Show("¿Deseas deshabilitar el usuario?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            //Deshabilitar
                        }
                    }
                
                
                
            }
        }
    }
}

