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

        DataGridViewButtonColumn BtnDisableColumn;
        DataGridViewButtonColumn BtnModifyColumn;
        DataGridViewButtonColumn BtnEnableColumn;

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
            try
            {
                Sesion.UserList = Sesion.DBConnection.GetAllUsersData();
                ActiveUsers = new List<User>();
                NonActiveUsers = new List<User>();
                foreach (User us in Sesion.UserList)
                    if (us.IsEnabled())
                        ActiveUsers.Add(us);
                    else
                        NonActiveUsers.Add(us);
                if (UsingActiveUsers)
                    UsersGridView.DataSource = ActiveUsers;
                else
                    UsersGridView.DataSource = NonActiveUsers;
                UsersGridView.Columns[2].Width = 150;
                UsersGridView.Columns[1].Width = 150;
                PutColumns();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los usuarios. Consulte al administrador");
            }
            UsersGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            UsersGridView.EnableHeadersVisualStyles = false;
        }

        public void PutColumns()
        {

            try
            {
                UsersGridView.Columns.Remove(BtnModifyColumn);
            }
            catch { }
            try
            {
                UsersGridView.Columns.Remove(BtnDisableColumn);
            }
            catch { }
            try
            {
                UsersGridView.Columns.Remove(BtnEnableColumn);
            }
            catch { }


            BtnModifyColumn = new DataGridViewButtonColumn()
            {
                Name = "Modify",
                Width = 80,
                HeaderText = "Modificar",
                Text = "Modificar",
                UseColumnTextForButtonValue = true
            };
            UsersGridView.Columns.Add(BtnModifyColumn);

            if (UsingActiveUsers)
            {
                BtnDisableColumn = new DataGridViewButtonColumn()
                {
                    Name = "Disable",
                    Width = 80,
                    HeaderText = "Deshabilitar",
                    Text = "Deshabilitar",
                    UseColumnTextForButtonValue = true
                };
                UsersGridView.Columns.Add(BtnDisableColumn);
            }
            else
            {
                BtnEnableColumn = new DataGridViewButtonColumn()
                {
                    Name = "Enable",
                    Width = 80,
                    HeaderText = "Habilitar",
                    Text = "Habilitar",
                    UseColumnTextForButtonValue = true
                };
                UsersGridView.Columns.Add(BtnEnableColumn);
            }
            UsersGridView.Left = (this.Width / 2) - (UsersGridView.Width / 2);
        }

        private void UsersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    ModifyForm = new ModifyUserForm(UserTemp);
                    ModifyForm.ShowDialog();
                    GetData();
                }
                else
                {
                    if (UsersGridView.Columns[e.ColumnIndex].Name.Equals("Disable"))
                    {
                        if (DialogResult.Yes == MessageBox.Show("¿Deseas deshabilitar el usuario " + UserTemp.Nombre + " " + UserTemp.Apellidos + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            if (Sesion.DBConnection.DisableUser(UserTemp.Cuenta))
                            {
                                GetData();
                            }
                        }
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("¿Deseas habilitar el usuario " + UserTemp.Nombre + " " + UserTemp.Apellidos + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            if (Sesion.DBConnection.EnableUser(UserTemp.Cuenta))
                            {
                                GetData();
                            }
                        }
                    }

                }



                
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<User> FilteredUsers = new List<User>();
            if (UsingActiveUsers)
            {
                foreach(User Temp in ActiveUsers)
                {
                    if(Temp.Nombre.ToLower().Contains(txtbxName.Text.ToLower()) && Temp.Cuenta.ToLower().Contains(txtbxAccount.Text.ToLower()) && Temp.Apellidos.ToLower().Contains(txtbxApl.Text.ToLower()))
                    {
                        FilteredUsers.Add(Temp);
                    }
                }
            }
            else
            {
                foreach (User Temp in NonActiveUsers)
                {
                    if (Temp.Nombre.ToLower().Contains(txtbxName.Text.ToLower()) && Temp.Cuenta.ToLower().Contains(txtbxAccount.Text.ToLower()) && Temp.Apellidos.ToLower().Contains(txtbxApl.Text.ToLower()))
                    {
                        FilteredUsers.Add(Temp);
                    }
                }
            }
            UsersGridView.DataSource = FilteredUsers;
        }

        private void chbxDisUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxDisUsers.Checked)
            {
                UsingActiveUsers = false;
            }
            else
            {
                UsingActiveUsers = true;
            }
            GetData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new AddUserForm().ShowDialog();
            GetData();
        }
    }
}

