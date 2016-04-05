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
        User ModifiedUser;

        public ModifyUserForm()
        {
            InitializeComponent();
        }

        public ModifyUserForm(User userToMod)
        {
            InitializeComponent();
            this.UserToMod = userToMod;
            ModifiedUser = UserToMod;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Modifica usuario y cierra
            this.Close();
        }
    }
}
