namespace MyMapObjectDemo
{
    partial class frmLayerAttributes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.btnDeleteField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 38);
            this.panel1.TabIndex = 0;
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AllowUserToDeleteRows = false;
            this.dgvAttributes.AllowUserToResizeRows = false;
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributes.Location = new System.Drawing.Point(0, 32);
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.RowTemplate.Height = 24;
            this.dgvAttributes.Size = new System.Drawing.Size(690, 363);
            this.dgvAttributes.TabIndex = 1;
            this.dgvAttributes.VirtualMode = true;
            this.dgvAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttributes_CellContentClick);
            this.dgvAttributes.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvAttributes_CellValueNeeded);
            this.dgvAttributes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttributes_ColumnHeaderMouseClick);
            this.dgvAttributes.SelectionChanged += new System.EventHandler(this.dgvAttributes_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteField);
            this.panel2.Controls.Add(this.btnAddField);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 32);
            this.panel2.TabIndex = 2;
            // 
            // btnEditSave
            // 
            this.btnEditSave.Location = new System.Drawing.Point(336, 3);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(75, 23);
            this.btnEditSave.TabIndex = 2;
            this.btnEditSave.Text = "储存编辑";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // btnDeleteField
            // 
            this.btnDeleteField.Location = new System.Drawing.Point(527, 4);
            this.btnDeleteField.Name = "btnDeleteField";
            this.btnDeleteField.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteField.TabIndex = 1;
            this.btnDeleteField.Text = "删除栏位";
            this.btnDeleteField.UseVisualStyleBackColor = true;
            this.btnDeleteField.Click += new System.EventHandler(this.btnDeleteField_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(432, 4);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(75, 23);
            this.btnAddField.TabIndex = 0;
            this.btnAddField.Text = "增加栏位";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click_1);
            // 
            // frmLayerAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 433);
            this.Controls.Add(this.btnEditSave);
            this.Controls.Add(this.dgvAttributes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmLayerAttributes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图层属性栏位";
            this.Load += new System.EventHandler(this.frmLayerAttributes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnDeleteField;
        private System.Windows.Forms.Button btnEditSave;
    }
}