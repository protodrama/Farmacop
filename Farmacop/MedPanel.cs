﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Newtonsoft.Json.Linq;

namespace Farmacop
{
    //Control que contiene todo lo referente a los medicamentos del entorno
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

        //Centra todo el contenido del control
        public void Center()
        {
            foreach(Control tmp in this.Controls)
            {
                tmp.Left = this.Width / 2 - tmp.Width / 2;
            }
        }

        //Agrega las columnas extras a la tabla de medicamentos
        private void InicializeTable()
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
            MedTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            MedTable.EnableHeadersVisualStyles = false;
        }

        //Obtiene los datos de los medicamentos desde el servidor
        private void GetData()
        {
            try
            {
                Session.MedList = ReadData(Session.DBConnection.GetAllMedicaments());
                if (Session.MedList != null)
                {
                    MedTable.DataSource = Session.MedList;
                    List<string> names = new List<string>();
                    foreach (Medicament tmp in Session.MedList)
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

        //Lee los datos de los medicamentos recibidos por el servidor
        public List<Medicament> ReadData(string jsondata)
        {
            List<Medicament> thelist = new List<Medicament>();
            JObject jobject = JObject.Parse(jsondata);
            JToken jdata = jobject["data"];

            for(int i = 0; i < jdata.Count<JToken>(); i++)
            {
                Medicament temp = new Medicament(jdata[i]["Nombre"].ToString(), jdata[i]["Tipo"].ToString());
                thelist.Add(temp);
            }

            return thelist;
        }

        //Agrega un nuevo medicamento comprobando que los datos están correctos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Name = "";
            string Type = cbbxType.Text;
            string NoCapName = txtNewMedNm.Text;

            if (!Type.Equals("") && !txtNewMedNm.Text.Trim().Equals(""))
            {
                bool find = false;
                foreach (Medicament MedTmp in Session.MedList)
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
                    try
                    {
                        if (Session.DBConnection.InsertMedicament(Name, Type))
                        {
                            GetData();
                            txtNewMedNm.Text = "";
                            MessageBox.Show("Medicamento insertado con éxito");
                        }
                        else
                        {
                            SystemSounds.Beep.Play();
                            MessageBox.Show("Error al insertar el medicamento");
                        }
                    }
                    catch(Exception ex)
                    {
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

        //Captura el evento de pulsación sobre el botón "Eliminar" de la tabla de medicamentos
        private void MedTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Medicament MedToDel = Session.MedList[e.RowIndex];

                if (DialogResult.Yes == MessageBox.Show("¿Seguro que quiere eliminar el medicamento con nombre " + MedToDel.Nombre + "?\nSe eliminará de forma permamente...", "Eliminar medicamento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    try
                    {
                        if (Session.DBConnection.DeleteMedicament(MedToDel.Nombre))
                        {
                            GetData();
                            MessageBox.Show("Medicamento eliminado correctamente", "Eliminado");
                        }
                        else
                            MessageBox.Show("Error al eliminar el medicamento. Puede que algunos pacientes tengan alergias asignadas o esté asignado a alguna receta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el medicamento.");
                    }
                }
            }
        }

        //Modifica un medicamento comprobando que todos los datos están correctamente introducidos
        private void btnMod_Click(object sender, EventArgs e)
        {
            if (!lblTypeMedMod.Text.Equals("...") && !txtbxMedNewName.Text.Equals("") && !cbbxTypeMod.Text.Equals(""))
            {
                string FChar = txtbxMedNewName.Text.Substring(0, 1);
                string NameNoFChar = txtbxMedNewName.Text.Substring(1, txtbxMedNewName.Text.Length - 1);
                string Name = FChar.ToUpper() + NameNoFChar;
                bool toUpdate = true;

                foreach (Medicament MedTmp in Session.MedList)
                {
                    if (!MedTmp.Nombre.ToLower().Equals(txtbxMedAMod.Text.ToLower()))
                    {
                        if (MedTmp.Nombre.ToLower().Equals(Name.ToLower()))
                        {
                            MessageBox.Show("El nuevo nombre coincide con uno de los medicamentos existentes.");
                            toUpdate = false;
                        }
                    }
                    else if (MedTmp.Tipo.ToLower().Equals(cbbxTypeMod.Text.ToLower()) && MedTmp.Nombre.ToLower().Equals(Name.ToLower()))
                    {
                        MessageBox.Show("No se realizan modificaciones al medicamento");
                        toUpdate = false;
                    }              
                }

                if (toUpdate)
                {
                    try
                    {
                        if (Session.DBConnection.UpdateMedicament(txtbxMedAMod.Text, Name, cbbxTypeMod.Text))
                        {
                            GetData();
                            MessageBox.Show("Medicamento modificado correctamente");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar el medicamento");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al modificar el medicamento");
                    }
                }
                
                txtbxMedAMod.Text = "";
                txtbxMedNewName.Text = "";
                cbbxTypeMod.Text = "";

            }
            else
                MessageBox.Show("Debes introducir todos los datos del medicamento que se quiere modificar correctamente");
        }

        //Comprueba si el nombre del medicamento a modificar existe y agrega el resto de datos al cuadro de modificación
        private void txtbxMedAMod_TextChanged(object sender, EventArgs e)
        {
            foreach(Medicament tmp in Session.MedList)
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
    }
}
