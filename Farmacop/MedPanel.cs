using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Farmacop
{
    public partial class MedPanel : UserControl
    {
        DataGridViewButtonColumn BtnDeleteColumn;
        bool firstCharge = true;

        public MedPanel()
        {
            InitializeComponent();
            GetData();
            Center();
        }

        public void Center()
        {
            foreach(Control tmp in this.Controls)
            {
                tmp.Left = this.Width / 2 - tmp.Width / 2;
            }
        }

        private void InicializeTable()
        {
            if(Sesion.UserType == UserType.Admin)
            {
                BtnDeleteColumn = new DataGridViewButtonColumn()
                {
                    Name = "Delete",
                    Width = 80,
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                MedTable.Columns.Add(BtnDeleteColumn);
                MedTable.Width += BtnDeleteColumn.Width + 5;
                MedTable.Left = (this.Width / 2) - (MedTable.Width / 2);
            }
            MedTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            MedTable.EnableHeadersVisualStyles = false;
        }

        private void GetData()
        {
            try
            {
                Sesion.MedList = Sesion.DBConnection.GetAllMedicaments();
                if (Sesion.MedList != null)
                {
                    MedTable.DataSource = Sesion.MedList;
                    List<string> names = new List<string>();
                    foreach (Medicament tmp in Sesion.MedList)
                        names.Add(tmp.Nombre);
                    var source = new AutoCompleteStringCollection();
                    source.AddRange(names.ToArray());
                    txtbxMedAMod.AutoCompleteCustomSource = source;
                    txtbxMedAMod.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    if (firstCharge)
                    {
                        MedTable.Columns[0].Width = 200;
                        MedTable.Columns[1].Width = 200;
                        MedTable.Width = MedTable.Columns[0].Width + MedTable.Columns[1].Width;
                        MedTable.Left = (this.Width / 2) - (MedTable.Width / 2);
                        InicializeTable();
                        firstCharge = false;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al obtener los medicamentos. Consulte al administrador.\n" + e.Message);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Name = "";
            string Type = cbbxType.Text;
            string NoCapName = txtNewMedNm.Text;

            if (!Type.Equals("") && !txtNewMedNm.Text.Equals(""))
            {
                bool find = false;
                foreach (Medicament MedTmp in Sesion.MedList)
                {
                    if (MedTmp.Nombre.ToLower().Equals(NoCapName.ToLower()))
                    {
                        find = true;
                        MessageBox.Show("El medicamento existe en la lista");
                        break;
                    }
                }

                if (!find)
                {
                    string FChar = NoCapName.Substring(0, 1);
                    string NameNoFChar = NoCapName.Substring(1, NoCapName.Length - 1);
                    Name = FChar.ToUpper() + NameNoFChar;
                    if (Sesion.DBConnection.InsertMedicament(Name, Type))
                    {
                        GetData();
                        MessageBox.Show("Medicamento insertado con éxito");
                    }
                    else {
                        SystemSounds.Beep.Play();
                        MessageBox.Show("Error al insertar el medicamento");
                    }
                    cbbxType.Text = "";
                    txtNewMedNm.Text = "";
                }
            }
            else
                MessageBox.Show("Debes introducir los datos del medicamento");
        }

        private void MedTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Medicament MedToDel = Sesion.MedList[e.RowIndex];

                if (DialogResult.Yes == MessageBox.Show("¿Seguro que quiere eliminar el medicamento con nombre " + MedToDel.Nombre + "?\nSe eliminará de forma permamente...", "Eliminar medicamento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    if (Sesion.DBConnection.DeleteMedicament(MedToDel.Nombre))
                    {
                        GetData();
                        MessageBox.Show("Medicamento eliminado correctamente", "Eliminado");
                    }
                    else
                        MessageBox.Show("Error al eliminar el medicamento. Puede que algunos pacientes tengan alergias asignadas.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (!lblTypeMedMod.Text.Equals("...") && !txtbxMedNewName.Text.Equals("") && !cbbxTypeMod.Text.Equals(""))
            {
                string FChar = txtbxMedNewName.Text.Substring(0, 1);
                string NameNoFChar = txtbxMedNewName.Text.Substring(1, txtbxMedNewName.Text.Length - 1);
                string Name = FChar.ToUpper() + NameNoFChar;

                foreach (Medicament MedTmp in Sesion.MedList)
                {
                    if (MedTmp.Nombre.ToLower().Equals(Name.ToLower()))
                    {                     
                        MessageBox.Show("El nuevo nombre coincide con uno de los medicamentos existentes.");
                        return;
                    }
                }

                if (Sesion.DBConnection.UpdateMedicament(txtbxMedAMod.Text, Name, cbbxTypeMod.Text))
                {
                    GetData();
                    MessageBox.Show("Medicamento modificado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al modificar el medicamento");
                }
                txtbxMedAMod.Text = "";
                txtbxMedNewName.Text = "";
                cbbxTypeMod.Text = "";

            }
            else
                MessageBox.Show("Debes introducir todos los datos del medicamento que se quiere modificar correctamente");
        }

        private void txtbxMedAMod_TextChanged(object sender, EventArgs e)
        {
            foreach(Medicament tmp in Sesion.MedList)
            {
                if (tmp.Nombre.Equals(txtbxMedAMod.Text))
                {
                    lblTypeMedMod.Text = tmp.Tipo;
                    txtbxMedNewName.Text = tmp.Nombre;
                    cbbxTypeMod.Text = tmp.Tipo;
                    break;
                }
                else {
                    lblTypeMedMod.Text = "...";
                    txtbxMedNewName.Text = "";
                    cbbxTypeMod.Text = "";
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
