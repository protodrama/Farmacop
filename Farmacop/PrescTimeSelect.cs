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
    //Control utilizado para la selección de horas al agregar o modificar una receta
    public partial class PrescTimeSelect : UserControl
    {
        public PrescTimeSelect()
        {
            InitializeComponent();
            FillMins();
        }

        public void FillMins()
        {
            for(int i = 0; i < 60; i+= 5)
            {
                cbbxMin.Items.Add(i.ToString("00"));
            }
            cbbxHour.SelectedIndex = 0;
            cbbxMin.SelectedIndex = 0;
        }

        public string Time
        {
            get
            {
                return cbbxHour.Text + ":" + cbbxMin.Text;
            }
        }
    }
}
