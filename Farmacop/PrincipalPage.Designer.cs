﻿namespace Farmacop
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
            this.lblUsers = new System.Windows.Forms.Label();
            this.Menu3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMedic = new System.Windows.Forms.Label();
            this.Menu4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRecepies = new System.Windows.Forms.Label();
            this.Menu5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtNumMsgs = new System.Windows.Forms.Label();
            this.Menu6 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLogout = new System.Windows.Forms.Label();
            this.SplitContaint = new System.Windows.Forms.SplitContainer();
            this.TitlePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelTitle = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.titleline = new System.Windows.Forms.Panel();
            this.Panel2Containt = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.SplitPrincipal)).BeginInit();
            this.SplitPrincipal.Panel1.SuspendLayout();
            this.SplitPrincipal.Panel2.SuspendLayout();
            this.SplitPrincipal.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.Menu1.SuspendLayout();
            this.Menu2.SuspendLayout();
            this.Menu3.SuspendLayout();
            this.Menu4.SuspendLayout();
            this.Menu5.SuspendLayout();
            this.Menu6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContaint)).BeginInit();
            this.SplitContaint.Panel1.SuspendLayout();
            this.SplitContaint.Panel2.SuspendLayout();
            this.SplitContaint.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.PanelTitle.SuspendLayout();
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
            // 
            // SplitPrincipal.Panel2
            // 
            this.SplitPrincipal.Panel2.Controls.Add(this.SplitContaint);
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
            this.lblProfile.Click += new System.EventHandler(this.Menu_Click);
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
            this.lblUsers.Click += new System.EventHandler(this.Menu_Click);
            this.lblUsers.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
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
            this.lblMedic.Click += new System.EventHandler(this.Menu_Click);
            this.lblMedic.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
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
            this.lblRecepies.Click += new System.EventHandler(this.Menu_Click);
            this.lblRecepies.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // Menu5
            // 
            this.Menu5.Controls.Add(this.lblMessage);
            this.Menu5.Controls.Add(this.txtNumMsgs);
            this.Menu5.Location = new System.Drawing.Point(0, 400);
            this.Menu5.Margin = new System.Windows.Forms.Padding(0);
            this.Menu5.Name = "Menu5";
            this.Menu5.Size = new System.Drawing.Size(468, 100);
            this.Menu5.TabIndex = 6;
            this.Menu5.Tag = "Messages";
            this.Menu5.Click += new System.EventHandler(this.Menu_Click);
            this.Menu5.MouseEnter += new System.EventHandler(this.Menu_MouseEnter);
            this.Menu5.MouseLeave += new System.EventHandler(this.Menu_MouseLeave);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(75, 34);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(75, 34, 3, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(132, 32);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Tag = "Messages";
            this.lblMessage.Text = "Mensajes";
            this.lblMessage.Click += new System.EventHandler(this.Menu_Click);
            this.lblMessage.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // txtNumMsgs
            // 
            this.txtNumMsgs.AutoSize = true;
            this.txtNumMsgs.BackColor = System.Drawing.Color.Yellow;
            this.txtNumMsgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumMsgs.Location = new System.Drawing.Point(213, 30);
            this.txtNumMsgs.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.txtNumMsgs.Name = "txtNumMsgs";
            this.txtNumMsgs.Size = new System.Drawing.Size(19, 20);
            this.txtNumMsgs.TabIndex = 2;
            this.txtNumMsgs.Tag = "Messages";
            this.txtNumMsgs.Text = "..";
            this.txtNumMsgs.Visible = false;
            this.txtNumMsgs.Click += new System.EventHandler(this.Menu_Click);
            this.txtNumMsgs.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
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
            this.lblLogout.Click += new System.EventHandler(this.Menu_Click);
            this.lblLogout.MouseEnter += new System.EventHandler(this.lblMenu_MouseEnter);
            // 
            // SplitContaint
            // 
            this.SplitContaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContaint.IsSplitterFixed = true;
            this.SplitContaint.Location = new System.Drawing.Point(0, 0);
            this.SplitContaint.Name = "SplitContaint";
            this.SplitContaint.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContaint.Panel1
            // 
            this.SplitContaint.Panel1.Controls.Add(this.TitlePanel);
            // 
            // SplitContaint.Panel2
            // 
            this.SplitContaint.Panel2.Controls.Add(this.Panel2Containt);
            this.SplitContaint.Size = new System.Drawing.Size(989, 840);
            this.SplitContaint.SplitterDistance = 58;
            this.SplitContaint.SplitterWidth = 1;
            this.SplitContaint.TabIndex = 0;
            this.SplitContaint.TabStop = false;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.PanelTitle);
            this.TitlePanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(989, 53);
            this.TitlePanel.TabIndex = 0;
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.lblTitle);
            this.PanelTitle.Controls.Add(this.titleline);
            this.PanelTitle.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelTitle.Location = new System.Drawing.Point(3, 3);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(983, 50);
            this.PanelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTitle.Location = new System.Drawing.Point(150, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(150, 3, 3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Perfil";
            // 
            // titleline
            // 
            this.titleline.BackColor = System.Drawing.Color.MediumBlue;
            this.titleline.Location = new System.Drawing.Point(3, 38);
            this.titleline.Name = "titleline";
            this.titleline.Size = new System.Drawing.Size(1600, 3);
            this.titleline.TabIndex = 1;
            // 
            // Panel2Containt
            // 
            this.Panel2Containt.Location = new System.Drawing.Point(0, 0);
            this.Panel2Containt.Name = "Panel2Containt";
            this.Panel2Containt.Size = new System.Drawing.Size(989, 781);
            this.Panel2Containt.TabIndex = 0;
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
            this.SplitPrincipal.Panel2.ResumeLayout(false);
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
            this.SplitContaint.Panel1.ResumeLayout(false);
            this.SplitContaint.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContaint)).EndInit();
            this.SplitContaint.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
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
        public System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.Label lblRecepies;
        public System.Windows.Forms.Label lblMedic;
        public System.Windows.Forms.Label lblUsers;
        public System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.FlowLayoutPanel TitlePanel;
        public System.Windows.Forms.SplitContainer SplitContaint;
        private System.Windows.Forms.FlowLayoutPanel PanelTitle;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel titleline;
        private System.Windows.Forms.FlowLayoutPanel Panel2Containt;
        private System.Windows.Forms.Label txtNumMsgs;
    }
}
