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
    public partial class moMapRenender : Form
    {
        #region 字段

        private MyMapObjects.moMapLayer _Layer; //輸入圖層對象
        private MyMapObjects.moRenderer _Renender; //輸出的圖層對象


        #endregion

        #region 方法

        internal void SetData(MyMapObjects.moMapLayer layer)
        { 
            _Layer = layer;
        }

        internal void GetData(out MyMapObjects.moRenderer renderer)
        {
            renderer = _Renender;
        }

        #endregion



        public moMapRenender()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //裝載窗體
        private void moMapRenender_Load(object sender, EventArgs e)
        {
            //這時已經獲得輸入的對象Layer
            //為接下來的用戶交互作相應的準備工作
        }

        //確認按鈕
        private void btn1_Click(object sender, EventArgs e)
        {
            //(1)根據用戶交互的]接口，新建一個Renender，並賦給_Renender
            //(2)既要關閉窗體，但窗體還要存在
            this.DialogResult = DialogResult.OK;
        }

        //取消按鈕
        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
