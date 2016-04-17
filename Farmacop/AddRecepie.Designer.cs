namespace Farmacop
{
    partial class AddRecepie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.SplitContainer splAlg;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecepie));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtTargetUser = new System.Windows.Forms.TextBox();
            this.grpRecData = new System.Windows.Forms.GroupBox();
            this.txtFEnd = new System.Windows.Forms.TextBox();
            this.txtFInic = new System.Windows.Forms.TextBox();
            this.txtDs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFInic = new System.Windows.Forms.Label();
            this.btnAddMed = new System.Windows.Forms.Button();
            this.cbbxMed = new System.Windows.Forms.ComboBox();
            this.lblMed = new System.Windows.Forms.Label();
            this.GpxTime = new System.Windows.Forms.GroupBox();
            this.TimeContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddAlg = new System.Windows.Forms.Button();
            splAlg = new System.Windows.Forms.SplitContainer();
            this.grpRecData.SuspendLayout();
            this.GpxTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(splAlg)).BeginInit();
            splAlg.Panel1.SuspendLayout();
            splAlg.Panel2.SuspendLayout();
            splAlg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(210, 330);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Añadir";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(364, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(73, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(95, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Usuario destinado:";
            // 
            // txtTargetUser
            // 
            this.txtTargetUser.Location = new System.Drawing.Point(174, 19);
            this.txtTargetUser.Name = "txtTargetUser";
            this.txtTargetUser.Size = new System.Drawing.Size(160, 20);
            this.txtTargetUser.TabIndex = 3;
            this.txtTargetUser.TextChanged += new System.EventHandler(this.txtTargetUser_TextChanged);
            // 
            // grpRecData
            // 
            this.grpRecData.Controls.Add(this.GpxTime);
            this.grpRecData.Controls.Add(this.txtFEnd);
            this.grpRecData.Controls.Add(this.txtFInic);
            this.grpRecData.Controls.Add(this.txtDs);
            this.grpRecData.Controls.Add(this.label2);
            this.grpRecData.Controls.Add(this.label1);
            this.grpRecData.Controls.Add(this.lblFInic);
            this.grpRecData.Controls.Add(this.btnAddMed);
            this.grpRecData.Controls.Add(this.cbbxMed);
            this.grpRecData.Controls.Add(this.lblMed);
            this.grpRecData.Location = new System.Drawing.Point(46, 45);
            this.grpRecData.Name = "grpRecData";
            this.grpRecData.Size = new System.Drawing.Size(567, 263);
            this.grpRecData.TabIndex = 4;
            this.grpRecData.TabStop = false;
            this.grpRecData.Text = "Datos de receta";
            this.grpRecData.Visible = false;
            // 
            // txtFEnd
            // 
            this.txtFEnd.Location = new System.Drawing.Point(128, 152);
            this.txtFEnd.Name = "txtFEnd";
            this.txtFEnd.Size = new System.Drawing.Size(100, 20);
            this.txtFEnd.TabIndex = 8;
            this.txtFEnd.Enter += new System.EventHandler(this.txtFEnd_Enter);
            // 
            // txtFInic
            // 
            this.txtFInic.Location = new System.Drawing.Point(128, 109);
            this.txtFInic.Name = "txtFInic";
            this.txtFInic.Size = new System.Drawing.Size(100, 20);
            this.txtFInic.TabIndex = 7;
            this.txtFInic.Enter += new System.EventHandler(this.txtFInic_Enter);
            // 
            // txtDs
            // 
            this.txtDs.Location = new System.Drawing.Point(128, 67);
            this.txtDs.MaxLength = 5;
            this.txtDs.Name = "txtDs";
            this.txtDs.Size = new System.Drawing.Size(100, 20);
            this.txtDs.TabIndex = 6;
            this.txtDs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDs_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dosis (mg):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha de fin:";
            // 
            // lblFInic
            // 
            this.lblFInic.AutoSize = true;
            this.lblFInic.Location = new System.Drawing.Point(40, 112);
            this.lblFInic.Name = "lblFInic";
            this.lblFInic.Size = new System.Drawing.Size(82, 13);
            this.lblFInic.TabIndex = 3;
            this.lblFInic.Text = "Fecha de inicio:";
            // 
            // btnAddMed
            // 
            this.btnAddMed.Location = new System.Drawing.Point(255, 22);
            this.btnAddMed.Name = "btnAddMed";
            this.btnAddMed.Size = new System.Drawing.Size(124, 23);
            this.btnAddMed.TabIndex = 2;
            this.btnAddMed.Text = "Nuevo medicamento";
            this.btnAddMed.UseVisualStyleBackColor = true;
            this.btnAddMed.Click += new System.EventHandler(this.btnAddMed_Click);
            // 
            // cbbxMed
            // 
            this.cbbxMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxMed.FormattingEnabled = true;
            this.cbbxMed.Location = new System.Drawing.Point(128, 22);
            this.cbbxMed.Name = "cbbxMed";
            this.cbbxMed.Size = new System.Drawing.Size(121, 21);
            this.cbbxMed.TabIndex = 1;
            // 
            // lblMed
            // 
            this.lblMed.AutoSize = true;
            this.lblMed.Location = new System.Drawing.Point(48, 25);
            this.lblMed.Name = "lblMed";
            this.lblMed.Size = new System.Drawing.Size(74, 13);
            this.lblMed.TabIndex = 0;
            this.lblMed.Text = "Medicamento:";
            // 
            // GpxTime
            // 
            this.GpxTime.Controls.Add(splAlg);
            this.GpxTime.Location = new System.Drawing.Point(391, 22);
            this.GpxTime.Name = "GpxTime";
            this.GpxTime.Size = new System.Drawing.Size(176, 195);
            this.GpxTime.TabIndex = 48;
            this.GpxTime.TabStop = false;
            this.GpxTime.Text = "Hora de tomas";
            // 
            // splAlg
            // 
            splAlg.Dock = System.Windows.Forms.DockStyle.Fill;
            splAlg.Location = new System.Drawing.Point(3, 16);
            splAlg.Margin = new System.Windows.Forms.Padding(0);
            splAlg.Name = "splAlg";
            splAlg.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splAlg.Panel1
            // 
            splAlg.Panel1.Controls.Add(this.TimeContainer);
            // 
            // splAlg.Panel2
            // 
            splAlg.Panel2.Controls.Add(this.panel1);
            splAlg.Size = new System.Drawing.Size(170, 176);
            splAlg.SplitterDistance = 136;
            splAlg.SplitterWidth = 1;
            splAlg.TabIndex = 0;
            // 
            // TimeContainer
            // 
            this.TimeContainer.AutoScroll = true;
            this.TimeContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TimeContainer.Location = new System.Drawing.Point(3, 0);
            this.TimeContainer.Name = "TimeContainer";
            this.TimeContainer.Size = new System.Drawing.Size(164, 134);
            this.TimeContainer.TabIndex = 0;
            this.TimeContainer.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddAlg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnAddAlg
            // 
            this.btnAddAlg.Location = new System.Drawing.Point(42, 3);
            this.btnAddAlg.Name = "btnAddAlg";
            this.btnAddAlg.Size = new System.Drawing.Size(99, 23);
            this.btnAddAlg.TabIndex = 0;
            this.btnAddAlg.Text = "Agregar";
            this.btnAddAlg.UseVisualStyleBackColor = true;
            this.btnAddAlg.Click += new System.EventHandler(this.btnAddAlg_Click);
            // 
            // AddRecepie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 375);
            this.ControlBox = false;
            this.Controls.Add(this.grpRecData);
            this.Controls.Add(this.txtTargetUser);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddRecepie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Añadir receta";
            this.grpRecData.ResumeLayout(false);
            this.grpRecData.PerformLayout();
            this.GpxTime.ResumeLayout(false);
            splAlg.Panel1.ResumeLayout(false);
            splAlg.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splAlg)).EndInit();
            splAlg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtTargetUser;
        private System.Windows.Forms.GroupBox grpRecData;
        private System.Windows.Forms.Label lblMed;
        private System.Windows.Forms.ComboBox cbbxMed;
        private System.Windows.Forms.Button btnAddMed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFInic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFEnd;
        private System.Windows.Forms.TextBox txtFInic;
        private System.Windows.Forms.TextBox txtDs;
        private System.Windows.Forms.GroupBox GpxTime;
        private System.Windows.Forms.FlowLayoutPanel TimeContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddAlg;
    }
}