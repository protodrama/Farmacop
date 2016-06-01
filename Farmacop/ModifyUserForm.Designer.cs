namespace Farmacop
{
    partial class ModifyUserForm
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
            this.algContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddAlg = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblFSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFApl = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtFNac = new System.Windows.Forms.TextBox();
            this.txtSApl = new System.Windows.Forms.TextBox();
            this.lblSSurname = new System.Windows.Forms.Label();
            this.lblBDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.ComboboxType = new System.Windows.Forms.ComboBox();
            this.GpxAlg = new System.Windows.Forms.GroupBox();
            this.AlgDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            splAlg = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splAlg)).BeginInit();
            splAlg.Panel1.SuspendLayout();
            splAlg.Panel2.SuspendLayout();
            splAlg.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GpxAlg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlgDataGrid)).BeginInit();
            this.SuspendLayout();
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
            splAlg.Panel1.Controls.Add(this.algContainer);
            // 
            // splAlg.Panel2
            // 
            splAlg.Panel2.Controls.Add(this.panel1);
            splAlg.Size = new System.Drawing.Size(183, 228);
            splAlg.SplitterDistance = 199;
            splAlg.SplitterWidth = 1;
            splAlg.TabIndex = 0;
            // 
            // algContainer
            // 
            this.algContainer.AutoScroll = true;
            this.algContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.algContainer.Location = new System.Drawing.Point(3, 0);
            this.algContainer.Name = "algContainer";
            this.algContainer.Size = new System.Drawing.Size(172, 198);
            this.algContainer.TabIndex = 0;
            this.algContainer.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAddAlg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 40);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(90, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddAlg
            // 
            this.btnAddAlg.Location = new System.Drawing.Point(3, 3);
            this.btnAddAlg.Name = "btnAddAlg";
            this.btnAddAlg.Size = new System.Drawing.Size(88, 23);
            this.btnAddAlg.TabIndex = 0;
            this.btnAddAlg.Text = "Agregar";
            this.btnAddAlg.UseVisualStyleBackColor = true;
            this.btnAddAlg.Click += new System.EventHandler(this.btnAddAlg_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(287, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(128, 321);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(129, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblFSurname
            // 
            this.lblFSurname.AutoSize = true;
            this.lblFSurname.Location = new System.Drawing.Point(45, 69);
            this.lblFSurname.Name = "lblFSurname";
            this.lblFSurname.Size = new System.Drawing.Size(78, 13);
            this.lblFSurname.TabIndex = 21;
            this.lblFSurname.Text = "Primer apellido:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(76, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Nombre:";
            // 
            // txtFApl
            // 
            this.txtFApl.Location = new System.Drawing.Point(129, 69);
            this.txtFApl.Name = "txtFApl";
            this.txtFApl.Size = new System.Drawing.Size(287, 20);
            this.txtFApl.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(287, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtFNac
            // 
            this.txtFNac.Location = new System.Drawing.Point(129, 159);
            this.txtFNac.Name = "txtFNac";
            this.txtFNac.Size = new System.Drawing.Size(287, 20);
            this.txtFNac.TabIndex = 4;
            this.txtFNac.Click += new System.EventHandler(this.txtFNac_Click);
            this.txtFNac.Enter += new System.EventHandler(this.txtFNac_Enter);
            // 
            // txtSApl
            // 
            this.txtSApl.Location = new System.Drawing.Point(129, 114);
            this.txtSApl.Name = "txtSApl";
            this.txtSApl.Size = new System.Drawing.Size(287, 20);
            this.txtSApl.TabIndex = 3;
            // 
            // lblSSurname
            // 
            this.lblSSurname.AutoSize = true;
            this.lblSSurname.Location = new System.Drawing.Point(31, 117);
            this.lblSSurname.Name = "lblSSurname";
            this.lblSSurname.Size = new System.Drawing.Size(92, 13);
            this.lblSSurname.TabIndex = 27;
            this.lblSSurname.Text = "Segundo apellido:";
            // 
            // lblBDate
            // 
            this.lblBDate.AutoSize = true;
            this.lblBDate.Location = new System.Drawing.Point(17, 162);
            this.lblBDate.Name = "lblBDate";
            this.lblBDate.Size = new System.Drawing.Size(109, 13);
            this.lblBDate.TabIndex = 28;
            this.lblBDate.Text = "Fecha de nacimiento:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(40, 263);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(82, 13);
            this.lblType.TabIndex = 30;
            this.lblType.Text = "Tipo de cuenta:";
            // 
            // ComboboxType
            // 
            this.ComboboxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboboxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboboxType.Items.AddRange(new object[] {
            "Admin",
            "Medico",
            "Paciente"});
            this.ComboboxType.Location = new System.Drawing.Point(128, 260);
            this.ComboboxType.Name = "ComboboxType";
            this.ComboboxType.Size = new System.Drawing.Size(121, 21);
            this.ComboboxType.TabIndex = 31;
            // 
            // GpxAlg
            // 
            this.GpxAlg.Controls.Add(splAlg);
            this.GpxAlg.Location = new System.Drawing.Point(670, 69);
            this.GpxAlg.Name = "GpxAlg";
            this.GpxAlg.Size = new System.Drawing.Size(189, 247);
            this.GpxAlg.TabIndex = 47;
            this.GpxAlg.TabStop = false;
            this.GpxAlg.Text = "Añadir alergias";
            // 
            // AlgDataGrid
            // 
            this.AlgDataGrid.AllowUserToAddRows = false;
            this.AlgDataGrid.AllowUserToDeleteRows = false;
            this.AlgDataGrid.AllowUserToResizeRows = false;
            this.AlgDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.AlgDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlgDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.AlgDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.AlgDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlgDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AlgDataGrid.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.AlgDataGrid.Location = new System.Drawing.Point(440, 12);
            this.AlgDataGrid.MultiSelect = false;
            this.AlgDataGrid.Name = "AlgDataGrid";
            this.AlgDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.AlgDataGrid.RowHeadersVisible = false;
            this.AlgDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.AlgDataGrid.ShowEditingIcon = false;
            this.AlgDataGrid.Size = new System.Drawing.Size(227, 313);
            this.AlgDataGrid.TabIndex = 48;
            this.AlgDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AlgDataGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Correo:";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(128, 208);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(287, 20);
            this.txtemail.TabIndex = 49;
            // 
            // ModifyUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 405);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.AlgDataGrid);
            this.Controls.Add(this.GpxAlg);
            this.Controls.Add(this.ComboboxType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblBDate);
            this.Controls.Add(this.lblSSurname);
            this.Controls.Add(this.txtFNac);
            this.Controls.Add(this.txtSApl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblFSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFApl);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModifyUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar usuario";
            splAlg.Panel1.ResumeLayout(false);
            splAlg.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splAlg)).EndInit();
            splAlg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GpxAlg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlgDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblFSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFApl;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtFNac;
        public System.Windows.Forms.TextBox txtSApl;
        private System.Windows.Forms.Label lblSSurname;
        private System.Windows.Forms.Label lblBDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox ComboboxType;
        private System.Windows.Forms.GroupBox GpxAlg;
        private System.Windows.Forms.FlowLayoutPanel algContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddAlg;
        private System.Windows.Forms.DataGridView AlgDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Button btnDelete;
    }
}