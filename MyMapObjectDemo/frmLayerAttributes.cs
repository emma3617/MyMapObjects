using MyMapObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMapObjectDemo
{

    public partial class frmLayerAttributes : Form
    {

        #region 字段

        private MyMapObjects.moMapLayer _Layer;
        private bool mChangeByUser = true;  //改變是否由用戶發起，用戶網格控件的事件處理
        private ContextMenuStrip columnHeaderContextMenu;
        private MyMapObjects.moFeature _Feature;
        private bool _IsFromIdentify = false;
        private MyMapObjects.moFeature _SelectedFeature;
        private FrmMap _parentForm;
        public MyMapObjects.moMapLayer Layer => _Layer;


        #endregion

        #region 構造函數
        public frmLayerAttributes(FrmMap parentForm)
        {
            InitializeComponent();
            InitializeContextMenu();
            _parentForm = parentForm;
            dgvAttributes.CellValueNeeded += dgvAttributes_CellValueNeeded;
            dgvAttributes.CellValuePushed += dgvAttributes_CellValuePushed;
            dgvAttributes.SelectionChanged += dgvAttributes_SelectionChanged;
            dgvAttributes.ColumnHeaderMouseClick += dgvAttributes_ColumnHeaderMouseClick;
        }
        #endregion


        #region 方法
        //設置數據
        internal void SetData(MyMapObjects.moMapLayer layer, MyMapObjects.moFeature selectedFeature = null)
        {
            _Layer = layer;
            _SelectedFeature = selectedFeature;
            ShowAttributes();
        }

        //獲取圖層
        internal MyMapObjects.moMapLayer GetLayer()
        {
            return _Layer;
        }

        //收到通知，圖層發生了變化(如圖層名稱等)
        internal void NotifiedLayerChanged(object sender)
        {
            //不再編寫
        }

        //收到通知，字段發生了變化(如字段名稱、是否顯示別名等)
        internal void NotifiedFieldsChanged(object sender)
        {
            //不再編寫
        }

        //收到通知，字段樹木發生了變化(如增加、刪除了字段)
        internal void NotifiedFieldCountChanged(object sender)
        {
            //不再編寫
        }

        //收到通知，選擇發生了變化
        internal void NotifiedFeatureSelectionChanged(object sender)
        {
            mChangeByUser = false;
            SetRowSelection();
            mChangeByUser = true;
        }

        #endregion


        #region 窗體與控件事件處理
        //裝載窗體
        private void frmLayerAttributes_Load(object sender, EventArgs e)
        {
            mChangeByUser = false;
            ShowFormTitle();
            CreateColumns();
            SetColumnTexts();
            LoadAttributesFromFile(); // 加載保存的屬性數據
            CreateRows();
            SetRowSelection();
            mChangeByUser = true;
        }
        private void LoadAttributesFromFile()
        {
            string filePath = $"{_Layer.Name}_Attributes.csv";

            if (!File.Exists(filePath))
                return;

            using (StreamReader reader = new StreamReader(filePath))
            {
                // 跳過標題行
                string headerLine = reader.ReadLine();
                if (headerLine == null)
                    return;

                // 讀取屬性數據
                string line;
                int featureIndex = 0;
                while ((line = reader.ReadLine()) != null && featureIndex < _Layer.Features.Count)
                {
                    string[] values = line.Split(',');

                    MyMapObjects.moFeature feature = _Layer.Features.GetItem(featureIndex);
                    for (int i = 0; i < values.Length && i < feature.Attributes.Count; i++)
                    {
                        feature.Attributes.SetItem(i, values[i]);
                    }

                    featureIndex++;
                }
            }
        }
        //需要顯示值
        private void dgvAttributes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            int sColumnIndex = e.ColumnIndex;
            int sRowIndex = e.RowIndex;
            if (sColumnIndex < 0 || sRowIndex < 0)
                return;
            MyMapObjects.moFeature sFeature = _Layer.Features.GetItem(sRowIndex);
            object sValue = sFeature.Attributes.GetItem(sColumnIndex);
            e.Value = sValue?.ToString() ?? string.Empty;
        }
        private void dgvAttributes_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            int sColumnIndex = e.ColumnIndex;
            int sRowIndex = e.RowIndex;
            if (sColumnIndex < 0 || sRowIndex < 0)
                return;
            MyMapObjects.moFeature sFeature = _Layer.Features.GetItem(sRowIndex);
            sFeature.Attributes.SetItem(sColumnIndex, e.Value.ToString());
        }

        //選擇發生了變化 0516 1:09:00
        private void dgvAttributes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAttributes.SelectedRows.Count > 0)
            {
                MyMapObjects.moFeatures sSelectedFeatures = new MyMapObjects.moFeatures();
                foreach (DataGridViewRow row in dgvAttributes.SelectedRows)
                {
                    int rowIndex = row.Index;
                    MyMapObjects.moFeature selectedFeature = _Layer.Features.GetItem(rowIndex);
                    sSelectedFeatures.Add(selectedFeature);
                }
                _Layer.SelectedFeatures = sSelectedFeatures;
                ToNotifyFeatureSelectionChanged();
            }
        }
        private void btnAddField_Click_1(object sender, EventArgs e)
        {
            string fieldName = Prompt.ShowDialog("请输入栏位名称:", "Add Field");
            if (!string.IsNullOrEmpty(fieldName))
            {
                MyMapObjects.moField newField = new MyMapObjects.moField(fieldName, MyMapObjects.moValueTypeConstant.dText);
                _Layer.AttributeFields.Append(newField);

                foreach (MyMapObjects.moFeature feature in _Layer.Features)
                {
                    feature.Attributes.Append("");
                }

                RefreshGrid(); // 更新 DataGridView
            }

        }
        private void btnDeleteField_Click(object sender, EventArgs e)
        {
            if (dgvAttributes.SelectedCells.Count > 0)
            {
                int columnIndex = dgvAttributes.SelectedCells[0].ColumnIndex;
                DeleteField(columnIndex);
            }
        }
        
        private void DeleteFieldMenuItem_Click(object sender, EventArgs e)
        {
            int columnIndex;
            if (columnHeaderContextMenu.Tag != null)
            {
                columnIndex = (int)columnHeaderContextMenu.Tag;
            }
            else if (dgvAttributes.SelectedCells.Count > 0)
            {
                columnIndex = dgvAttributes.SelectedCells[0].ColumnIndex;
            }
            else
            {
                return;
            }
            var confirmResult = MessageBox.Show("确定删除该字段吗?", "确认删除", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteField(columnIndex);
            }
        }
       
        private void DeleteField(int columnIndex)
        {
            // 從每個要素的屬性集合中移除相應的值
            foreach (MyMapObjects.moFeature feature in _Layer.Features)
            {
                if (columnIndex < feature.Attributes.Count)
                {
                    feature.Attributes.RemoveAt(columnIndex);
                }
            }

            // 從圖層的屬性字段集合中移除該字段
            _Layer.AttributeFields.RemoveAt(columnIndex);

            // 從 DataGridView 中移除該列
            dgvAttributes.Columns.RemoveAt(columnIndex);

            // 更新 DataGridView
            RefreshGrid();
        }
        private void RemoveHiddenColumns()
        {
            List<int> hiddenColumns = new List<int>();

            for (int i = 0; i < dgvAttributes.Columns.Count; i++)
            {
                if (!dgvAttributes.Columns[i].Visible)
                {
                    hiddenColumns.Add(i);
                }
            }

            foreach (int columnIndex in hiddenColumns.OrderByDescending(c => c))
            {
                // 从图层的属性字段集合中移除该字段
                _Layer.AttributeFields.RemoveAt(columnIndex);

                // 从 DataGridView 中移除该列
                dgvAttributes.Columns.RemoveAt(columnIndex);
            }
        }



        private void dgvAttributes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dgvAttributes.ClearSelection();
                foreach (DataGridViewRow row in dgvAttributes.Rows)
                {
                    row.Cells[e.ColumnIndex].Selected = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                dgvAttributes.ClearSelection();
                dgvAttributes.Columns[e.ColumnIndex].Selected = true;
                columnHeaderContextMenu.Tag = e.ColumnIndex; // 存儲列索引
                columnHeaderContextMenu.Show(Cursor.Position);
            }

        }
        private void InitializeContextMenu()
        {
            columnHeaderContextMenu = new ContextMenuStrip();
            var deleteMenuItem = new ToolStripMenuItem("删除列");
            deleteMenuItem.Click += DeleteFieldMenuItem_Click;
            columnHeaderContextMenu.Items.Add(deleteMenuItem);
        }

        public void SetFeature(MyMapObjects.moFeature feature)
        {
            _Feature = feature;
            ShowAttributes();
        }

        private void ShowAttributes()
        {
            if (_Layer == null)
                return;

            dgvAttributes.Columns.Clear();
            dgvAttributes.Rows.Clear();

            MyMapObjects.moFields fields = _Layer.AttributeFields;

            // 添加列
            for (int i = 0; i < fields.Count; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                {
                    HeaderText = fields.GetItem(i).Name,
                    Name = fields.GetItem(i).Name
                };
                dgvAttributes.Columns.Add(column);
            }

            // 添加行
            for (int i = 0; i < _Layer.Features.Count; i++)
            {
                MyMapObjects.moFeature feature = _Layer.Features.GetItem(i);
                DataGridViewRow row = new DataGridViewRow();
                for (int j = 0; j < feature.Attributes.Count; j++)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell
                    {
                        Value = feature.Attributes.GetItem(j).ToString()
                    };
                    row.Cells.Add(cell);
                }
                dgvAttributes.Rows.Add(row);

                // 高亮指定要素
                if (_SelectedFeature != null && feature == _SelectedFeature)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.Selected = true;
                    dgvAttributes.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }

            // 設置 DataGridView 可編輯
            dgvAttributes.ReadOnly = false;
            foreach (DataGridViewColumn column in dgvAttributes.Columns)
            {
                column.ReadOnly = false; // 設置列可編輯
            }
            dgvAttributes.CellEndEdit += dgvAttributes_CellEndEdit;
        }
        private void dgvAttributes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 獲取編輯的行和列
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            // 獲取對應的要素和屬性字段
            MyMapObjects.moFeature feature = _Layer.Features.GetItem(rowIndex);
            MyMapObjects.moField field = _Layer.AttributeFields.GetItem(columnIndex);

            // 更新要素的屬性值
            string newValue = dgvAttributes.Rows[rowIndex].Cells[columnIndex].Value.ToString();
            feature.Attributes.SetItem(columnIndex, ConvertToFieldType(newValue, field.ValueType));

            // 通知地圖層屬性已更改
            _Layer.IsDirty = true;
        }
        private object ConvertToFieldType(string value, MyMapObjects.moValueTypeConstant valueType)
        {
            switch (valueType)
            {
                case MyMapObjects.moValueTypeConstant.dInt16:
                    return Int16.Parse(value);
                case MyMapObjects.moValueTypeConstant.dInt32:
                    return Int32.Parse(value);
                case MyMapObjects.moValueTypeConstant.dInt64:
                    return Int64.Parse(value);
                case MyMapObjects.moValueTypeConstant.dSingle:
                    return Single.Parse(value);
                case MyMapObjects.moValueTypeConstant.dDouble:
                    return Double.Parse(value);
                case MyMapObjects.moValueTypeConstant.dText:
                    return value;
                default:
                    throw new Exception("Invalid field value type!");
            }
        }

        #endregion



        #region 私有函數

        //顯示窗體標題
        private void ShowFormTitle()
        {
            this.Text = "屬性:" + _Layer.Name;
        }

        //生成所有列
        private void CreateColumns()
        {
            MyMapObjects.moFields sFields = _Layer.AttributeFields;
            int sFieldCount = sFields.Count;

            // 删除所有列
            dgvAttributes.Columns.Clear();

            // 根据字段数新建列
            for (int i = 0; i < sFieldCount; i++)
            {
                DataGridViewTextBoxColumn sColumn = new DataGridViewTextBoxColumn();
                sColumn.HeaderText = sFields.GetItem(i).Name; // 设置列头
                dgvAttributes.Columns.Add(sColumn);
            }
        }
        //設置列頭
        private void SetColumnTexts()
        {
            MyMapObjects.moFields sFields = _Layer.AttributeFields;
            int sFieldsCount = sFields.Count;
            for (int i = 0; i < sFieldsCount; i++)
            {
                string sColumnText = sFields.ShowAlias ? sFields.GetItem(i).AliasName : sFields.GetItem(i).Name;
                dgvAttributes.Columns[i].HeaderText = sColumnText;
            }
        }

        //增加行
        private void CreateRows()
        {
            // 刪除所有行
            dgvAttributes.Rows.Clear();

            // 根據要素數目增加行
            int sRowCount = _Layer.Features.Count;
            if (sRowCount > 0)
            {
                dgvAttributes.Rows.Add(sRowCount);
            }

            // 填充数据
            for (int i = 0; i < sRowCount; i++)
            {
                for (int j = 0; j < _Layer.AttributeFields.Count; j++)
                {
                    dgvAttributes.Rows[i].Cells[j].Value = _Layer.Features.GetItem(i).Attributes.GetItem(j)?.ToString();
                }
            }
        }

        //設置選擇行
        //0516 32:處
        private void SetRowSelection()
        {
            //先清除所有選擇行
            dgvAttributes.ClearSelection();
            //設置選擇行
            MyMapObjects.moFeatures sFeatures = _Layer.Features;
            MyMapObjects.moFeatures sSelectedFeatures = _Layer.SelectedFeatures;
            Int32 sSelectedCount = sSelectedFeatures.Count;
            for (Int32 i = 0; i <= sSelectedCount - 1; i++)
            {
                MyMapObjects.moFeature sFeature = sSelectedFeatures.GetItem(i);
                Int32 sIndex = GetFeatureIndex(sFeatures, sFeature);
                if (sIndex >= 0)
                {
                    dgvAttributes.Rows[sIndex].Selected = true;
                }
            }
        }

        //返回指定要素在要素集合中的索引好，如無，則返回-1
        private Int32 GetFeatureIndex(MyMapObjects.moFeatures features, MyMapObjects.moFeature feature)
        {
            Int32 sIndex = -1;
            Int32 sFeatureCount = features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                MyMapObjects.moFeature sFeature = features.GetItem(i);
                if (sFeature == feature)
                {
                    sIndex = i;
                    break;
                }
            }
            return sIndex;
        }
        private void RefreshGrid()
        {
            // 重新生成列
            CreateColumns();
            // 设置列标题
            SetColumnTexts();
            // 增加行
            CreateRows();
            // 设置选择行
            SetRowSelection();
        }

        //通知主窗體，選擇發生了變化
        private void ToNotifyFeatureSelectionChanged()
        {
            _parentForm.RedrawTrackingShapes();
        }

        #endregion
        // 顯示提示框的靜態類
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 10, Top = 20, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 10, Top = 50, Width = 250 };
                Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 80, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void dgvAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            SaveAttributesToLayer();
            MessageBox.Show("屬性資料已成功保存!", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SaveAttributesToLayer()
        {
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                if (row.IsNewRow) continue;

                int rowIndex = row.Index;
                MyMapObjects.moFeature feature = _Layer.Features.GetItem(rowIndex);

                for (int colIndex = 0; colIndex < dgvAttributes.Columns.Count; colIndex++)
                {
                    feature.Attributes.SetItem(colIndex, row.Cells[colIndex].Value?.ToString() ?? string.Empty);
                }
            }
        }

    }
}
