
namespace MyMapObjectDemo
{
    partial class FrmMap
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            MyMapObjects.moLayers moLayers1 = new MyMapObjects.moLayers();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMap));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMapScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDrawLineLayer = new System.Windows.Forms.Button();
            this.btnEditPolygonNode = new System.Windows.Forms.Button();
            this.btnLayerAttributes = new System.Windows.Forms.Button();
            this.chkShowLngLat = new System.Windows.Forms.CheckBox();
            this.btnLayerRenderer = new System.Windows.Forms.Button();
            this.btnEndEdit = new System.Windows.Forms.Button();
            this.btnEditPolygon = new System.Windows.Forms.Button();
            this.btnEndSketch = new System.Windows.Forms.Button();
            this.btnEndPart = new System.Windows.Forms.Button();
            this.btnSketchPolygon = new System.Windows.Forms.Button();
            this.btnMovePolygon = new System.Windows.Forms.Button();
            this.btnShowLabel = new System.Windows.Forms.Button();
            this.btnClassBreaks = new System.Windows.Forms.Button();
            this.btnUnqiueValue = new System.Windows.Forms.Button();
            this.btnSimpleRenderer = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnPan = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnFullExtent = new System.Windows.Forms.Button();
            this.btnProjection = new System.Windows.Forms.Button();
            this.btnLoadLayer = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.moMap = new MyMapObjects.moMapControl();
            this.clbLayers = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.档案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置坐标系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.layerComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.btnCancelAllOps = new System.Windows.Forms.ToolStripButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCoordinate,
            this.tssMapScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 733);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1157, 38);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssCoordinate
            // 
            this.tssCoordinate.AutoSize = false;
            this.tssCoordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssCoordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssCoordinate.Name = "tssCoordinate";
            this.tssCoordinate.Size = new System.Drawing.Size(257, 33);
            // 
            // tssMapScale
            // 
            this.tssMapScale.AutoSize = false;
            this.tssMapScale.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssMapScale.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssMapScale.Name = "tssMapScale";
            this.tssMapScale.Size = new System.Drawing.Size(257, 33);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnDrawLineLayer);
            this.panel1.Controls.Add(this.btnEditPolygonNode);
            this.panel1.Controls.Add(this.btnLayerAttributes);
            this.panel1.Controls.Add(this.chkShowLngLat);
            this.panel1.Controls.Add(this.btnLayerRenderer);
            this.panel1.Controls.Add(this.btnEndEdit);
            this.panel1.Controls.Add(this.btnEditPolygon);
            this.panel1.Controls.Add(this.btnEndSketch);
            this.panel1.Controls.Add(this.btnEndPart);
            this.panel1.Controls.Add(this.btnSketchPolygon);
            this.panel1.Controls.Add(this.btnMovePolygon);
            this.panel1.Controls.Add(this.btnShowLabel);
            this.panel1.Controls.Add(this.btnClassBreaks);
            this.panel1.Controls.Add(this.btnUnqiueValue);
            this.panel1.Controls.Add(this.btnSimpleRenderer);
            this.panel1.Controls.Add(this.btnIdentify);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnPan);
            this.panel1.Controls.Add(this.btnZoomOut);
            this.panel1.Controls.Add(this.btnZoomIn);
            this.panel1.Controls.Add(this.btnFullExtent);
            this.panel1.Controls.Add(this.btnProjection);
            this.panel1.Controls.Add(this.btnLoadLayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1011, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 707);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(10, 630);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 23);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDrawLineLayer
            // 
            this.btnDrawLineLayer.Location = new System.Drawing.Point(10, 401);
            this.btnDrawLineLayer.Name = "btnDrawLineLayer";
            this.btnDrawLineLayer.Size = new System.Drawing.Size(125, 23);
            this.btnDrawLineLayer.TabIndex = 19;
            this.btnDrawLineLayer.Text = "画线图层";
            this.btnDrawLineLayer.UseVisualStyleBackColor = true;
            this.btnDrawLineLayer.Visible = false;
            this.btnDrawLineLayer.Click += new System.EventHandler(this.btnDrawLineLayer_Click);
            // 
            // btnEditPolygonNode
            // 
            this.btnEditPolygonNode.Location = new System.Drawing.Point(10, 601);
            this.btnEditPolygonNode.Name = "btnEditPolygonNode";
            this.btnEditPolygonNode.Size = new System.Drawing.Size(125, 23);
            this.btnEditPolygonNode.TabIndex = 18;
            this.btnEditPolygonNode.Text = "编辑节点";
            this.btnEditPolygonNode.UseVisualStyleBackColor = true;
            this.btnEditPolygonNode.Visible = false;
            this.btnEditPolygonNode.Click += new System.EventHandler(this.btnEditPolygonNode_Click);
            // 
            // btnLayerAttributes
            // 
            this.btnLayerAttributes.Location = new System.Drawing.Point(10, 571);
            this.btnLayerAttributes.Margin = new System.Windows.Forms.Padding(2);
            this.btnLayerAttributes.Name = "btnLayerAttributes";
            this.btnLayerAttributes.Size = new System.Drawing.Size(125, 25);
            this.btnLayerAttributes.TabIndex = 5;
            this.btnLayerAttributes.Text = "图层属性表";
            this.btnLayerAttributes.UseVisualStyleBackColor = true;
            this.btnLayerAttributes.Visible = false;
            this.btnLayerAttributes.Click += new System.EventHandler(this.btnLayerAttributes_Click);
            // 
            // chkShowLngLat
            // 
            this.chkShowLngLat.AutoSize = true;
            this.chkShowLngLat.Location = new System.Drawing.Point(10, 520);
            this.chkShowLngLat.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowLngLat.Name = "chkShowLngLat";
            this.chkShowLngLat.Size = new System.Drawing.Size(96, 16);
            this.chkShowLngLat.TabIndex = 6;
            this.chkShowLngLat.Text = "显示地理坐标";
            this.chkShowLngLat.UseVisualStyleBackColor = true;
            this.chkShowLngLat.Visible = false;
            this.chkShowLngLat.CheckedChanged += new System.EventHandler(this.chkShowLngLat_CheckedChanged);
            // 
            // btnLayerRenderer
            // 
            this.btnLayerRenderer.Location = new System.Drawing.Point(10, 543);
            this.btnLayerRenderer.Margin = new System.Windows.Forms.Padding(2);
            this.btnLayerRenderer.Name = "btnLayerRenderer";
            this.btnLayerRenderer.Size = new System.Drawing.Size(125, 25);
            this.btnLayerRenderer.TabIndex = 4;
            this.btnLayerRenderer.Text = "示例：图层渲染";
            this.btnLayerRenderer.UseVisualStyleBackColor = true;
            this.btnLayerRenderer.Visible = false;
            this.btnLayerRenderer.Click += new System.EventHandler(this.btnLayerRenderer_Click);
            // 
            // btnEndEdit
            // 
            this.btnEndEdit.Location = new System.Drawing.Point(10, 487);
            this.btnEndEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEndEdit.Name = "btnEndEdit";
            this.btnEndEdit.Size = new System.Drawing.Size(125, 25);
            this.btnEndEdit.TabIndex = 17;
            this.btnEndEdit.Text = "结束编辑";
            this.btnEndEdit.UseVisualStyleBackColor = true;
            this.btnEndEdit.Visible = false;
            this.btnEndEdit.Click += new System.EventHandler(this.btnEndEdit_Click);
            // 
            // btnEditPolygon
            // 
            this.btnEditPolygon.Location = new System.Drawing.Point(10, 459);
            this.btnEditPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditPolygon.Name = "btnEditPolygon";
            this.btnEditPolygon.Size = new System.Drawing.Size(125, 25);
            this.btnEditPolygon.TabIndex = 16;
            this.btnEditPolygon.Text = "编辑多边形";
            this.btnEditPolygon.UseVisualStyleBackColor = true;
            this.btnEditPolygon.Visible = false;
            this.btnEditPolygon.Click += new System.EventHandler(this.btnEditPolygon_Click);
            // 
            // btnEndSketch
            // 
            this.btnEndSketch.Location = new System.Drawing.Point(76, 431);
            this.btnEndSketch.Margin = new System.Windows.Forms.Padding(2);
            this.btnEndSketch.Name = "btnEndSketch";
            this.btnEndSketch.Size = new System.Drawing.Size(68, 25);
            this.btnEndSketch.TabIndex = 15;
            this.btnEndSketch.Text = "结束描绘";
            this.btnEndSketch.UseVisualStyleBackColor = true;
            this.btnEndSketch.Visible = false;
            this.btnEndSketch.Click += new System.EventHandler(this.btnEndSketch_Click);
            // 
            // btnEndPart
            // 
            this.btnEndPart.Location = new System.Drawing.Point(4, 431);
            this.btnEndPart.Margin = new System.Windows.Forms.Padding(2);
            this.btnEndPart.Name = "btnEndPart";
            this.btnEndPart.Size = new System.Drawing.Size(68, 25);
            this.btnEndPart.TabIndex = 14;
            this.btnEndPart.Text = "结束部分";
            this.btnEndPart.UseVisualStyleBackColor = true;
            this.btnEndPart.Visible = false;
            this.btnEndPart.Click += new System.EventHandler(this.btnEndPart_Click);
            // 
            // btnSketchPolygon
            // 
            this.btnSketchPolygon.Location = new System.Drawing.Point(10, 371);
            this.btnSketchPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.btnSketchPolygon.Name = "btnSketchPolygon";
            this.btnSketchPolygon.Size = new System.Drawing.Size(125, 25);
            this.btnSketchPolygon.TabIndex = 13;
            this.btnSketchPolygon.Text = "描绘多边形";
            this.btnSketchPolygon.UseVisualStyleBackColor = true;
            this.btnSketchPolygon.Visible = false;
            this.btnSketchPolygon.Click += new System.EventHandler(this.btnSketchPolygon_Click);
            // 
            // btnMovePolygon
            // 
            this.btnMovePolygon.Location = new System.Drawing.Point(10, 343);
            this.btnMovePolygon.Margin = new System.Windows.Forms.Padding(2);
            this.btnMovePolygon.Name = "btnMovePolygon";
            this.btnMovePolygon.Size = new System.Drawing.Size(125, 25);
            this.btnMovePolygon.TabIndex = 12;
            this.btnMovePolygon.Text = "移动多边形";
            this.btnMovePolygon.UseVisualStyleBackColor = true;
            this.btnMovePolygon.Visible = false;
            this.btnMovePolygon.Click += new System.EventHandler(this.btnMovePolygon_Click);
            // 
            // btnShowLabel
            // 
            this.btnShowLabel.Location = new System.Drawing.Point(10, 315);
            this.btnShowLabel.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowLabel.Name = "btnShowLabel";
            this.btnShowLabel.Size = new System.Drawing.Size(125, 25);
            this.btnShowLabel.TabIndex = 11;
            this.btnShowLabel.Text = "显示注记";
            this.btnShowLabel.UseVisualStyleBackColor = true;
            this.btnShowLabel.Visible = false;
            this.btnShowLabel.Click += new System.EventHandler(this.btnShowLabel_Click);
            // 
            // btnClassBreaks
            // 
            this.btnClassBreaks.Location = new System.Drawing.Point(10, 287);
            this.btnClassBreaks.Margin = new System.Windows.Forms.Padding(2);
            this.btnClassBreaks.Name = "btnClassBreaks";
            this.btnClassBreaks.Size = new System.Drawing.Size(125, 25);
            this.btnClassBreaks.TabIndex = 10;
            this.btnClassBreaks.Text = "分级渲染";
            this.btnClassBreaks.UseVisualStyleBackColor = true;
            this.btnClassBreaks.Visible = false;
            this.btnClassBreaks.Click += new System.EventHandler(this.btnClassBreaks_Click);
            // 
            // btnUnqiueValue
            // 
            this.btnUnqiueValue.Location = new System.Drawing.Point(10, 259);
            this.btnUnqiueValue.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnqiueValue.Name = "btnUnqiueValue";
            this.btnUnqiueValue.Size = new System.Drawing.Size(125, 25);
            this.btnUnqiueValue.TabIndex = 9;
            this.btnUnqiueValue.Text = "唯一值渲染";
            this.btnUnqiueValue.UseVisualStyleBackColor = true;
            this.btnUnqiueValue.Visible = false;
            this.btnUnqiueValue.Click += new System.EventHandler(this.btnUnqiueValue_Click);
            // 
            // btnSimpleRenderer
            // 
            this.btnSimpleRenderer.Location = new System.Drawing.Point(10, 231);
            this.btnSimpleRenderer.Margin = new System.Windows.Forms.Padding(2);
            this.btnSimpleRenderer.Name = "btnSimpleRenderer";
            this.btnSimpleRenderer.Size = new System.Drawing.Size(125, 25);
            this.btnSimpleRenderer.TabIndex = 8;
            this.btnSimpleRenderer.Text = "简单渲染";
            this.btnSimpleRenderer.UseVisualStyleBackColor = true;
            this.btnSimpleRenderer.Visible = false;
            this.btnSimpleRenderer.Click += new System.EventHandler(this.btnSimpleRenderer_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(10, 203);
            this.btnIdentify.Margin = new System.Windows.Forms.Padding(2);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(125, 25);
            this.btnIdentify.TabIndex = 7;
            this.btnIdentify.Text = "查询";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Visible = false;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(10, 175);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(125, 25);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnPan
            // 
            this.btnPan.Location = new System.Drawing.Point(10, 147);
            this.btnPan.Margin = new System.Windows.Forms.Padding(2);
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(125, 25);
            this.btnPan.TabIndex = 5;
            this.btnPan.Text = "漫游";
            this.btnPan.UseVisualStyleBackColor = true;
            this.btnPan.Visible = false;
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(10, 119);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(125, 25);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.Text = "缩小";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Visible = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(10, 91);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(125, 25);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.Text = "放大";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Visible = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnFullExtent
            // 
            this.btnFullExtent.Location = new System.Drawing.Point(10, 63);
            this.btnFullExtent.Margin = new System.Windows.Forms.Padding(2);
            this.btnFullExtent.Name = "btnFullExtent";
            this.btnFullExtent.Size = new System.Drawing.Size(125, 25);
            this.btnFullExtent.TabIndex = 2;
            this.btnFullExtent.Text = "全范围显示";
            this.btnFullExtent.UseVisualStyleBackColor = true;
            this.btnFullExtent.Visible = false;
            this.btnFullExtent.Click += new System.EventHandler(this.btnFullExtent_Click);
            // 
            // btnProjection
            // 
            this.btnProjection.Location = new System.Drawing.Point(10, 6);
            this.btnProjection.Margin = new System.Windows.Forms.Padding(2);
            this.btnProjection.Name = "btnProjection";
            this.btnProjection.Size = new System.Drawing.Size(125, 25);
            this.btnProjection.TabIndex = 1;
            this.btnProjection.Text = "设置坐标系统";
            this.btnProjection.UseVisualStyleBackColor = true;
            this.btnProjection.Visible = false;
            this.btnProjection.Click += new System.EventHandler(this.btnProjection_Click);
            // 
            // btnLoadLayer
            // 
            this.btnLoadLayer.Location = new System.Drawing.Point(10, 34);
            this.btnLoadLayer.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadLayer.Name = "btnLoadLayer";
            this.btnLoadLayer.Size = new System.Drawing.Size(125, 25);
            this.btnLoadLayer.TabIndex = 0;
            this.btnLoadLayer.Text = "载入图层";
            this.btnLoadLayer.UseVisualStyleBackColor = true;
            this.btnLoadLayer.Visible = false;
            this.btnLoadLayer.Click += new System.EventHandler(this.btnLoadLayer_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1006, 26);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 707);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // moMap
            // 
            this.moMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moMap.BackColor = System.Drawing.Color.White;
            this.moMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.moMap.FlashColor = System.Drawing.Color.Green;
            this.moMap.Layers = moLayers1;
            this.moMap.Location = new System.Drawing.Point(214, 56);
            this.moMap.Margin = new System.Windows.Forms.Padding(2);
            this.moMap.Name = "moMap";
            this.moMap.SelectionColor = System.Drawing.Color.Cyan;
            this.moMap.Size = new System.Drawing.Size(941, 680);
            this.moMap.TabIndex = 3;
            this.moMap.MapScaleChanged += new MyMapObjects.moMapControl.MapScaleChangedHandle(this.moMap_MapScaleChanged);
            this.moMap.AfterTrackingLayerDraw += new MyMapObjects.moMapControl.AfterTrackingLayerDrawHandle(this.moMap_AfterTrackingLayerDraw);
            this.moMap.Load += new System.EventHandler(this.moMap_Load);
            this.moMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseClick);
            this.moMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseDown);
            this.moMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseMove);
            this.moMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseUp);
            // 
            // clbLayers
            // 
            this.clbLayers.AllowDrop = true;
            this.clbLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbLayers.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.clbLayers.CheckOnClick = true;
            this.clbLayers.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.clbLayers.FormattingEnabled = true;
            this.clbLayers.Location = new System.Drawing.Point(0, 57);
            this.clbLayers.Name = "clbLayers";
            this.clbLayers.Size = new System.Drawing.Size(215, 679);
            this.clbLayers.TabIndex = 4;
            this.clbLayers.SelectedIndexChanged += new System.EventHandler(this.clbLayers_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.档案ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 26);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 档案ToolStripMenuItem
            // 
            this.档案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.档案ToolStripMenuItem.Name = "档案ToolStripMenuItem";
            this.档案ToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.档案ToolStripMenuItem.Text = "档案";
            // 
            // 开启ToolStripMenuItem
            // 
            this.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            this.开启ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.开启ToolStripMenuItem.Text = "开启";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置坐标系统ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 设置坐标系统ToolStripMenuItem
            // 
            this.设置坐标系统ToolStripMenuItem.Name = "设置坐标系统ToolStripMenuItem";
            this.设置坐标系统ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.设置坐标系统ToolStripMenuItem.Text = "设置坐标系统";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton18,
            this.toolStripButton2,
            this.toolStripButton17,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton7,
            this.toolStripButton5,
            this.toolStripButton8,
            this.toolStripButton6,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripButton15,
            this.toolStripButton16,
            this.layerComboBox,
            this.btnCancelAllOps});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 28);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "开启资料夹";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.AutoSize = false;
            this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton18.Text = "toolStripButton18";
            this.toolStripButton18.ToolTipText = "设定投影坐标";
            this.toolStripButton18.Click += new System.EventHandler(this.toolStripButton18_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "检视范围";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.AutoSize = false;
            this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton17.Text = "toolStripButton17";
            this.toolStripButton17.ToolTipText = "漫游";
            this.toolStripButton17.Click += new System.EventHandler(this.toolStripButton17_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "放大";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "缩小";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.ToolTipText = "注记";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "选取";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.AutoSize = false;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "移动";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "查询栏位";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.AutoSize = false;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.ToolTipText = "绘制多边形";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.AutoSize = false;
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton10.Text = "toolStripButton10";
            this.toolStripButton10.ToolTipText = "绘制折线";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.AutoSize = false;
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton11.Text = "toolStripButton11";
            this.toolStripButton11.ToolTipText = "暂停编辑";
            this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.AutoSize = false;
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton12.Text = "toolStripButton12";
            this.toolStripButton12.ToolTipText = "结束编辑";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.AutoSize = false;
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton13.Text = "toolStripButton13";
            this.toolStripButton13.ToolTipText = "编辑节点";
            this.toolStripButton13.Click += new System.EventHandler(this.toolStripButton13_Click);
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.AutoSize = false;
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton14.Text = "toolStripButton14";
            this.toolStripButton14.ToolTipText = "查看属性表";
            this.toolStripButton14.Click += new System.EventHandler(this.toolStripButton14_Click);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.AutoSize = false;
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton15.Text = "toolStripButton15";
            this.toolStripButton15.ToolTipText = "图层渲染";
            this.toolStripButton15.Click += new System.EventHandler(this.toolStripButton15_Click);
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.AutoSize = false;
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(30, 25);
            this.toolStripButton16.Text = "toolStripButton16";
            this.toolStripButton16.ToolTipText = "导出";
            this.toolStripButton16.Click += new System.EventHandler(this.toolStripButton16_Click);
            // 
            // layerComboBox
            // 
            this.layerComboBox.Name = "layerComboBox";
            this.layerComboBox.Size = new System.Drawing.Size(121, 28);
            this.layerComboBox.Visible = false;
            this.layerComboBox.Click += new System.EventHandler(this.layerComboBox_Click);
            // 
            // btnCancelAllOps
            // 
            this.btnCancelAllOps.AutoSize = false;
            this.btnCancelAllOps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelAllOps.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelAllOps.Image")));
            this.btnCancelAllOps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelAllOps.Name = "btnCancelAllOps";
            this.btnCancelAllOps.Size = new System.Drawing.Size(30, 25);
            this.btnCancelAllOps.Text = "toolStripButton19";
            this.btnCancelAllOps.Visible = false;
            this.btnCancelAllOps.Click += new System.EventHandler(this.btnCancelAllOps_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 54);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 679);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(3, 54);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1003, 3);
            this.splitter3.TabIndex = 8;
            this.splitter3.TabStop = false;
            // 
            // FrmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 771);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.clbLayers);
            this.Controls.Add(this.moMap);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIS 数据编辑系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMap_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnLoadLayer;
        private MyMapObjects.moMapControl moMap;
        private System.Windows.Forms.ToolStripStatusLabel tssCoordinate;
        private System.Windows.Forms.ToolStripStatusLabel tssMapScale;
        private System.Windows.Forms.Button btnProjection;
        private System.Windows.Forms.Button btnFullExtent;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnPan;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnShowLabel;
        private System.Windows.Forms.Button btnClassBreaks;
        private System.Windows.Forms.Button btnUnqiueValue;
        private System.Windows.Forms.Button btnSimpleRenderer;
        private System.Windows.Forms.Button btnSketchPolygon;
        private System.Windows.Forms.Button btnMovePolygon;
        private System.Windows.Forms.Button btnEndEdit;
        private System.Windows.Forms.Button btnEditPolygon;
        private System.Windows.Forms.Button btnEndSketch;
        private System.Windows.Forms.Button btnEndPart;
        private System.Windows.Forms.Button btnLayerRenderer;
        private System.Windows.Forms.Button btnLayerAttributes;
        private System.Windows.Forms.CheckBox chkShowLngLat;
        private System.Windows.Forms.Button btnEditPolygonNode;
        private System.Windows.Forms.CheckedListBox clbLayers;
        private System.Windows.Forms.Button btnDrawLineLayer;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 档案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置坐标系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.ToolStripButton toolStripButton17;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ToolStripButton toolStripButton18;
        private System.Windows.Forms.ToolStripComboBox layerComboBox;
        private System.Windows.Forms.ToolStripButton btnCancelAllOps;
    }
}

