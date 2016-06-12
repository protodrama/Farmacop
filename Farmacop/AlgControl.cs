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
    //Control utilizado para seleccionar diferentes alergias en las listas los formularios de agregar y modificar usuario
    public partial class AlgControl : UserControl
    {
        public AlgControl(string[] data)
        {
            InitializeComponent();
            this.AlgComboBox.Items.AddRange(data);
        }

        //Obtiene el nombre del medicamento seleccionado
        public string GetText { get { return AlgComboBox.Text; } }
    }
}
