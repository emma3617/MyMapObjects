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

        public QueryForm(MyMapObjects.moMapLayer mapLayer)
        {
            InitializeComponent();
            _mapLayer = mapLayer;
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

        private void ApplyQuery()
        {
            var selectedFieldName = cmbField.SelectedItem.ToString();
            var condition = txtCondition.Text;

            var fieldIndex = _mapLayer.AttributeFields.FindField(selectedFieldName);
            if (fieldIndex >= 0)
            {
                _mapLayer.ClearSelection();
                for (int i = 0; i < _mapLayer.Features.Count; i++)
                {
                    var feature = _mapLayer.Features.GetItem(i);
                    var fieldValue = feature.Attributes.GetItem(fieldIndex).ToString();
                    if (EvaluateCondition(fieldValue, condition))
                    {
                        _mapLayer.SelectedFeatures.Add(feature);
                    }
                }
                _mapControl.RedrawTrackingShapes();
            }
        }
        private bool EvaluateCondition(string fieldValue, string condition)
        {
            return fieldValue.Contains(condition);
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
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
