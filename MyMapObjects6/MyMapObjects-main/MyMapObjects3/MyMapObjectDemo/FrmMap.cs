using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyMapObjectDemo
{
    public partial class FrmMap : Form
    {
        #region 字段

        //选项变量
        private Color mZoomBoxColor = Color.DeepPink; //缩放盒的颜色
        private double mZoomBoxWidth = 0.53; //缩放盒边界宽度，毫米
        private Color mSelectBoxColor = Color.DarkGreen; //选择盒的颜色
        private double mSelectBoxWidth = 0.53; //选择盒边界宽度，毫米
        private double mZoomRatioFixed = 2; //固定缩放系数
        private double mZoomRatioMouseWheel = 1.2; //滑轮缩放系数
        private double mSelectionTolerance = 3; //选择容限，单位像素
        private MyMapObjects.moSimpleFillSymbol mSelectingBoxSymbol; //选择盒符号
        private MyMapObjects.moSimpleFillSymbol mZoomBoxSymbol; //缩放盒符号
        private MyMapObjects.moSimpleFillSymbol mMovingPolygonSymbol; //正在移动的多边形符号
        private MyMapObjects.moSimpleFillSymbol mEditingPolygonSymbol; //正在编辑的多边形符号
        private MyMapObjects.moSimpleMarkerSymbol mEditingVertexSymbol; //正在编辑的图像顶点符号
        private MyMapObjects.moSimpleLineSymbol mElasticSymbol; //橡皮筋符号
        private bool mShowLngLat = false; //指示是否显示地理坐标（经纬度）

        //与地图操作有关的变量
        private Int32 mMapOpStyle = 0; //0：无，1：放大，2：缩小，3：漫游，4：选择，5：查询，6：移动，7：描绘，8：编辑
        private PointF mStartMouseLocation; //移动图形、选择、缩放或地图漫游时，鼠标按下时的位置
        private bool mIsInZoomIn = false;
        private bool mIsInZoomOut = false;
        private bool mIsInPan = false;
        private bool mIsInSelect = false;
        private bool mIsInIdentify = false;
        private bool mIsInMovingShapes = false;
        private List<MyMapObjects.moGeometry> mMovingGeometries = new List<MyMapObjects.moGeometry>();
        private MyMapObjects.moGeometry mEditingGeometry; //正在编辑的图形
        private List<MyMapObjects.moPoints> mSketchingShape; //正在描绘的图形，用一个多点的集合存储
        private bool mIsInEditNode = false;
        private int mEditingNodePartIndex = -1;
        private int mEditingNodeIndex = -1;
        #endregion

        #region 方法

        internal void NotifiedFeatureSelectionChanged(object sender)
        {
            moMap.RedrawTrackingShapes();
        }

        #endregion

        #region 构造函数
        private int dragIndex;
        private ContextMenuStrip clbContextMenu;


        public FrmMap()
        {
            InitializeComponent();
            //订阅moMap的MouseWheel事件
            moMap.MouseWheel += MoMap_MouseWheel;
            // 訂閱moMap的MouseDoubleClick事件
            moMap.MouseDoubleClick += moMap_MouseDoubleClick;
            clbLayers.AllowDrop = true;
            clbLayers.ItemCheck += clbLayers_ItemCheck;
            clbLayers.MouseDown += clbLayers_MouseDown;
            clbLayers.MouseMove += clbLayers_MouseMove;
            clbLayers.DragOver += clbLayers_DragOver;
            clbLayers.DragDrop += clbLayers_DragDrop;
            // 初始化上下文菜单
            InitializeContextMenu();
            //畫線圖層
            btnDrawLineLayer.Click += btnDrawLineLayer_Click;
            //條件查詢
            btnIdentify.Click += btnIdentify_Click;


        }
        private void InitializeContextMenu()
        {
            clbContextMenu = new ContextMenuStrip();
            var deleteMenuItem = new ToolStripMenuItem("删除");
            deleteMenuItem.Click += DeleteMenuItem_Click;
            clbContextMenu.Items.Add(deleteMenuItem);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (clbLayers.SelectedItem != null)
            {
                var layerName = clbLayers.SelectedItem.ToString();
                MyMapObjects.moMapLayer layer = null;
                for (int i = 0; i < moMap.Layers.Count; i++)
                {
                    var l = moMap.Layers.GetItem(i);
                    if (l.Name == layerName)
                    {
                        layer = l;
                        break;
                    }
                }

                if (layer != null)
                {
                    moMap.Layers.Remove(layer);
                    moMap.RedrawMap();
                    InitializeLayerList();
                }
            }
        }

        #endregion

        #region 窗体和控件事件处理

        //装载窗体
        private void FrmMap_Load(object sender, EventArgs e)
        {
            //（1）初始化符号
            InitializeSymbols();
            //（2）初始化描绘图形
            InitializeSketchingShape();
            //（3）显示比例尺
            ShowMapScale();
            // 初始化圖層列表
            InitializeLayerList();
        }
        private void InitializeLayerList()
        {
            clbLayers.Items.Clear();
            for (int i = 0; i < moMap.Layers.Count; i++)
            {
                var layer = moMap.Layers.GetItem(i);
                clbLayers.Items.Add(layer.Name, layer.Visible);
            }
        }
        private void clbLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                var layerName = clbLayers.Items[e.Index].ToString();
                MyMapObjects.moMapLayer layer = null;
                for (int i = 0; i < moMap.Layers.Count; i++)
                {
                    var l = moMap.Layers.GetItem(i);
                    if (l.Name == layerName)
                    {
                        layer = l;
                        break;
                    }
                }

                if (layer != null)
                {
                    layer.Visible = (e.NewValue == CheckState.Checked);
                    moMap.RedrawMap();
                }
            }));
        }

        //设置坐标系统
        private void btnProjection_Click(object sender, EventArgs e)
        {
            //new一个moProjectionCS对象，赋给moMap的ProjectionCS属性即可
            //由于地图控件的默认坐标系统与我们的实验数据的坐标系统正好一致，因此不再编写代码

        }

        //装载图层
        private void btnLoadLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog sDialog = new OpenFileDialog();
            sDialog.Filter = "Shape 文件|*.shp";
            string sFileName = "";
            if (sDialog.ShowDialog(this) == DialogResult.OK)
            {
                sFileName = sDialog.FileName;
                sDialog.Dispose();
            }
            else
            {
                sDialog.Dispose();
                return;
            }

            MyMapObjects.moMapLayer sLayer;
            try
            {
                sLayer = DataIOTools.LoadMapLayerFromShapeFile(sFileName);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            moMap.Layers.Add(sLayer);
            if (moMap.Layers.Count == 1)
            {
                moMap.FullExtent();
            }
            else
            {
                moMap.RedrawMap();
            }

            InitializeLayerList();
        }

        //全图显示
        private void btnFullExtent_Click(object sender, EventArgs e)
        {
            moMap.FullExtent();
        }

        //放大
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 1;
        }

        //缩小
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 2;
        }

        //漫游
        private void btnPan_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 3;
        }

        //选择
        private void btnSelect_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 4;
        }

        //查询
        private void btnIdentify_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 5;
            if (moMap.Layers.Count > 0)
            {
                MyMapObjects.moMapLayer layer = moMap.Layers.GetItem(0); // Select the layer you want to query
                QueryForm queryForm = new QueryForm(layer);
                queryForm.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("沒有符合的图层！");
            }
        }

        //简单渲染
        private void btnSimpleRenderer_Click(object sender, EventArgs e)
        {
            //（1）查找一个多边形图层
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            //（2）新建一个简单渲染对象
            MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
            MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
            //可以继续设置符号的颜色等特征
            sRenderer.Symbol = sSymbol;
            sLayer.Renderer = sRenderer;
            moMap.RedrawMap();
        }

        //唯一值渲染
        private void btnUnqiueValue_Click(object sender, EventArgs e)
        {
            //（1）查找一个多边形图层
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            //（2）如果存在字段名为“Name”的字段并且为字符型，则新建一个唯一值渲染对象
            string sFieldName = "NAME";
            Int32 sFieldIndex = sLayer.AttributeFields.FindField(sFieldName);
            if (sFieldIndex < 0)
                return;
            //新建一个渲染对象
            MyMapObjects.moUniqueValueRenderer sRenderer = new MyMapObjects.moUniqueValueRenderer();
            sRenderer.Field = sFieldName;
            //读出所有值
            List<string> sValues = new List<string>();
            Int32 sFeatureCount = sLayer.Features.Count;
            for (Int32 i = 0; i <= sLayer.Features.Count - 1; i++)
            {
                string sValue = (string)sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                sValues.Add(sValue);
            }
            //去除重复
            sValues.Distinct().ToList();
            //生成符号
            Int32 sValueCount = sValues.Count;
            for (Int32 i = 0; i <= sValueCount - 1; i++)
            {
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                sRenderer.AddUniqueValue(sValues[i], sSymbol);
            }
            sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol();
            //赋给图层
            sLayer.Renderer = sRenderer;
            //重绘地图
            moMap.RedrawMap();
        }

        //分级渲染
        private void btnClassBreaks_Click(object sender, EventArgs e)
        {
            //（1）查找多边形图层
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            //（2）如果存在名称为“POPU”的字段并且为双精度型，则新建一个分级渲染对象
            string sFieldName = "POPU";
            Int32 sFieldIndex = sLayer.AttributeFields.FindField(sFieldName);
            if (sFieldIndex < 0)
                return;
            if (sLayer.AttributeFields.GetItem(sFieldIndex).ValueType != MyMapObjects.moValueTypeConstant.dDouble)
                return;
            //新建一个分级渲染
            MyMapObjects.moClassBreaksRenderer sRenderer = new MyMapObjects.moClassBreaksRenderer();
            sRenderer.Field = sFieldName;
            //读出所有值
            List<double> sValues = new List<double>();
            Int32 sFeatureCount = sLayer.Features.Count;
            for (Int32 i = 0; i <= sFeatureCount - 1; i++)
            {
                double sValue = (double)sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                sValues.Add(sValue);
            }
            //获取最小最大值，并分为5级
            double sMinValue = sValues.Min();
            double sMaxValue = sValues.Max();
            for (Int32 i = 0; i <= 4; i++)
            {
                double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / 5;
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                sRenderer.AddBreakValue(sValue, sSymbol);
            }
            //生成渐变色
            Color sStartColor = Color.FromArgb(255, 255, 192, 192);
            Color sEndColor = Color.Maroon;
            sRenderer.RampColor(sStartColor, sEndColor);
            sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol();
            //赋给图层
            sLayer.Renderer = sRenderer;
            //重绘地图
            moMap.RedrawMap();
        }

        //注记按钮
        private void btnShowLabel_Click(object sender, EventArgs e)
        {
            if (moMap.Layers.Count == 0)
                return;
            //获取第一个图层
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(0);
            //检索第一个字符型字段，如果没有字符型字段则直接选择第一个字段
            Int32 sFieldCount = sLayer.AttributeFields.Count;
            if (sFieldCount == 0)
                return;
            Int32 sFieldIndex = 0;
            for (Int32 i = 0; i <= sFieldCount - 1; i++)
            {
                if (sLayer.AttributeFields.GetItem(i).ValueType == MyMapObjects.moValueTypeConstant.dText)
                {
                    sFieldIndex = i;
                    break;
                }
            }
            //新建一个注记渲染对象
            MyMapObjects.moLabelRenderer sLabelRenderer = new MyMapObjects.moLabelRenderer();
            //设定绑定字段
            sLabelRenderer.Field = sLayer.AttributeFields.GetItem(sFieldIndex).Name;
            //设置注记符号
            Font sOldFont = sLabelRenderer.TextSymbol.Font;
            sLabelRenderer.TextSymbol.Font = new Font(sOldFont.Name, 12);
            sLabelRenderer.TextSymbol.UseMask = true;
            sLabelRenderer.LabelFeatures = true;
            //赋给图层
            sLayer.LabelRenderer = sLabelRenderer;
            //重绘地图
            moMap.RedrawMap();
        }

        //移动多边形
        private void btnMovePolygon_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 6;
        }

        //描绘多边形
        private void btnSketchPolygon_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 7;
        }

        private void btnEndPart_Click(object sender, EventArgs e)
        {
            //判斷是否結束，即是否至少三個點
            if (mSketchingShape.Last().Count < 3)
                return;
            //往List中增加一個多點對像
            MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
            mSketchingShape.Add(sPoints);
            //重繪
            moMap.RedrawTrackingShapes();

        }

        //結束描繪
        private void btnEndSketch_Click(object sender, EventArgs e)
        {
            EndPolygonSketching();
        }

        //編輯多邊形
        private void btnEditPolygon_Click(object sender, EventArgs e)
        {
            //獲得一個多邊形
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            //是否只有一個選中的多邊形
            if (sLayer.SelectedFeatures.Count != 1)
                return;
            //複製
            MyMapObjects.moMultiPolygon sOriMultiPolygon =
                (MyMapObjects.moMultiPolygon)sLayer.SelectedFeatures.GetItem(0).Geometry;
            MyMapObjects.moMultiPolygon sDesMultiPolygon = sOriMultiPolygon.Clone();
            mEditingGeometry = sDesMultiPolygon;
            //設置選擇類型
            mMapOpStyle = 8;
            moMap.RedrawTrackingShapes();

        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            if (mEditingGeometry != null)
            {
                // 更新多边形的范围
                MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
                sMultiPolygon.UpdateExtent();

                // 保存新的多边形到图层中
                SaveEditedPolygon();
            }

            // 清除
            mEditingGeometry = null;
            mMapOpStyle = 0; // 退出编辑模式

            // 重绘地图
            moMap.RedrawMap();
        }

        //显示地理坐标
        private void chkShowLngLat_CheckedChanged(object sender, EventArgs e)
        {
            mShowLngLat = chkShowLngLat.Checked;
        }

        //圖層渲染
        private void btnLayerRenderer_Click(object sender, EventArgs e)
        {
            //(1)我們獲得一個任意類型圖層
            if (moMap.Layers.Count == 0)
                return;
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(0);
            //(2)新建一個frmLayerRenender對象(窗體)
            moMapRenender sfrmLayerRenender = new moMapRenender();
            //(3)載入數據
            sfrmLayerRenender.SetData(sLayer);
            //(4)顯示窗體，並根據對話框結果做相應的反應
            if (sfrmLayerRenender.ShowDialog(this) == DialogResult.OK)
            {
                MyMapObjects.moRenderer sRenderer;
                sfrmLayerRenender.GetData(out sRenderer);
                //由於在frmLayerRenderer沒有實現實例化
                //sLayer.Renderer = sRenderer;
                moMap.RedrawMap();
                sfrmLayerRenender.Dispose();

            }
            else
            {
                sfrmLayerRenender.Dispose();
            }
        }

        private void btnLayerAttributes_Click(object sender, EventArgs e)
        {
            //(1)獲取任意類型的一個圖層
            if (moMap.Layers.Count == 0)
                return;
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(0);
            //(2)檢測該圖層屬性窗體是否已經打開
            frmLayerAttributes sfrmLayerAttributes = IsLayerAttributesFormOpened(sLayer);
            if (sfrmLayerAttributes == null)
            {
                //(3)沒有打開，則新建一個
                sfrmLayerAttributes = new frmLayerAttributes();
                //輸入數據
                sfrmLayerAttributes.SetData(sLayer);
                //顯示窗體
                sfrmLayerAttributes.Show(this);
            }
            else
            {
                //(4)已經打開，則激活
                sfrmLayerAttributes.Activate();
            }
        }

        #endregion

        #region 地图控件事件处理

        private void moMap_AfterTrackingLayerDraw(object sender, MyMapObjects.moUserDrawingTool drawTool)
        {
            DrawSketchingShapes(drawTool);
            DrawEditingShapes(drawTool);
        }

        //比例尺发生了变化
        private void moMap_MapScaleChanged(object sender)
        {
            ShowMapScale();
        }

        //地圖控件的鼠標點擊事件
        private void moMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1) //放大
            { }
            else if (mMapOpStyle == 2) //缩小
            {
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                moMap.ZoomByCenter(sPoint, 1 / mZoomRatioFixed);
            }
            else if (mMapOpStyle == 3) //漫游
            { }
            else if (mMapOpStyle == 4) //选择
            { }
            else if (mMapOpStyle == 5) //查询
            { }
            else if (mMapOpStyle == 6) //移动
            { }
            else if (mMapOpStyle == 7) //描绘
            {
                if (e.Button != MouseButtons.Left)
                    return;
                //將屏幕座標轉換為地圖座標並加入描繪圖形
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                mSketchingShape.Last().Add(sPoint);
                //地圖控件重繪跟蹤
                moMap.RedrawTrackingShapes();
            }
            else if (mMapOpStyle == 8) //编辑
            { }

            else if (mMapOpStyle == 9) // 節點編輯
            {
                OnEditNode_MouseClick(e);
            }
            if (mMapOpStyle == 10) // 画线图层模式
            {
                if (e.Button != MouseButtons.Left)
                    return;
                // 将屏幕坐标转换为地图坐标并加入描绘图形
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                mSketchingShape.Last().Add(sPoint);
                // 地图控件重绘跟踪
                moMap.RedrawTrackingShapes();
            }
        }


        //地图控件鼠标按下
        private void moMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1) // 放大
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == 2) // 缩小
            {
            }
            else if (mMapOpStyle == 3) // 漫遊
            {
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == 4) // 選擇
            {
                OnSelect_MouseDown(e);
            }
            else if (mMapOpStyle == 5) // 查詢
            {
                OnIdentify_MouseDown(e);
            }
            else if (mMapOpStyle == 6) // 移動
            {
                OnMoveShape_MouseDown(e);
            }
            else if (mMapOpStyle == 7) // 描繪
            {
            }
            else if (mMapOpStyle == 8) // 編輯
            {
            }
            else if (mMapOpStyle == 9) // 節點編輯
            {
                OnEditNode_MouseDown(e);
            }
        }

        //放大——鼠标按下
        private void OnZoomIn_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInZoomIn = true;
            }
        }

        //漫游——鼠标按下
        private void OnPan_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInPan = true;
            }
        }

        //选择——鼠标按下
        private void OnSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInSelect = true;
            }
        }

        //查询——鼠标按下
        private void OnIdentify_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInIdentify = true;
            }
        }

        //移动图形——鼠标按下
        private void OnMoveShape_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            //查找多边形图层
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            //判断是否有选中的要素
            Int32 sSelFeatureCount = sLayer.SelectedFeatures.Count;
            if (sSelFeatureCount == 0)
                return;
            //复制图形
            mMovingGeometries.Clear();
            for (Int32 i = 0; i <= sSelFeatureCount - 1; i++)
            {
                MyMapObjects.moMultiPolygon sOriPolygon = (MyMapObjects.moMultiPolygon)sLayer.SelectedFeatures.GetItem(i).Geometry;
                MyMapObjects.moMultiPolygon sDesPolygon = sOriPolygon.Clone();
                mMovingGeometries.Add(sDesPolygon);
            }
            //设置变量
            mStartMouseLocation = e.Location;
            mIsInMovingShapes = true;
        }

        //地图控件鼠标移动
        private void moMap_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoordinates(e.Location);
            if (mMapOpStyle == 1) //放大
            {
                OnZoomIn_MouseMove(e);
            }
            else if (mMapOpStyle == 2) //缩小
            { }
            else if (mMapOpStyle == 3) //漫游
            {
                OnPan_MouseMove(e);
            }
            else if (mMapOpStyle == 4) //选择
            {
                OnSelect_MouseMove(e);
            }
            else if (mMapOpStyle == 5) //查询
            {
                OnIdentify_MouseMove(e);
            }
            else if (mMapOpStyle == 6) //移动
            {
                OnMoveShape_MouseMove(e);
            }
            else if (mMapOpStyle == 7) //描绘
            {
                MyMapObjects.moPoint sCurPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                MyMapObjects.moPoints sLastPart = mSketchingShape.Last();
                Int32 sPointCount = sLastPart.Count;
                if (sPointCount == 0)
                { }//什麼也不幹
                else if (sPointCount == 1)
                {
                    moMap.Refresh();
                    //只有一個點，
                    MyMapObjects.moPoint sFirstPoint = sLastPart.GetItem(0);
                    MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                }
                else
                {
                    moMap.Refresh();
                    MyMapObjects.moPoint sFirstPoint = sLastPart.GetItem(0);
                    MyMapObjects.moPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                    MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                    sDrawingTool.DrawLine(sLastPoint, sCurPoint, mElasticSymbol);
                }
            }
            else if (mMapOpStyle == 8) //编辑
            { }
            else if (mMapOpStyle == 9) // 節點編輯
            {
                if (mIsInEditNode)
                {
                    OnEditNode_MouseMove(e);
                }
            }
            else if (mIsInMovingShapes) // 確認移動狀態
            {
                OnMoveShape_MouseMove(e);
            }
        }




        //放大——鼠标移动
        private void OnZoomIn_MouseMove(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
            { return; }
            moMap.Refresh();
            MyMapObjects.moRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);
        }

        //漫游——鼠标移动
        private void OnPan_MouseMove(MouseEventArgs e)
        {
            if (mIsInPan == false)
            { return; }
            moMap.PanMapImageTo(e.Location.X - mStartMouseLocation.X, e.Location.Y - mStartMouseLocation.Y);
        }

        //选择——鼠标移动
        private void OnSelect_MouseMove(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            { return; }
            moMap.Refresh();
            MyMapObjects.moRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectingBoxSymbol);
        }

        //查询——鼠标移动
        private void OnIdentify_MouseMove(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
            { return; }
            moMap.Refresh();
            MyMapObjects.moRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectingBoxSymbol);
        }

        //移动图形——鼠标移动
        private void OnMoveShape_MouseMove(MouseEventArgs e)
        {
            if (mIsInMovingShapes == false)
                return; 
            //修改移动图形的坐标
            double sDeltaX = moMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = moMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            ModifyMovingGeometries(sDeltaX, sDeltaY);
            //绘制移动图形
            moMap.Refresh();
            DrawMovingShapes();
            //重新設置鼠標位置
            mStartMouseLocation = e.Location;
        }

        //地圖控件的鼠標鬆開事件
        private void moMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1) //放大
            {
                OnZoomIn_MouseUp(e);
            }
            else if (mMapOpStyle == 2) //缩小
            { }
            else if (mMapOpStyle == 3) //漫游
            {
                OnPan_MouseUp(e);
            }
            else if (mMapOpStyle == 4) //选择
            {
                OnSelect_MouseUp(e);
            }
            else if (mMapOpStyle == 5) //查询
            {
                OnIdentify_MouseUp(e);
            }
            else if (mMapOpStyle == 6) //移动
            {
                OnMoveShape_MouseUp(e);
            }
            else if (mMapOpStyle == 7) //描绘
            { }
            else if (mMapOpStyle == 8) //编辑
            { }
            else if (mMapOpStyle == 9) // 節點編輯
            {
                if (mIsInEditNode)
                {
                    OnEditNode_MouseUp(e);
                }
            }
        }

        //移動圖層--鼠標鬆開
        private void OnMoveShape_MouseUp(MouseEventArgs e)
        {
            if (!mIsInMovingShapes)
                return;
            // 獲取多邊形圖層
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;

            // 更新圖層中的幾何圖形
            for (int i = 0; i < mMovingGeometries.Count; i++)
            {
                MyMapObjects.moGeometry sNewGeometry = mMovingGeometries[i];
                MyMapObjects.moGeometry sOriginalGeometry = sLayer.SelectedFeatures.GetItem(i).Geometry;

                if (sNewGeometry.GetType() == typeof(MyMapObjects.moMultiPolygon) &&
                    sOriginalGeometry.GetType() == typeof(MyMapObjects.moMultiPolygon))
                {
                    MyMapObjects.moMultiPolygon sNewMultiPolygon = (MyMapObjects.moMultiPolygon)sNewGeometry;
                    MyMapObjects.moMultiPolygon sOriginalMultiPolygon = (MyMapObjects.moMultiPolygon)sOriginalGeometry;

                    sOriginalMultiPolygon.Parts = sNewMultiPolygon.Parts.Clone();
                    sOriginalMultiPolygon.UpdateExtent();
                }
            }

            mIsInMovingShapes = false;
            mMovingGeometries.Clear();
            moMap.RedrawMap();
        }

        //松开——鼠标松开
        private void OnZoomIn_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
            { return; }
            mIsInZoomIn = false;
            if (mStartMouseLocation.X == e.Location.X && mStartMouseLocation.Y == e.Location.Y)
            {
                //按单点放大
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);
                moMap.ZoomByCenter(sPoint, mZoomRatioFixed);
            }
            else
            {
                //按矩形放大
                MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
                moMap.ZoomToExtent(sBox);
            }
        }

        //漫游——鼠标松开
        private void OnPan_MouseUp(MouseEventArgs e)
        {
            if (mIsInPan == false)
            { return; }
            mIsInPan = false;
            double sDeltaX = moMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = moMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            moMap.PanDelta(sDeltaX, sDeltaY);
        }

        //选择——鼠标松开
        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            { return; }
            mIsInSelect = false;
            MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double sTolerance = moMap.ToMapDistance(mSelectionTolerance);
            moMap.SelectByBox(sBox, sTolerance, 0);
            moMap.RedrawTrackingShapes();
            //通知子窗體，選擇發生了變化
            ToNotifiedFeatureSelectionChanged();
        }

        //查询——鼠标松开
        private void OnIdentify_MouseUp(MouseEventArgs e)
        {
            if (mIsInIdentify == false)
            { return; }
            mIsInIdentify = false;
            moMap.Refresh();
            MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double sTolerance = moMap.ToMapDistance(mSelectionTolerance);
            if (moMap.Layers.Count == 0)
                return;
            else
            {
                MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(0);
                MyMapObjects.moFeatures sFeatures = sLayer.SearchByBox(sBox, sTolerance);
                Int32 sSelFeatureCount = sFeatures.Count;
                if (sSelFeatureCount > 0)
                {
                    MyMapObjects.moGeometry[] sGeometries = new MyMapObjects.moGeometry[sSelFeatureCount];
                    for (Int32 i = 0; i <= sSelFeatureCount - 1; i++)
                    {
                        sGeometries[i] = sFeatures.GetItem(i).Geometry;
                    }
                    moMap.FlashShapes(sGeometries, 3, 800);
                }
            }
        }

        //地图控件的鼠标滑轮事件
        private void MoMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //计算地图控件中心的地图坐标
            double sX = moMap.ClientRectangle.Width / 2;
            double sY = moMap.ClientRectangle.Height / 2;
            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(sX, sY);

            //缩放
            if (e.Delta > 0)
                moMap.ZoomByCenter(sPoint, mZoomRatioMouseWheel);
            else
                moMap.ZoomByCenter(sPoint, 1 / mZoomRatioMouseWheel);
        }

        #endregion

        #region 私有函数

        //初始化符号
        private void InitializeSymbols()
        {
            mSelectingBoxSymbol = new MyMapObjects.moSimpleFillSymbol();
            mSelectingBoxSymbol.Color = Color.Transparent;
            mSelectingBoxSymbol.Outline.Color = mSelectBoxColor;
            mSelectingBoxSymbol.Outline.Size = mSelectBoxWidth;
            mZoomBoxSymbol = new MyMapObjects.moSimpleFillSymbol();
            mZoomBoxSymbol.Color = Color.Transparent;
            mZoomBoxSymbol.Outline.Color = mZoomBoxColor;
            mZoomBoxSymbol.Outline.Size = mZoomBoxWidth;
            mMovingPolygonSymbol = new MyMapObjects.moSimpleFillSymbol();
            mMovingPolygonSymbol.Color = Color.Transparent;
            mMovingPolygonSymbol.Outline.Color = Color.Black;
            mEditingPolygonSymbol = new MyMapObjects.moSimpleFillSymbol();
            mEditingPolygonSymbol.Color = Color.Transparent;
            mEditingPolygonSymbol.Outline.Color = Color.DarkGreen;
            mEditingPolygonSymbol.Outline.Size = 0.53;
            mEditingVertexSymbol = new MyMapObjects.moSimpleMarkerSymbol();
            mEditingVertexSymbol.Color = Color.DarkGreen;
            mEditingVertexSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidSquare;
            mEditingVertexSymbol.Size = 2;
            mElasticSymbol = new MyMapObjects.moSimpleLineSymbol();
            mElasticSymbol.Color = Color.DarkGreen;
            mElasticSymbol.Size = 0.52;
            mElasticSymbol.Style = MyMapObjects.moSimpleLineSymbolStyleConstant.Dash;
        }

        //初始化描绘图形
        private void InitializeSketchingShape()
        {
            mSketchingShape = new List<MyMapObjects.moPoints>();
            MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
            mSketchingShape.Add(sPoints);
        }

        //根据屏幕坐标显示地图坐标
        private void ShowCoordinates(PointF point)
        {
            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(point.X, point.Y);
            if (mShowLngLat == false)
            {
                double sX = Math.Round(sPoint.X, 2);
                double sY = Math.Round(sPoint.Y, 2);
                tssCoordinate.Text = "X:" + sX.ToString() + ",Y:" + sY.ToString();
            }
            else
            {
                MyMapObjects.moPoint sLngLat = moMap.ProjectionCS.TransferToLngLat(sPoint);
                double sX = Math.Round(sLngLat.X, 4);
                double sY = Math.Round(sLngLat.Y, 4);
                tssCoordinate.Text = "X:" + sX.ToString() + ",Y:" + sY.ToString();
            }

        }

        //显示比例尺
        private void ShowMapScale()
        {
            tssMapScale.Text = "1:" + moMap.MapScale.ToString("0.00");
        }

        //根据屏幕上的两点获得一个地图坐标下的矩形
        private MyMapObjects.moRectangle GetMapRectByTwoPoints(PointF point1, PointF point2)
        {
            MyMapObjects.moPoint sPoint1 = moMap.ToMapPoint(point1.X, point1.Y);
            MyMapObjects.moPoint sPoint2 = moMap.ToMapPoint(point2.X, point2.Y);
            double sMinX = Math.Min(sPoint1.X, sPoint2.X);
            double sMaxX = Math.Max(sPoint1.X, sPoint2.X);
            double sMinY = Math.Min(sPoint1.Y, sPoint2.Y);
            double sMaxY = Math.Max(sPoint1.Y, sPoint2.Y);
            MyMapObjects.moRectangle sRect = new MyMapObjects.moRectangle(sMinX, sMaxX, sMinY, sMaxY);
            return sRect;
        }

        //获取一个多边形图层
        private MyMapObjects.moMapLayer GetPolygonLayer()
        {
            Int32 sLayerCount = moMap.Layers.Count;
            MyMapObjects.moMapLayer sLayer = null;
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                if (moMap.Layers.GetItem(i).ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
                {
                    sLayer = moMap.Layers.GetItem(i);
                    break;
                }
            }
            return sLayer;
        }

        //修改移动图形的坐标
        private void ModifyMovingGeometries(double deltaX, double deltaY)
        {
            int sCount = mMovingGeometries.Count;
            for (int i = 0; i < sCount; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolygon))
                {
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mMovingGeometries[i];
                    int sPartCount = sMultiPolygon.Parts.Count;
                    for (int j = 0; j < sPartCount; j++)
                    {
                        MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                        int sPointCount = sPoints.Count;
                        for (int k = 0; k < sPointCount; k++)
                        {
                            MyMapObjects.moPoint sPoint = sPoints.GetItem(k);
                            sPoint.X += deltaX;
                            sPoint.Y += deltaY;
                        }
                    }
                    sMultiPolygon.UpdateExtent();
                }
            }
        }

        //绘制移动图形
        private void DrawMovingShapes()
        {
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            int sCount = mMovingGeometries.Count;
            for (int i = 0; i < sCount; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolygon))
                {
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mMovingGeometries[i];
                    sDrawingTool.DrawMultiPolygon(sMultiPolygon, mMovingPolygonSymbol);
                }
            }
        }

        //绘制正在描绘的图形
        private void DrawSketchingShapes(MyMapObjects.moUserDrawingTool drawingTool)
        {
            if (mSketchingShape == null)
                return;
            Int32 sPartCount = mSketchingShape.Count;
            //绘制已经描绘完成的部分
            for (Int32 i = 0; i <= sPartCount - 2; i++)
            {
                drawingTool.DrawPolygon(mSketchingShape[i], mEditingPolygonSymbol);
            }
            //正在描绘的部分（只有一个Part）
            MyMapObjects.moPoints sLastPart = mSketchingShape.Last();
            if (sLastPart.Count >= 2)
                drawingTool.DrawPolyline(sLastPart, mEditingPolygonSymbol.Outline);
            //绘制所有顶点手柄
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                MyMapObjects.moPoints sPoints = mSketchingShape[i];
                drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
            }
        }

        //绘制正在编辑的图形
        private void DrawEditingShapes(MyMapObjects.moUserDrawingTool drawingTool)
        {
            if (mEditingGeometry == null)
                return;

            if (mEditingGeometry.GetType() == typeof(MyMapObjects.moMultiPolygon))
            {
                MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
                // 繪製邊界
                drawingTool.DrawMultiPolygon(sMultiPolygon, mEditingPolygonSymbol);
                // 繪製頂點手柄
                int sPartCount = sMultiPolygon.Parts.Count;
                for (int i = 0; i < sPartCount; i++)
                {
                    MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(i);
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
        }

        //指定圖層的屬性窗體是否已經打開，如是則返回已經打開的窗體，如否則返回null
        private frmLayerAttributes IsLayerAttributesFormOpened(MyMapObjects.moMapLayer layer)
        {
            frmLayerAttributes sfrmLayerAttributes = null;
            foreach (Form sForm in this.OwnedForms)
            {
                if (sForm.GetType() == typeof(frmLayerAttributes))
                {
                    frmLayerAttributes sCurfrmLayerAttributes = (frmLayerAttributes)sForm;
                    if (sCurfrmLayerAttributes.GetLayer() == layer)
                    {
                        sfrmLayerAttributes = sCurfrmLayerAttributes;
                        break;
                    }
                }
            }
            return sfrmLayerAttributes;
        }

        //通知子窗體，要素選擇發生了變化
        private void ToNotifiedFeatureSelectionChanged()
        {
            Int32 sLayerCount = moMap.Layers.Count;
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(i);
                frmLayerAttributes sfrmLayerAttributes = IsLayerAttributesFormOpened(sLayer);
                if (sfrmLayerAttributes != null)
                {
                    sfrmLayerAttributes.NotifiedFeatureSelectionChanged(this);
                }
            }
        }

        #endregion

        private void moMap_Load(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnEditPolygonNode_Click(object sender, EventArgs e)
        {
            // 獲取多邊形圖層
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;

            // 檢查是否只有一個選中的多邊形
            if (sLayer.SelectedFeatures.Count != 1)
                return;

            // 獲取選中的多邊形並複製
            MyMapObjects.moMultiPolygon sOriMultiPolygon =
                (MyMapObjects.moMultiPolygon)sLayer.SelectedFeatures.GetItem(0).Geometry;
            MyMapObjects.moMultiPolygon sDesMultiPolygon = sOriMultiPolygon.Clone();
            mEditingGeometry = sDesMultiPolygon;

            // 設定地圖操作樣式為節點編輯
            mMapOpStyle = 9; // 使用 9 表示節點編輯
            moMap.RedrawTrackingShapes();
        }
        private void OnEditNode_MouseClick(MouseEventArgs e)
        {
            if (mEditingGeometry == null)
                return;

            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
            double sTolerance = moMap.ToMapDistance(mSelectionTolerance);

            MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
            for (int i = 0; i < sMultiPolygon.Parts.Count; i++)
            {
                MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(i);
                for (int j = 0; j < sPoints.Count; j++)
                {
                    MyMapObjects.moPoint sVertex = sPoints.GetItem(j);
                    if (sVertex.Distance(sPoint) <= sTolerance)
                    {
                        mIsInEditNode = true;
                        mEditingNodePartIndex = i;
                        mEditingNodeIndex = j;
                        return;
                    }
                }
            }
        }
        private void OnEditNode_MouseMove(MouseEventArgs e)
        {
            if (!mIsInEditNode)
                return;

            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
            MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
            MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(mEditingNodePartIndex);
            sPoints.SetItem(mEditingNodeIndex, sPoint);
            sMultiPolygon.UpdateExtent();

            moMap.RedrawTrackingShapes();
        }
        private void OnEditNode_MouseUp(MouseEventArgs e)
        {
            if (mIsInEditNode)
            {
                mIsInEditNode = false;
                MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
                sMultiPolygon.UpdateExtent();
                SaveEditedPolygon();
            }
        }
        private void SaveEditedPolygon()
        {
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;

            for (int i = 0; i < sLayer.SelectedFeatures.Count; i++)
            {
                MyMapObjects.moFeature sFeature = sLayer.SelectedFeatures.GetItem(i);
                if (sFeature.Geometry is MyMapObjects.moMultiPolygon)
                {
                    sFeature.Geometry = ((MyMapObjects.moMultiPolygon)mEditingGeometry).Clone();
                    sLayer.Features.SetItem(i, sFeature);
                    break;
                }
            }

            sLayer.UpdateExtent();
            moMap.RedrawMap();
        }
        private void OnEditNode_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
            double sTolerance = moMap.ToMapDistance(mSelectionTolerance);

            MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
            for (int i = 0; i < sMultiPolygon.Parts.Count; i++)
            {
                MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(i);
                for (int j = 0; j < sPoints.Count; j++)
                {
                    MyMapObjects.moPoint sVertex = sPoints.GetItem(j);
                    if (sVertex.Distance(sPoint) <= sTolerance)
                    {
                        mIsInEditNode = true;
                        mEditingNodePartIndex = i;
                        mEditingNodeIndex = j;
                        return;
                    }
                }
            }
        }

        private void moMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mMapOpStyle == 9) // 節點編輯模式
                {
                    EndNodeEditing();
                }
                else if (mMapOpStyle == 7) // 描繪多邊形模式
                {
                    EndPolygonSketching();
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (mMapOpStyle == 10) // 画线图层模式
                    {
                        EndLineSketching();
                    }
                }
            }
        }

        private void EndLineSketching()
        {
            if (mSketchingShape.Last().Count >= 1 && mSketchingShape.Last().Count < 2)
                return;
            if (mSketchingShape.Last().Count == 0)
            {
                mSketchingShape.Remove(mSketchingShape.Last());
            }
            if (mSketchingShape.Count > 0)
            {
                // 创建新图层
                string layerName = "LineLayer_" + DateTime.Now.Ticks;
                MyMapObjects.moMapLayer newLayer = new MyMapObjects.moMapLayer(layerName, MyMapObjects.moGeometryTypeConstant.MultiPolyline);

                // 新建折线
                MyMapObjects.moMultiPolyline sMultiPolyline = new MyMapObjects.moMultiPolyline();
                sMultiPolyline.Parts.AddRange(mSketchingShape.ToArray());
                sMultiPolyline.UpdateExtent();

                // 新建要素并加入图层
                MyMapObjects.moFeature sFeature = newLayer.GetNewFeature();
                sFeature.Geometry = sMultiPolyline;
                newLayer.Features.Add(sFeature);
                newLayer.UpdateExtent();

                // 添加新图层到地图
                moMap.Layers.Add(newLayer);

                // 更新图层列表
                InitializeLayerList();
            }
            InitializeSketchingShape();
            mMapOpStyle = 0;
            moMap.RedrawMap();
        }
        private void EndNodeEditing()
        {
            if (mEditingGeometry != null)
            {
                MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
                sMultiPolygon.UpdateExtent();
                SaveEditedPolygon();
                mEditingGeometry = null;
                mIsInEditNode = false;
                mMapOpStyle = 0;
                moMap.RedrawMap();
            }
        }
        private void EndPolygonSketching()
        {
            if (mSketchingShape.Last().Count >= 1 && mSketchingShape.Last().Count < 3)
                return;
            if (mSketchingShape.Last().Count == 0)
            {
                mSketchingShape.Remove(mSketchingShape.Last());
            }
            if (mSketchingShape.Count > 0)
            {
                // 创建新图层
                string layerName = "DefaultName_" + DateTime.Now.Ticks;
                MyMapObjects.moMapLayer newLayer = new MyMapObjects.moMapLayer(layerName, MyMapObjects.moGeometryTypeConstant.MultiPolygon);

                // 新建多边形
                MyMapObjects.moMultiPolygon sMultiPolygon = new MyMapObjects.moMultiPolygon();
                sMultiPolygon.Parts.AddRange(mSketchingShape.ToArray());
                sMultiPolygon.UpdateExtent();

                // 新建要素并加入图层
                MyMapObjects.moFeature sFeature = newLayer.GetNewFeature();
                sFeature.Geometry = sMultiPolygon;
                newLayer.Features.Add(sFeature);
                newLayer.UpdateExtent();

                // 添加新图层到地图
                moMap.Layers.Add(newLayer);

                // 更新图层列表
                InitializeLayerList();
            }
            InitializeSketchingShape();
            mMapOpStyle = 0;
            moMap.RedrawMap();
        }

        private void clbLayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            if (clbLayers.SelectedItem != null)
            {
                var layerName = clbLayers.SelectedItem.ToString();
                MyMapObjects.moMapLayer layer = null;
                for (int i = 0; i < moMap.Layers.Count; i++)
                {
                    var l = moMap.Layers.GetItem(i);
                    if (l.Name == layerName)
                    {
                        layer = l;
                        break;
                    }
                }

                if (layer != null)
                {
                    moMap.Layers.Remove(layer);
                    moMap.RedrawMap();
                    InitializeLayerList();
                }
            }
        }




        
        private void clbLayers_MouseDown(object sender, MouseEventArgs e)
        {
            dragIndex = clbLayers.IndexFromPoint(e.X, e.Y);
            if (dragIndex != ListBox.NoMatches)
            {
                if (e.Button == MouseButtons.Right)
                {
                    clbLayers.SelectedIndex = dragIndex;
                    clbContextMenu.Show(clbLayers, e.Location);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    clbLayers.DoDragDrop(clbLayers.Items[dragIndex], DragDropEffects.Move);
                }
            }
        }

        private void clbLayers_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && dragIndex != ListBox.NoMatches)
            {
                clbLayers.DoDragDrop(clbLayers.Items[dragIndex], DragDropEffects.Move);
            }
        }

        private void clbLayers_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void clbLayers_DragDrop(object sender, DragEventArgs e)
        {
            Point point = clbLayers.PointToClient(new Point(e.X, e.Y));
            int index = clbLayers.IndexFromPoint(point);

            if (index != ListBox.NoMatches && index != dragIndex)
            {
                object data = clbLayers.Items[dragIndex];
                bool isChecked = clbLayers.GetItemChecked(dragIndex);
                clbLayers.Items.RemoveAt(dragIndex);
                clbLayers.Items.Insert(index, data);
                clbLayers.SetItemChecked(index, isChecked);
                UpdateLayerOrder();
            }
        }

        private void UpdateLayerOrder()
        {
            List<MyMapObjects.moMapLayer> layers = new List<MyMapObjects.moMapLayer>();

            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                var layerName = clbLayers.Items[i].ToString();
                MyMapObjects.moMapLayer layer = null;
                for (int j = 0; j < moMap.Layers.Count; j++)
                {
                    var l = moMap.Layers.GetItem(j);
                    if (l.Name == layerName)
                    {
                        layer = l;
                        break;
                    }
                }
                if (layer != null)
                {
                    layers.Add(layer);
                }
            }

            moMap.Layers.Clear();
            foreach (var layer in layers)
            {
                moMap.Layers.Add(layer);
            }

            moMap.RedrawMap();
        }

        private void btnDrawLineLayer_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 10; // 使用 10 表示画线图层模式
            InitializeSketchingShape(); // 初始化描绘图形
        }
    }
}
