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
    public partial class ModifyUserForm : Form
    {
        User UserToMod;
        MonthCalendar MyCalendar;
        List<string> algDeleted = new List<string>();

        public ModifyUserForm()
        {
            InitializeComponent();
        }

        public ModifyUserForm(User userToMod)
        {
            InitializeComponent();
            try
            {
                this.UserToMod = userToMod;
                txtName.Text = UserToMod.Nombre;
                txtFApl.Text = UserToMod.GetFApl();
                txtSApl.Text = UserToMod.GetSApl();
                txtFNac.Text = UserToMod.Nacimiento;
                if (UserToMod.Tipo.Equals("Admin"))
                    ComboboxType.SelectedItem = "Admin";
                if(UserToMod.Tipo.Equals("Medico"))
                    ComboboxType.SelectedItem = "Medico";
                if (UserToMod.Tipo.Equals("Paciente"))
                    ComboboxType.SelectedItem = "Paciente";
                UserToMod.Alergias = Sesion.DBConnection.GetUserAlg(UserToMod.Cuenta);
                AlgDataGrid.DataSource = UserToMod.GetAlgList();
                AlgDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                AlgDataGrid.EnableHeadersVisualStyles = false;
                DataGridViewButtonColumn BtnDeleteColumn = new DataGridViewButtonColumn()
                {
                    Name = "Delete",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                AlgDataGrid.Columns.Add(BtnDeleteColumn);
            }
            catch (Exception e) { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!txtName.Text.Trim().Equals("") && !txtFNac.Text.Trim().Equals("") && !txtFApl.Text.Trim().Equals("") && !txtSApl.Text.Trim().Equals(""))
            {
                if (Sesion.DBConnection.UpdateModUserData(txtName.Text, txtFApl.Text, txtSApl.Text, DateTime.Parse(txtFNac.Text).ToString("yyyy-MM-dd"), ComboboxType.SelectedItem.ToString(), UserToMod.Cuenta))
                {
                    if(algDeleted.Count > 0)
                    {
                        foreach (string alg in algDeleted)
                            Sesion.DBConnection.DeleteAlg(UserToMod.Cuenta, alg);
                    }
                    foreach (Control Ctemp in algContainer.Controls)
                    {
                        if (Ctemp is AlgControl)
                        {
                            if (((AlgControl)Ctemp).Text.Equals(""))
                                continue;
                            else
                                Sesion.DBConnection.InsertAlg(UserToMod.Cuenta, ((AlgControl)Ctemp).Text);
                        }
                    }
                    MessageBox.Show("Usuario modificado con éxito");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben tener un valor");
            }
            this.Close();
        }

        private void txtFNac_Click(object sender, EventArgs e)
        {
            MyCalendar = new MonthCalendar()
            {
                Left = 330,
                Top = 110
            };
            MyCalendar.MouseLeave += MyCalendar_MouseLeave;
            MyCalendar.DateSelected += MyCalendar_DateSelected;
            MyCalendar.Leave += MyCalendar_Leave;
            this.Controls.Add(MyCalendar);
            MyCalendar.BringToFront();
            MyCalendar.Focus();
            txtFNac.Enabled = false;
        }

        private void MyCalendar_Leave(object sender, EventArgs e)
        {
            this.Controls.Remove(MyCalendar);
            txtFNac.Enabled = true;
        }

        private void MyCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFNac.Enabled = true;
            txtFNac.Text = MyCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            try
            {
                DateTime Date = DateTime.Parse(txtFNac.Text);
                if (Date.Date > DateTime.Now.Date)
                    throw new Exception();
                else
                    if (DateTime.Now.Year - Date.Date.Year >= 200)
                    throw new Exception();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fecha fuera de rango (Fecha actual como máximo).", "Error");
                txtFNac.Text = UserToMod.Nacimiento;
            }
            this.Controls.Remove(MyCalendar);
        }

        private void MyCalendar_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(MyCalendar);
            txtFNac.Enabled = true;
        }

        private void txtFNac_Enter(object sender, EventArgs e)
        {
            MyCalendar = new MonthCalendar()
            {
                Left = 330,
                Top = 110
            };
            MyCalendar.MouseLeave += MyCalendar_MouseLeave;
            MyCalendar.DateSelected += MyCalendar_DateSelected;
            MyCalendar.Leave += MyCalendar_Leave;
            this.Controls.Add(MyCalendar);
            MyCalendar.BringToFront();
            MyCalendar.Focus();
            txtFNac.Enabled = false;
        }

        private void AddAlgComboBox()
        {
            Sesion.MedList = Sesion.DBConnection.GetAllMedicaments();
            List<string> MedNames = new List<string>();

            foreach (Medicament temp in Sesion.MedList)
                if(!UserToMod.Alergias.Contains(temp.Nombre))
                    MedNames.Add(temp.Nombre);

            foreach (Control Ctemp in algContainer.Controls)
            {
                if (Ctemp is AlgControl)
                {
                    if (((AlgControl)Ctemp).Text.Equals(""))
                        return;
                    if (MedNames.Contains(((AlgControl)Ctemp).Text))
                        MedNames.Remove(((AlgControl)Ctemp).Text);
                }
            }

            algContainer.Controls.Add(new AlgControl(MedNames.ToArray()));
            if (MedNames.Count == 0)
                this.Controls.Remove(GpxAlg);
        }

        private void btnAddAlg_Click(object sender, EventArgs e)
        {
            AddAlgComboBox();
        }

        private void AlgDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AlgDataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if(DialogResult.Yes == MessageBox.Show("¿Desea eliminar la alergia del usuario?","Eliminando", MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    algDeleted.Add(UserToMod.Alergias[e.RowIndex]);
                    UserToMod.Alergias.Remove(UserToMod.Alergias[e.RowIndex]);
                    AlgDataGrid.DataSource = UserToMod.GetAlgList();
                }
            }
        }
    }
}
