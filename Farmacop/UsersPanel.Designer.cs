namespace Farmacop
{
    partial class UsersPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbxApl = new System.Windows.Forms.TextBox();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.txtbxAccount = new System.Windows.Forms.TextBox();
            this.lblApl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.UsersGridView = new System.Windows.Forms.DataGridView();
            this.chbxDisUsers = new System.Windows.Forms.CheckBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxApl);
            this.groupBox1.Controls.Add(this.txtbxName);
            this.groupBox1.Controls.Add(this.txtbxAccount);
            this.groupBox1.Controls.Add(this.lblApl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Location = new System.Drawing.Point(36, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar";
            // 
            // txtbxApl
            // 
            this.txtbxApl.Location = new System.Drawing.Point(106, 86);
            this.txtbxApl.Name = "txtbxApl";
            this.txtbxApl.Size = new System.Drawing.Size(232, 20);
            this.txtbxApl.TabIndex = 10;
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(106, 56);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(232, 20);
            this.txtbxName.TabIndex = 9;
            // 
            // txtbxAccount
            // 
            this.txtbxAccount.Location = new System.Drawing.Point(106, 26);
            this.txtbxAccount.Name = "txtbxAccount";
            this.txtbxAccount.Size = new System.Drawing.Size(232, 20);
            this.txtbxAccount.TabIndex = 8;
            // 
            // lblApl
            // 
            this.lblApl.AutoSize = true;
            this.lblApl.Location = new System.Drawing.Point(48, 89);
            this.lblApl.Name = "lblApl";
            this.lblApl.Size = new System.Drawing.Size(52, 13);
            this.lblApl.TabIndex = 7;
            this.lblApl.Text = "Apellidos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre de cuenta:";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(393, 53);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Aplicar filtro";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // UsersGridView
            // 
            this.UsersGridView.AllowUserToAddRows = false;
            this.UsersGridView.AllowUserToDeleteRows = false;
            this.UsersGridView.AllowUserToResizeRows = false;
            this.UsersGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.UsersGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsersGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.UsersGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.UsersGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.UsersGridView.Location = new System.Drawing.Point(79, 218);
            this.UsersGridView.MultiSelect = false;
            this.UsersGridView.Name = "UsersGridView";
            this.UsersGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.UsersGridView.RowHeadersVisible = false;
            this.UsersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.UsersGridView.ShowEditingIcon = false;
            this.UsersGridView.Size = new System.Drawing.Size(841, 335);
            this.UsersGridView.TabIndex = 2;
            this.UsersGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersGridView_CellContentClick);
            // 
            // chbxDisUsers
            // 
            this.chbxDisUsers.AutoSize = true;
            this.chbxDisUsers.Location = new System.Drawing.Point(90, 195);
            this.chbxDisUsers.Name = "chbxDisUsers";
            this.chbxDisUsers.Size = new System.Drawing.Size(173, 17);
            this.chbxDisUsers.TabIndex = 4;
            this.chbxDisUsers.Text = "Mostrar usuarios deshabilitados";
            this.chbxDisUsers.UseVisualStyleBackColor = true;
            this.chbxDisUsers.CheckedChanged += new System.EventHandler(this.chbxDisUsers_CheckedChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(193, 154);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(113, 23);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.Text = "Agregar usuario";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // UsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.UsersGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chbxDisUsers);
            this.Name = "UsersPanel";
            this.Size = new System.Drawing.Size(991, 729);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView UsersGridView;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chbxDisUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblApl;
        private System.Windows.Forms.TextBox txtbxApl;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.TextBox txtbxAccount;
        private System.Windows.Forms.Button btnAddUser;
    }
}
