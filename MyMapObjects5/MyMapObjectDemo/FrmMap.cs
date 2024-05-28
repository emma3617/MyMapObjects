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

        #endregion

        #region 方法

        internal void NotifiedFeatureSelectionChanged(object sender)
        { 
            moMap.RedrawTrackingShapes();
        }

        #endregion

        #region 构造函数

        public FrmMap()
        {
            InitializeComponent();
            //订阅moMap的MouseWheel事件
            moMap.MouseWheel += MoMap_MouseWheel;
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

            //读取文件
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

            //加入地图控件
            moMap.Layers.Add(sLayer);
            if (moMap.Layers.Count == 1)
            {
                moMap.FullExtent();
            }
            else
            {
                moMap.RedrawMap();
            }
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
        //待補 大概0514 38左右
        private void btnEndSketch_Click(object sender, EventArgs e)
        {

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
                (MyMapObjects.moMultiPolygon) sLayer.SelectedFeatures.GetItem(0).Geometry;
            MyMapObjects.moMultiPolygon sDesMultiPolygon = sOriMultiPolygon.Clone();
            mEditingGeometry = sDesMultiPolygon;
            //設置選擇類型
            mMapOpStyle = 8;
            moMap.RedrawTrackingShapes();

        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            //修改數據，不再編寫
            //清除
            mEditingGeometry = null;
            //重繪
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
            if (moMap.Layers.Count ==0)
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
        }

        //地图控件鼠标按下
        private void moMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1) //放大
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == 2) //缩小
            { }
            else if (mMapOpStyle == 3) //漫游
            {
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == 4) //选择
            {
                OnSelect_MouseDown(e);
            }
            else if (mMapOpStyle == 5) //查询
            {
                OnIdentify_MouseDown(e);
            }
            else if (mMapOpStyle == 6) //移动
            {
                OnMoveShape_MouseDown(e);
            }
            else if (mMapOpStyle == 7) //描绘
            {

            }
            else if (mMapOpStyle == 8) //编辑
            { }
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
            { return; }
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
        }

        //移動圖層--鼠標鬆開
        private void OnMoveShape_MouseUp(MouseEventArgs e)
        {
            if (mIsInMovingShapes == false)
                return;
            mIsInMovingShapes = false;
            //做相應的修改數據的操作，不再編寫
            //一般來說，修改了圖形數據，應該重新更新相應範圍
            mMovingGeometries.Clear();
            //重繪地圖
            moMap.RedrawMap();
        }

        //松开——鼠标松开
        private void OnZoomIn_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
            { return; }
            mIsInZoomIn = false;
            if(mStartMouseLocation.X == e.Location.X && mStartMouseLocation.Y == e.Location.Y)
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
                if(sSelFeatureCount > 0)
                {
                    MyMapObjects.moGeometry[] sGeometries = new MyMapObjects.moGeometry[sSelFeatureCount];
                    for(Int32 i = 0; i <= sSelFeatureCount - 1; i++)
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
            MyMapObjects.moPoint sPoint=moMap.ToMapPoint(sX, sY);

            //缩放
            if (e.Delta > 0)
                moMap.ZoomByCenter(sPoint, mZoomRatioMouseWheel);
            else
                moMap.ZoomByCenter(sPoint,1/mZoomRatioMouseWheel);
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
            MyMapObjects.moPoint sPoint=moMap.ToMapPoint(point.X, point.Y);
            if(mShowLngLat == false)
            {
                double sX = Math.Round(sPoint.X, 2);
                double sY = Math.Round(sPoint.Y, 2);
                tssCoordinate.Text="X:"+sX.ToString()+",Y:"+sY.ToString();
            }
            else
            {
                MyMapObjects.moPoint sLngLat=moMap.ProjectionCS.TransferToLngLat(sPoint);
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
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolygon))
                {
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mMovingGeometries[i];
                    Int32 sPartCount = sMultiPolygon.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                        Int32 sPointCount = sPoints.Count;
                        for (Int32 k = 0; k <= sPointCount - 1; k++)
                        {
                            MyMapObjects.moPoint sPoint = sPoints.GetItem(k);
                            sPoint.X = sPoint.X + deltaX;
                            sPoint.Y = sPoint.Y + deltaY;
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
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
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
                //绘制边界
                drawingTool.DrawMultiPolygon(sMultiPolygon, mEditingPolygonSymbol);
                //绘制顶点手柄
                Int32 sPartCount = sMultiPolygon.Parts.Count;
                for (Int32 i = 0; i <= sPartCount - 1; i++)
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
    }
}
