using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        #endregion

        #region 構造函數
        public frmLayerAttributes()
        {
            InitializeComponent();
        }
        #endregion


        #region 方法
        //設置數據
        internal void SetData(MyMapObjects.moMapLayer layer)
        { 
            _Layer = layer;
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
            //顯示窗體標題
            ShowFormTitle();
            //增加列
            CreateColoumns();
            //設置列標題
            SetColumnTexts();
            //增加行
            CreateRows();
            //設置選擇行
            SetRowSelection();
            mChangeByUser = true;
        }

        //需要顯示值
        private void dgvAttributes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            Int32 sColumnIndex = e.ColumnIndex;
            Int32 sRowIndex = e.RowIndex;
            if (sColumnIndex<0 || sRowIndex<0)
                return;
            MyMapObjects.moFeature sFeature = _Layer.Features.GetItem(sRowIndex);
            object sValue = sFeature.Attributes.GetItem(sColumnIndex);
            e.Value = sValue.ToString();
        }

        //選擇發生了變化 0516 1:09:00
        private void dgvAttributes_SelectionChanged(object sender, EventArgs e)
        {
            //如果非用戶觸發的變化，則直接返回
            if (mChangeByUser == false)
                return;
            MyMapObjects.moFeatures sSelectedFeatures = new MyMapObjects.moFeatures();
            Int32 sFeatureCount = _Layer.Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                if (dgvAttributes.Rows[i].Selected == true)
                {
                    MyMapObjects.moFeature sFeature = _Layer.Features.GetItem(i);
                    sSelectedFeatures.Add(sFeature);
                }
            }
            _Layer.SelectedFeatures = sSelectedFeatures;
            ToNotifyFeatureSelectionChanged();
        }


        #endregion



        #region 私有函數

        //顯示窗體標題
        private void ShowFormTitle()
        {
           this.Text = "屬性:" + _Layer.Name;
        }

        //生成所有列
        private void CreateColoumns()
        { 
            MyMapObjects.moFields sFields = _Layer.AttributeFields;
            Int32 sFieldCount = sFields.Count;
            //刪除所有列
            dgvAttributes.Columns.Clear();
            //根據字段數新建列
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            { 
                DataGridViewTextBoxColumn sColumns = new DataGridViewTextBoxColumn();
                dgvAttributes.Columns.Add(sColumns);
            }
        }
        //設置列頭
        private void SetColumnTexts()
        {
            MyMapObjects.moFields sFields = _Layer.AttributeFields;
            Int32 sFieldsCount = sFields.Count;
            for (Int32 i = 0;i <= sFieldsCount - 1;i++)
            {
                string sColumnText = "";
                MyMapObjects.moField sField = sFields.GetItem(i);
                if (sFields.ShowAlias == true)
                {
                    sColumnText = sField.AliasName;
                }
                else
                {
                    sColumnText = sField.Name;

                }

                dgvAttributes.Columns[i].HeaderText = sColumnText;
            }
        }

        //增加行
        private void CreateRows() 
        {
            //刪除所有行
            dgvAttributes.Rows.Clear();
            //根據要素數目增加行
            Int32 sRowCount = _Layer.Features.Count;
            if (sRowCount > 0)
            {
                dgvAttributes.Rows.Add(sRowCount);
            }
        }

        //設置選擇行
        //0516 32:處
        private void SetRowSelection()
        { 
            //先情除所有選擇行
            dgvAttributes.ClearSelection();
            //設置選擇行
            MyMapObjects.moFeatures sFeatures = _Layer.Features;
            MyMapObjects.moFeatures sSelectedFeatures = _Layer.SelectedFeatures;
            Int32 sSelectedCount = sSelectedFeatures.Count;
            for (Int32 i = 0; i <= sSelectedCount - 1; i++)
            { 
                MyMapObjects.moFeature sFeature = sSelectedFeatures.GetItem(i);
                Int32 sIndex = GetFeatureIndex (sFeatures, sFeature);
                if (sIndex > 0)
                {
                    dgvAttributes.Rows[sIndex].Selected = true;
                }
            }
        }

        //返回指定要素在要素集合中的索引好，如無，則返回-1
        private Int32 GetFeatureIndex (MyMapObjects.moFeatures features,MyMapObjects.moFeature feature)
        {
            Int32 sIndex = -1;
            Int32 sFeatureCount = features.Count;
            for(Int32 i = 0;i <= sFeatureCount - 1;i++) 
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


        //通知主窗體，選擇發生了變化
        private void ToNotifyFeatureSelectionChanged()
        { 
            FrmMap sfrmMain = (FrmMap)this.Owner;
            sfrmMain.NotifiedFeatureSelectionChanged(this);
        }

        #endregion


    }
}
