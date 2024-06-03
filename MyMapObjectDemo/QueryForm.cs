using MyMapObjects;
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
    public partial class QueryForm : Form
    {
        #region 字段

        private MyMapObjects.moMapLayer _mapLayer; // 地图图层
        private moMapControl _mapControl; // 地图控件

        #endregion

        #region 构造函数

        public QueryForm(MyMapObjects.moMapLayer mapLayer, moMapControl mapControl)
        {
            InitializeComponent();
            _mapLayer = mapLayer;
            _mapControl = mapControl;
            LoadFields();
        }
        #endregion

        #region
        private void LoadFields()
        {
            cmbField.Items.Clear();
            foreach (var field in _mapLayer.AttributeFields)
            {
                cmbField.Items.Add(field.Name);
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFieldValues();
            if (cmbField.SelectedItem != null)
            {
                txtCondition.Text = $"\"{cmbField.SelectedItem}\" ";
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                txtCondition.Text += listBox1.SelectedItem.ToString();
            }
        }
        private void LoadFieldValues()
        {
            listBox1.Items.Clear();
            if (cmbField.SelectedItem == null) return;

            var selectedFieldName = cmbField.SelectedItem.ToString();
            var fieldIndex = _mapLayer.AttributeFields.FindField(selectedFieldName);

            var distinctValues = new HashSet<string>();
            for (int i = 0; i < _mapLayer.Features.Count; i++)
            {
                var feature = _mapLayer.Features.GetItem(i);
                var fieldValue = $"'{feature.Attributes.GetItem(fieldIndex).ToString()}'";
                distinctValues.Add(fieldValue);
            }

            listBox1.Items.AddRange(distinctValues.ToArray());
        }

        private void AddCondition(string conditionOperator)
        {
            if (cmbField.SelectedItem == null || string.IsNullOrEmpty(txtValue.Text)) return;

            var selectedFieldName = cmbField.SelectedItem.ToString();
            var value = txtValue.Text;
            if (string.IsNullOrEmpty(txtCondition.Text))
            {
                txtCondition.Text = $"\"{selectedFieldName}\" {conditionOperator} '{value}'";
            }
            else
            {
                txtCondition.Text += $" {conditionOperator} \"{selectedFieldName}\" {conditionOperator} '{value}'";
            }
        }

        private void ApplyQuery()
        {
            if (cmbField.SelectedItem == null) return;

            var query = txtCondition.Text.Trim();
            var selectedFieldName = cmbField.SelectedItem.ToString();
            var fieldIndex = _mapLayer.AttributeFields.FindField(selectedFieldName);

            if (fieldIndex >= 0)
            {
                _mapLayer.ClearSelection();
                foreach (var feature in _mapLayer.Features)
                {
                    var fieldValue = feature.Attributes.GetItem(fieldIndex).ToString();
                    if (EvaluateCondition(feature, query))
                    {
                        _mapLayer.SelectedFeatures.Add(feature);
                    }
                }
                _mapControl.RedrawTrackingShapes();
                HighlightSelectedFeatures();
            }
        }
        private void HighlightSelectedFeatures()
        {
            var selectedFeatures = _mapLayer.SelectedFeatures;
            var drawingTool = _mapControl.GetDrawingTool();

            foreach (var feature in selectedFeatures)
            {
                if (feature.Geometry is moMultiPolygon polygon)
                {
                    drawingTool.DrawMultiPolygon(polygon, new moSimpleFillSymbol()
                    {
                        Color = Color.Transparent, // No fill color
                        Outline = new moSimpleLineSymbol() { Color = Color.Red, Size = 1 }
                    });
                }
                // Handle other geometry types if needed
            }
        }
        private bool EvaluateCondition(moFeature feature, string condition)
        {
            var conditions = condition.Split(new[] { " AND ", " OR " }, StringSplitOptions.None);
            foreach (var cond in conditions)
            {
                var parts = cond.Split(new[] { ' ' }, 3);
                if (parts.Length != 3) return false;

                var fieldName = parts[0].Trim('"');
                var operatorSymbol = parts[1];
                var value = parts[2].Trim('\'');

                var fieldIndex = _mapLayer.AttributeFields.FindField(fieldName);
                var fieldValue = feature.Attributes.GetItem(fieldIndex).ToString();

                switch (operatorSymbol)
                {
                    case "=":
                        if (fieldValue != value) return false;
                        break;
                    case "!=":
                        if (fieldValue == value) return false;
                        break;
                    case "LIKE":
                        if (!fieldValue.Contains(value)) return false;
                        break;
                    case ">":
                        if (double.TryParse(fieldValue, out double fieldValueParsed) && double.TryParse(value, out double valueParsed))
                        {
                            if (fieldValueParsed <= valueParsed) return false;
                        }
                        break;
                    case "<":
                        if (double.TryParse(fieldValue, out fieldValueParsed) && double.TryParse(value, out valueParsed))
                        {
                            if (fieldValueParsed >= valueParsed) return false;
                        }
                        break;
                    default:
                        return false;
                }
            }

            return true;
        }
        #endregion

        #region
        private void QueryForm_Load(object sender, EventArgs e)
        {
            LoadFields();
            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyQuery();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyQuery();
            CloseForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();

        }
        #endregion

        private void txtCondition_TextChanged(object sender, EventArgs e)
        {
            txtCondition.Height = 500;
            txtCondition.Width = 400;
        }

        private void btnAnd_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "AND ";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "= ";
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "OR ";
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "NOT ";
        }

        private void lblQuery_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() != "Search...")
            {
                txtCondition.Text += $"'{listBox1.SelectedItem.ToString()}'";
            }
        }

        private void CloseForm()
        {
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngreater_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "> ";
        }

        private void btnless_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "< ";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "<> ";
        }

        private void btngraterqual_Click(object sender, EventArgs e)
        {
            txtCondition.Text += ">= ";
        }

        private void btnlessequal_Click(object sender, EventArgs e)
        {
            txtCondition.Text += "<= ";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
