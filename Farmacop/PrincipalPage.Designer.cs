namespace Farmacop
{
    partial class PrincipalPage
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitPrincipal = new System.Windows.Forms.SplitContainer();
            this.MenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Menu1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProfile = new System.Windows.Forms.Label();
            this.Menu2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Menu3 = new System.Windows.Forms.FlowLayoutPanel();
            this.Menu4 = new System.Windows.Forms.FlowLayoutPanel();
            this.Menu5 = new System.Windows.Forms.FlowLayoutPanel();
            this.Menu6 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblMedic = new System.Windows.Forms.Label();
            this.lblRecepies = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).BeginInit();
            this.SplitPrincipal.Panel1.SuspendLayout();
            this.SplitPrincipal.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.Menu1.SuspendLayout();
            this.Menu2.SuspendLayout();
            this.Menu3.SuspendLayout();
            this.Menu4.SuspendLayout();
            this.Menu5.SuspendLayout();
            this.Menu6.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitPrincipal
            // 
            this.SplitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitPrincipal.IsSplitterFixed = true;
            this.SplitPrincipal.Location = new System.Drawing.Point(0, 0);
            this.SplitPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.SplitPrincipal.Name = "SplitPrincipal";
            // 
            // SplitPrincipal.Panel1
            // 
            this.SplitPrincipal.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.SplitPrincipal.Panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SplitPrincipal.Panel1.Controls.Add(this.MenuPanel);
            this.SplitPrincipal.Size = new System.Drawing.Size(1405, 840);
            this.SplitPrincipal.SplitterDistance = 415;
            this.SplitPrincipal.SplitterWidth = 1;
            this.SplitPrincipal.TabIndex = 0;
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.MediumBlue;
            this.MenuPanel.Controls.Add(this.Menu1);
            this.MenuPanel.Controls.Add(this.Menu2);
            this.MenuPanel.Controls.Add(this.Menu3);
            this.MenuPanel.Controls.Add(this.Menu4);
            this.MenuPanel.Controls.Add(this.Menu5);
            this.MenuPanel.Controls.Add(this.Menu6);
            this.MenuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(465, 840);
            this.MenuPanel.TabIndex = 0;
            // 
            // Menu1
            // 
            this.Menu1.Controls.Add(this.lblProfile);
            this.Menu1.Location = new System.Drawing.Point(0, 0);
            this.Menu1.Margin = new System.Windows.Forms.Padding(0);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(468, 100);
            this.Menu1.TabIndex = 2;
            this.Menu1.Tag = "Profile";
            this.Menu1.Click += new System.EventHandler(this.Menu_Click);
            this.Menu1.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu1.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfile.ForeColor = System.Drawing.Color.White;
            this.lblProfile.Location = new System.Drawing.Point(75, 34);
            this.lblProfile.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(75, 32);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.Tag = "Profile";
            this.lblProfile.Text = "Perfil";
            this.lblProfile.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // Menu2
            // 
            this.Menu2.Controls.Add(this.lblUsers);
            this.Menu2.Location = new System.Drawing.Point(0, 100);
            this.Menu2.Margin = new System.Windows.Forms.Padding(0);
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(468, 100);
            this.Menu2.TabIndex = 3;
            this.Menu2.Tag = "Users";
            this.Menu2.Click += new System.EventHandler(this.Menu_Click);
            this.Menu2.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu2.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // Menu3
            // 
            this.Menu3.Controls.Add(this.lblMedic);
            this.Menu3.Location = new System.Drawing.Point(0, 200);
            this.Menu3.Margin = new System.Windows.Forms.Padding(0);
            this.Menu3.Name = "Menu3";
            this.Menu3.Size = new System.Drawing.Size(468, 100);
            this.Menu3.TabIndex = 4;
            this.Menu3.Tag = "Medic";
            this.Menu3.Click += new System.EventHandler(this.Menu_Click);
            this.Menu3.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu3.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // Menu4
            // 
            this.Menu4.Controls.Add(this.lblRecepies);
            this.Menu4.Location = new System.Drawing.Point(0, 300);
            this.Menu4.Margin = new System.Windows.Forms.Padding(0);
            this.Menu4.Name = "Menu4";
            this.Menu4.Size = new System.Drawing.Size(468, 100);
            this.Menu4.TabIndex = 5;
            this.Menu4.Tag = "Recepies";
            this.Menu4.Click += new System.EventHandler(this.Menu_Click);
            this.Menu4.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu4.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // Menu5
            // 
            this.Menu5.Controls.Add(this.lblControl);
            this.Menu5.Location = new System.Drawing.Point(0, 400);
            this.Menu5.Margin = new System.Windows.Forms.Padding(0);
            this.Menu5.Name = "Menu5";
            this.Menu5.Size = new System.Drawing.Size(468, 100);
            this.Menu5.TabIndex = 6;
            this.Menu5.Tag = "Control";
            this.Menu5.Click += new System.EventHandler(this.Menu_Click);
            this.Menu5.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu5.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // Menu6
            // 
            this.Menu6.Controls.Add(this.lblLogout);
            this.Menu6.Location = new System.Drawing.Point(0, 500);
            this.Menu6.Margin = new System.Windows.Forms.Padding(0);
            this.Menu6.Name = "Menu6";
            this.Menu6.Size = new System.Drawing.Size(468, 100);
            this.Menu6.TabIndex = 7;
            this.Menu6.Tag = "Logout";
            this.Menu6.Click += new System.EventHandler(this.Menu_Click);
            this.Menu6.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu6.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.ForeColor = System.Drawing.Color.White;
            this.lblUsers.Location = new System.Drawing.Point(75, 34);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(122, 32);
            this.lblUsers.TabIndex = 1;
            this.lblUsers.Tag = "Users";
            this.lblUsers.Text = "Usuarios";
            this.lblUsers.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // lblMedic
            // 
            this.lblMedic.AutoSize = true;
            this.lblMedic.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedic.ForeColor = System.Drawing.Color.White;
            this.lblMedic.Location = new System.Drawing.Point(75, 34);
            this.lblMedic.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblMedic.Name = "lblMedic";
            this.lblMedic.Size = new System.Drawing.Size(192, 32);
            this.lblMedic.TabIndex = 1;
            this.lblMedic.Tag = "Medic";
            this.lblMedic.Text = "Medicamentos";
            this.lblMedic.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // lblRecepies
            // 
            this.lblRecepies.AutoSize = true;
            this.lblRecepies.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecepies.ForeColor = System.Drawing.Color.White;
            this.lblRecepies.Location = new System.Drawing.Point(75, 34);
            this.lblRecepies.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblRecepies.Name = "lblRecepies";
            this.lblRecepies.Size = new System.Drawing.Size(116, 32);
            this.lblRecepies.TabIndex = 1;
            this.lblRecepies.Tag = "Recepies";
            this.lblRecepies.Text = "Recetas";
            this.lblRecepies.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.ForeColor = System.Drawing.Color.White;
            this.lblControl.Location = new System.Drawing.Point(75, 34);
            this.lblControl.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(239, 32);
            this.lblControl.TabIndex = 1;
            this.lblControl.Tag = "Control";
            this.lblControl.Text = "Control de recetas";
            this.lblControl.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Location = new System.Drawing.Point(75, 34);
            this.lblLogout.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(69, 32);
            this.lblLogout.TabIndex = 1;
            this.lblLogout.Tag = "Logout";
            this.lblLogout.Text = "Salir";
            this.lblLogout.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // PrincipalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitPrincipal);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "PrincipalPage";
            this.Size = new System.Drawing.Size(1405, 840);
            this.SizeChanged += new System.EventHandler(this.PaginaPrincipal_SizeChanged);
            this.SplitPrincipal.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).EndInit();
            this.SplitPrincipal.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.Menu1.ResumeLayout(false);
            this.Menu1.PerformLayout();
            this.Menu2.ResumeLayout(false);
            this.Menu2.PerformLayout();
            this.Menu3.ResumeLayout(false);
            this.Menu3.PerformLayout();
            this.Menu4.ResumeLayout(false);
            this.Menu4.PerformLayout();
            this.Menu5.ResumeLayout(false);
            this.Menu5.PerformLayout();
            this.Menu6.ResumeLayout(false);
            this.Menu6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.SplitContainer SplitPrincipal;
        public System.Windows.Forms.FlowLayoutPanel MenuPanel;
        private System.Windows.Forms.FlowLayoutPanel Menu1;
        private System.Windows.Forms.FlowLayoutPanel Menu2;
        private System.Windows.Forms.FlowLayoutPanel Menu3;
        private System.Windows.Forms.FlowLayoutPanel Menu4;
        private System.Windows.Forms.FlowLayoutPanel Menu5;
        private System.Windows.Forms.FlowLayoutPanel Menu6;
        public System.Windows.Forms.Label lblLogout;
        public System.Windows.Forms.Label lblControl;
        public System.Windows.Forms.Label lblRecepies;
        public System.Windows.Forms.Label lblMedic;
        public System.Windows.Forms.Label lblUsers;
        public System.Windows.Forms.Label lblProfile;
    }
}
