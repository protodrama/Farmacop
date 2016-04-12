namespace Farmacop
{
    partial class FormP
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormP));
            this.pctbxFarmacop = new System.Windows.Forms.PictureBox();
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.tbxAccount = new System.Windows.Forms.TextBox();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkNewUser = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxFarmacop)).BeginInit();
            this.SuspendLayout();
            // 
            // pctbxFarmacop
            // 
            this.pctbxFarmacop.Image = ((System.Drawing.Image)(resources.GetObject("pctbxFarmacop.Image")));
            this.pctbxFarmacop.Location = new System.Drawing.Point(553, 97);
            this.pctbxFarmacop.Name = "pctbxFarmacop";
            this.pctbxFarmacop.Size = new System.Drawing.Size(366, 47);
            this.pctbxFarmacop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxFarmacop.TabIndex = 0;
            this.pctbxFarmacop.TabStop = false;
            // 
            // lblIniciarSesion
            // 
            this.lblIniciarSesion.AutoSize = true;
            this.lblIniciarSesion.Font = new System.Drawing.Font("Arial Black", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciarSesion.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblIniciarSesion.Location = new System.Drawing.Point(593, 165);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(280, 50);
            this.lblIniciarSesion.TabIndex = 1;
            this.lblIniciarSesion.Text = "Iniciar sesión";
            // 
            // tbxAccount
            // 
            this.tbxAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAccount.Location = new System.Drawing.Point(619, 242);
            this.tbxAccount.Name = "tbxAccount";
            this.tbxAccount.Size = new System.Drawing.Size(220, 26);
            this.tbxAccount.TabIndex = 1;
            // 
            // tbxPass
            // 
            this.tbxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPass.Location = new System.Drawing.Point(619, 303);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.PasswordChar = '*';
            this.tbxPass.Size = new System.Drawing.Size(220, 26);
            this.tbxPass.TabIndex = 2;
            this.tbxPass.UseSystemPasswordChar = true;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(680, 349);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(94, 32);
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre de cuenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(619, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña:";
            // 
            // lnkNewUser
            // 
            this.lnkNewUser.AutoSize = true;
            this.lnkNewUser.LinkArea = new System.Windows.Forms.LinkArea(68, 70);
            this.lnkNewUser.Location = new System.Drawing.Point(636, 398);
            this.lnkNewUser.Name = "lnkNewUser";
            this.lnkNewUser.Size = new System.Drawing.Size(203, 30);
            this.lnkNewUser.TabIndex = 6;
            this.lnkNewUser.TabStop = true;
            this.lnkNewUser.Text = "Si es la primera vez que entras añade \r\nuna contraseña a tu usuario aquí";
            this.lnkNewUser.UseCompatibleTextRendering = true;
            this.lnkNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewUser_LinkClicked);
            // 
            // FormP
            // 
            this.AcceptButton = this.btnEntrar;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1419, 821);
            this.Controls.Add(this.lnkNewUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.tbxAccount);
            this.Controls.Add(this.lblIniciarSesion);
            this.Controls.Add(this.pctbxFarmacop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmacop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormP_FormClosing);
            this.Resize += new System.EventHandler(this.Formulario_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pctbxFarmacop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctbxFarmacop;
        private System.Windows.Forms.Label lblIniciarSesion;
        private System.Windows.Forms.TextBox tbxAccount;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkNewUser;
    }
}

