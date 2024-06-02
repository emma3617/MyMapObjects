namespace MyMapObjectDemo
{
    partial class moMapRenender
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.btnChooseColor1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxFields2 = new System.Windows.Forms.ListBox();
            this.btnChooseColor2 = new System.Windows.Forms.Button();
            this.textBoxClassBreaks = new System.Windows.Forms.TextBox();
            this.comboBoxField2 = new System.Windows.Forms.ComboBox();
            this.panelColor2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBoxFields3 = new System.Windows.Forms.ListBox();
            this.btnChooseColor3 = new System.Windows.Forms.Button();
            this.comboBoxField3 = new System.Windows.Forms.ComboBox();
            this.panelColor3 = new System.Windows.Forms.Panel();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBoxSymbolType = new System.Windows.Forms.ComboBox();
            this.panelSymbolColor = new System.Windows.Forms.Panel();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.comboBoxLineStyle = new System.Windows.Forms.ComboBox();
            this.comboBoxLayer = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonApplySymbol = new System.Windows.Forms.Button();
            this.comboBoxStyle = new System.Windows.Forms.ComboBox();
            this.labelStyle = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelColor1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(7, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelColor1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panelColor1
            // 
            this.panelColor1.Controls.Add(this.btnChooseColor1);
            this.panelColor1.Location = new System.Drawing.Point(319, 94);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(277, 158);
            this.panelColor1.TabIndex = 1;
            this.panelColor1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelColor1_Paint);
            // 
            // btnChooseColor1
            // 
            this.btnChooseColor1.Location = new System.Drawing.Point(168, 97);
            this.btnChooseColor1.Name = "btnChooseColor1";
            this.btnChooseColor1.Size = new System.Drawing.Size(75, 23);
            this.btnChooseColor1.TabIndex = 0;
            this.btnChooseColor1.Text = "选择颜色";
            this.btnChooseColor1.UseVisualStyleBackColor = true;
            this.btnChooseColor1.Click += new System.EventHandler(this.btnChooseColor1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxFields2);
            this.tabPage2.Controls.Add(this.btnChooseColor2);
            this.tabPage2.Controls.Add(this.textBoxClassBreaks);
            this.tabPage2.Controls.Add(this.comboBoxField2);
            this.tabPage2.Controls.Add(this.panelColor2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(624, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxFields2
            // 
            this.listBoxFields2.FormattingEnabled = true;
            this.listBoxFields2.ItemHeight = 12;
            this.listBoxFields2.Location = new System.Drawing.Point(518, 14);
            this.listBoxFields2.Name = "listBoxFields2";
            this.listBoxFields2.Size = new System.Drawing.Size(86, 28);
            this.listBoxFields2.TabIndex = 5;
            this.listBoxFields2.Visible = false;
            this.listBoxFields2.SelectedIndexChanged += new System.EventHandler(this.listBoxFields2_SelectedIndexChanged);
            // 
            // btnChooseColor2
            // 
            this.btnChooseColor2.Location = new System.Drawing.Point(529, 291);
            this.btnChooseColor2.Name = "btnChooseColor2";
            this.btnChooseColor2.Size = new System.Drawing.Size(75, 23);
            this.btnChooseColor2.TabIndex = 1;
            this.btnChooseColor2.Text = "选择颜色";
            this.btnChooseColor2.UseVisualStyleBackColor = true;
            this.btnChooseColor2.Click += new System.EventHandler(this.btnChooseColor2_Click);
            // 
            // textBoxClassBreaks
            // 
            this.textBoxClassBreaks.Location = new System.Drawing.Point(504, 88);
            this.textBoxClassBreaks.Name = "textBoxClassBreaks";
            this.textBoxClassBreaks.Size = new System.Drawing.Size(100, 22);
            this.textBoxClassBreaks.TabIndex = 4;
            this.textBoxClassBreaks.Visible = false;
            this.textBoxClassBreaks.TextChanged += new System.EventHandler(this.textBoxClassBreaks_TextChanged);
            // 
            // comboBoxField2
            // 
            this.comboBoxField2.FormattingEnabled = true;
            this.comboBoxField2.Location = new System.Drawing.Point(495, 53);
            this.comboBoxField2.Name = "comboBoxField2";
            this.comboBoxField2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxField2.TabIndex = 3;
            this.comboBoxField2.Visible = false;
            this.comboBoxField2.SelectedIndexChanged += new System.EventHandler(this.comboBoxField2_SelectedIndexChanged);
            // 
            // panelColor2
            // 
            this.panelColor2.Location = new System.Drawing.Point(495, 154);
            this.panelColor2.Name = "panelColor2";
            this.panelColor2.Size = new System.Drawing.Size(96, 88);
            this.panelColor2.TabIndex = 2;
            this.panelColor2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelColor2_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBoxFields3);
            this.tabPage3.Controls.Add(this.btnChooseColor3);
            this.tabPage3.Controls.Add(this.comboBoxField3);
            this.tabPage3.Controls.Add(this.panelColor3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(624, 325);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBoxFields3
            // 
            this.listBoxFields3.FormattingEnabled = true;
            this.listBoxFields3.ItemHeight = 12;
            this.listBoxFields3.Location = new System.Drawing.Point(541, 36);
            this.listBoxFields3.Name = "listBoxFields3";
            this.listBoxFields3.Size = new System.Drawing.Size(61, 28);
            this.listBoxFields3.TabIndex = 4;
            this.listBoxFields3.Visible = false;
            this.listBoxFields3.SelectedIndexChanged += new System.EventHandler(this.listBoxFields3_SelectedIndexChanged);
            // 
            // btnChooseColor3
            // 
            this.btnChooseColor3.Location = new System.Drawing.Point(525, 274);
            this.btnChooseColor3.Name = "btnChooseColor3";
            this.btnChooseColor3.Size = new System.Drawing.Size(75, 23);
            this.btnChooseColor3.TabIndex = 0;
            this.btnChooseColor3.Text = "选择颜色";
            this.btnChooseColor3.UseVisualStyleBackColor = true;
            this.btnChooseColor3.Click += new System.EventHandler(this.btnChooseColor3_Click);
            // 
            // comboBoxField3
            // 
            this.comboBoxField3.FormattingEnabled = true;
            this.comboBoxField3.Location = new System.Drawing.Point(481, 10);
            this.comboBoxField3.Name = "comboBoxField3";
            this.comboBoxField3.Size = new System.Drawing.Size(121, 20);
            this.comboBoxField3.TabIndex = 3;
            this.comboBoxField3.Visible = false;
            this.comboBoxField3.SelectedIndexChanged += new System.EventHandler(this.comboBoxField3_SelectedIndexChanged);
            // 
            // panelColor3
            // 
            this.panelColor3.Location = new System.Drawing.Point(402, 218);
            this.panelColor3.Name = "panelColor3";
            this.panelColor3.Size = new System.Drawing.Size(94, 79);
            this.panelColor3.TabIndex = 2;
            this.panelColor3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelColor3_Paint);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(462, 367);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "确定";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(552, 367);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 23);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "取消";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // comboBoxSymbolType
            // 
            this.comboBoxSymbolType.FormattingEnabled = true;
            this.comboBoxSymbolType.Location = new System.Drawing.Point(345, 55);
            this.comboBoxSymbolType.Name = "comboBoxSymbolType";
            this.comboBoxSymbolType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSymbolType.TabIndex = 0;
            this.comboBoxSymbolType.Visible = false;
            this.comboBoxSymbolType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSymbolType_SelectedIndexChanged_1);
            // 
            // panelSymbolColor
            // 
            this.panelSymbolColor.Location = new System.Drawing.Point(345, 95);
            this.panelSymbolColor.Name = "panelSymbolColor";
            this.panelSymbolColor.Size = new System.Drawing.Size(105, 100);
            this.panelSymbolColor.TabIndex = 1;
            this.panelSymbolColor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSymbolColor_Paint);
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(481, 56);
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownSize.TabIndex = 2;
            this.numericUpDownSize.Visible = false;
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);
            // 
            // comboBoxLineStyle
            // 
            this.comboBoxLineStyle.FormattingEnabled = true;
            this.comboBoxLineStyle.Location = new System.Drawing.Point(481, 95);
            this.comboBoxLineStyle.Name = "comboBoxLineStyle";
            this.comboBoxLineStyle.Size = new System.Drawing.Size(121, 20);
            this.comboBoxLineStyle.TabIndex = 3;
            this.comboBoxLineStyle.Visible = false;
            this.comboBoxLineStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxLineStyle_SelectedIndexChanged);
            // 
            // comboBoxLayer
            // 
            this.comboBoxLayer.FormattingEnabled = true;
            this.comboBoxLayer.Location = new System.Drawing.Point(345, 16);
            this.comboBoxLayer.Name = "comboBoxLayer";
            this.comboBoxLayer.Size = new System.Drawing.Size(121, 20);
            this.comboBoxLayer.TabIndex = 4;
            this.comboBoxLayer.Visible = false;
            this.comboBoxLayer.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayer_SelectedIndexChanged_1);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.labelColor);
            this.tabPage4.Controls.Add(this.labelSize);
            this.tabPage4.Controls.Add(this.labelStyle);
            this.tabPage4.Controls.Add(this.comboBoxStyle);
            this.tabPage4.Controls.Add(this.buttonApplySymbol);
            this.tabPage4.Controls.Add(this.comboBoxLayer);
            this.tabPage4.Controls.Add(this.comboBoxLineStyle);
            this.tabPage4.Controls.Add(this.numericUpDownSize);
            this.tabPage4.Controls.Add(this.panelSymbolColor);
            this.tabPage4.Controls.Add(this.comboBoxSymbolType);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(624, 325);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonApplySymbol
            // 
            this.buttonApplySymbol.Location = new System.Drawing.Point(451, 282);
            this.buttonApplySymbol.Name = "buttonApplySymbol";
            this.buttonApplySymbol.Size = new System.Drawing.Size(75, 23);
            this.buttonApplySymbol.TabIndex = 5;
            this.buttonApplySymbol.Text = "应用";
            this.buttonApplySymbol.UseVisualStyleBackColor = true;
            this.buttonApplySymbol.Visible = false;
            this.buttonApplySymbol.Click += new System.EventHandler(this.buttonApplySymbol_Click);
            // 
            // comboBoxStyle
            // 
            this.comboBoxStyle.FormattingEnabled = true;
            this.comboBoxStyle.Location = new System.Drawing.Point(481, 146);
            this.comboBoxStyle.Name = "comboBoxStyle";
            this.comboBoxStyle.Size = new System.Drawing.Size(121, 20);
            this.comboBoxStyle.TabIndex = 6;
            this.comboBoxStyle.Visible = false;
            this.comboBoxStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxStyle_SelectedIndexChanged);
            // 
            // labelStyle
            // 
            this.labelStyle.AutoSize = true;
            this.labelStyle.Location = new System.Drawing.Point(271, 16);
            this.labelStyle.Name = "labelStyle";
            this.labelStyle.Size = new System.Drawing.Size(33, 12);
            this.labelStyle.TabIndex = 7;
            this.labelStyle.Text = "label1";
            this.labelStyle.Visible = false;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(273, 65);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(33, 12);
            this.labelSize.TabIndex = 8;
            this.labelSize.Text = "label1";
            this.labelSize.Visible = false;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(499, 188);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(33, 12);
            this.labelColor.TabIndex = 9;
            this.labelColor.Text = "label1";
            // 
            // moMapRenender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 402);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "moMapRenender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图层渲染";
            this.Load += new System.EventHandler(this.moMapRenender_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelColor1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnChooseColor1;
        private System.Windows.Forms.Button btnChooseColor2;
        private System.Windows.Forms.Button btnChooseColor3;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.Panel panelColor2;
        private System.Windows.Forms.Panel panelColor3;
        private System.Windows.Forms.ComboBox comboBoxField2;
        private System.Windows.Forms.ComboBox comboBoxField3;
        private System.Windows.Forms.TextBox textBoxClassBreaks;
        private System.Windows.Forms.ListBox listBoxFields3;
        private System.Windows.Forms.ListBox listBoxFields2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox comboBoxLayer;
        private System.Windows.Forms.ComboBox comboBoxLineStyle;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Panel panelSymbolColor;
        private System.Windows.Forms.ComboBox comboBoxSymbolType;
        private System.Windows.Forms.Button buttonApplySymbol;
        private System.Windows.Forms.ComboBox comboBoxStyle;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelStyle;
        private System.Windows.Forms.Label labelColor;
    }
}