using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMapObjectDemo
{
    public partial class FieldSelectionForm : Form
    {
        public string SelectedField { get; private set; }
        public FieldSelectionForm(List<string> fields)
        {
            InitializeComponents(fields);
        }
        private void InitializeComponents(List<string> fields)
        {
            this.Text = "选择字段";
            this.Size = new Size(300, 150);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // 設置視窗初始化位置為螢幕中間

            comboBoxFields = new ComboBox();
            comboBoxFields.Location = new Point(20, 20);
            comboBoxFields.Width = 240;
            comboBoxFields.Items.AddRange(fields.ToArray());
            comboBoxFields.SelectedIndex = 0;
            this.Controls.Add(comboBoxFields);

            btnOk = new Button();
            btnOk.Text = "确定";
            btnOk.Location = new Point(100, 60);
            btnOk.Click += btnOk_Click;
            this.Controls.Add(btnOk);
        }

        private void comboBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedField = comboBoxFields.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
