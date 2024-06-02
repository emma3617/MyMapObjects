using System.Windows.Forms;

namespace MyMapObjectDemo
{
    partial class QueryForm
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
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btngreater = new System.Windows.Forms.Button();
            this.btnless = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btngraterqual = new System.Windows.Forms.Button();
            this.btnlessequal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbField
            // 
            this.cmbField.DropDownHeight = 120;
            this.cmbField.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.IntegralHeight = false;
            this.cmbField.ItemHeight = 20;
            this.cmbField.Location = new System.Drawing.Point(88, 34);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(124, 28);
            this.cmbField.TabIndex = 1;
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // txtCondition
            // 
            this.txtCondition.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCondition.Location = new System.Drawing.Point(63, 201);
            this.txtCondition.Margin = new System.Windows.Forms.Padding(5);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(300, 27);
            this.txtCondition.TabIndex = 2;
            this.txtCondition.TextChanged += new System.EventHandler(this.txtCondition_TextChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(196, 265);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "套用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(301, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(406, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEqual.Location = new System.Drawing.Point(63, 86);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(49, 23);
            this.btnEqual.TabIndex = 6;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(172, 85);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(79, 23);
            this.btnAnd.TabIndex = 7;
            this.btnAnd.Text = "And";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(172, 144);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(79, 23);
            this.btnOr.TabIndex = 8;
            this.btnOr.Text = "Or";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(172, 115);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(79, 23);
            this.btnNot.TabIndex = 9;
            this.btnNot.Text = "Not";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(278, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(172, 137);
            this.listBox1.TabIndex = 10;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(61, 184);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(175, 12);
            this.lblQuery.TabIndex = 11;
            this.lblQuery.Text = "SELECT * FROM express WHERE:";
            this.lblQuery.Click += new System.EventHandler(this.lblQuery_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(381, 201);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 22);
            this.txtValue.TabIndex = 12;
            this.txtValue.Visible = false;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // btngreater
            // 
            this.btngreater.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btngreater.Location = new System.Drawing.Point(63, 115);
            this.btngreater.Name = "btngreater";
            this.btngreater.Size = new System.Drawing.Size(49, 23);
            this.btngreater.TabIndex = 13;
            this.btngreater.Text = ">";
            this.btngreater.UseVisualStyleBackColor = true;
            this.btngreater.Click += new System.EventHandler(this.btngreater_Click);
            // 
            // btnless
            // 
            this.btnless.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnless.Location = new System.Drawing.Point(63, 144);
            this.btnless.Name = "btnless";
            this.btnless.Size = new System.Drawing.Size(49, 23);
            this.btnless.TabIndex = 14;
            this.btnless.Text = "<";
            this.btnless.UseVisualStyleBackColor = true;
            this.btnless.Click += new System.EventHandler(this.btnless_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn1.Location = new System.Drawing.Point(118, 86);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(49, 23);
            this.btn1.TabIndex = 15;
            this.btn1.Text = "<>";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btngraterqual
            // 
            this.btngraterqual.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btngraterqual.Location = new System.Drawing.Point(118, 116);
            this.btngraterqual.Name = "btngraterqual";
            this.btngraterqual.Size = new System.Drawing.Size(49, 23);
            this.btngraterqual.TabIndex = 16;
            this.btngraterqual.Text = ">=";
            this.btngraterqual.UseVisualStyleBackColor = true;
            this.btngraterqual.Click += new System.EventHandler(this.btngraterqual_Click);
            // 
            // btnlessequal
            // 
            this.btnlessequal.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnlessequal.Location = new System.Drawing.Point(118, 145);
            this.btnlessequal.Name = "btnlessequal";
            this.btnlessequal.Size = new System.Drawing.Size(49, 23);
            this.btnlessequal.TabIndex = 17;
            this.btnlessequal.Text = "<=";
            this.btnlessequal.UseVisualStyleBackColor = true;
            this.btnlessequal.Click += new System.EventHandler(this.btnlessequal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "请选择栏位";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlessequal);
            this.Controls.Add(this.btngraterqual);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnless);
            this.Controls.Add(this.btngreater);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnNot);
            this.Controls.Add(this.btnOr);
            this.Controls.Add(this.btnAnd);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.cmbField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "QueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryForm";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Button btnEqual;
        private Button btnAnd;
        private Button btnOr;
        private Button btnNot;
        private ListBox listBox1;
        private Label lblQuery;
        private TextBox txtValue;
        private Button btngreater;
        private Button btnless;
        private Button btn1;
        private Button btngraterqual;
        private Button btnlessequal;
        private Label label1;
    }
}