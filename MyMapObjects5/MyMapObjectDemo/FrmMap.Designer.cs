
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMapScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCoordinate,
            this.tssMapScale});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(843, 38);
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
            this.panel1.Location = new System.Drawing.Point(697, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 565);
            this.panel1.TabIndex = 1;
            // 
            // btnLayerAttributes
            // 
            this.btnLayerAttributes.Location = new System.Drawing.Point(10, 539);
            this.btnLayerAttributes.Margin = new System.Windows.Forms.Padding(2);
            this.btnLayerAttributes.Name = "btnLayerAttributes";
            this.btnLayerAttributes.Size = new System.Drawing.Size(125, 25);
            this.btnLayerAttributes.TabIndex = 5;
            this.btnLayerAttributes.Text = "示例：图层属性表";
            this.btnLayerAttributes.UseVisualStyleBackColor = true;
            this.btnLayerAttributes.Click += new System.EventHandler(this.btnLayerAttributes_Click);
            // 
            // chkShowLngLat
            // 
            this.chkShowLngLat.AutoSize = true;
            this.chkShowLngLat.Location = new System.Drawing.Point(10, 488);
            this.chkShowLngLat.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowLngLat.Name = "chkShowLngLat";
            this.chkShowLngLat.Size = new System.Drawing.Size(96, 16);
            this.chkShowLngLat.TabIndex = 6;
            this.chkShowLngLat.Text = "显示地理坐标";
            this.chkShowLngLat.UseVisualStyleBackColor = true;
            this.chkShowLngLat.CheckedChanged += new System.EventHandler(this.chkShowLngLat_CheckedChanged);
            // 
            // btnLayerRenderer
            // 
            this.btnLayerRenderer.Location = new System.Drawing.Point(10, 511);
            this.btnLayerRenderer.Margin = new System.Windows.Forms.Padding(2);
            this.btnLayerRenderer.Name = "btnLayerRenderer";
            this.btnLayerRenderer.Size = new System.Drawing.Size(125, 25);
            this.btnLayerRenderer.TabIndex = 4;
            this.btnLayerRenderer.Text = "示例：图层渲染";
            this.btnLayerRenderer.UseVisualStyleBackColor = true;
            this.btnLayerRenderer.Click += new System.EventHandler(this.btnLayerRenderer_Click);
            // 
            // btnEndEdit
            // 
            this.btnEndEdit.Location = new System.Drawing.Point(10, 455);
            this.btnEndEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEndEdit.Name = "btnEndEdit";
            this.btnEndEdit.Size = new System.Drawing.Size(125, 25);
            this.btnEndEdit.TabIndex = 17;
            this.btnEndEdit.Text = "结束编辑";
            this.btnEndEdit.UseVisualStyleBackColor = true;
            this.btnEndEdit.Click += new System.EventHandler(this.btnEndEdit_Click);
            // 
            // btnEditPolygon
            // 
            this.btnEditPolygon.Location = new System.Drawing.Point(10, 427);
            this.btnEditPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditPolygon.Name = "btnEditPolygon";
            this.btnEditPolygon.Size = new System.Drawing.Size(125, 25);
            this.btnEditPolygon.TabIndex = 16;
            this.btnEditPolygon.Text = "编辑多边形";
            this.btnEditPolygon.UseVisualStyleBackColor = true;
            this.btnEditPolygon.Click += new System.EventHandler(this.btnEditPolygon_Click);
            // 
            // btnEndSketch
            // 
            this.btnEndSketch.Location = new System.Drawing.Point(76, 399);
            this.btnEndSketch.Margin = new System.Windows.Forms.Padding(2);
            this.btnEndSketch.Name = "btnEndSketch";
            this.btnEndSketch.Size = new System.Drawing.Size(68, 25);
            this.btnEndSketch.TabIndex = 15;
            this.btnEndSketch.Text = "结束描绘";
            this.btnEndSketch.UseVisualStyleBackColor = true;
            this.btnEndSketch.Click += new System.EventHandler(this.btnEndSketch_Click);
            // 
            // btnEndPart
            // 
            this.btnEndPart.Location = new System.Drawing.Point(4, 399);
            this.btnEndPart.Margin = new System.Windows.Forms.Padding(2);
            this.btnEndPart.Name = "btnEndPart";
            this.btnEndPart.Size = new System.Drawing.Size(68, 25);
            this.btnEndPart.TabIndex = 14;
            this.btnEndPart.Text = "结束部分";
            this.btnEndPart.UseVisualStyleBackColor = true;
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
            this.btnLoadLayer.Click += new System.EventHandler(this.btnLoadLayer_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(692, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 565);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
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
            this.moMap.Location = new System.Drawing.Point(0, 0);
            this.moMap.Margin = new System.Windows.Forms.Padding(2);
            this.moMap.Name = "moMap";
            this.moMap.SelectionColor = System.Drawing.Color.Cyan;
            this.moMap.Size = new System.Drawing.Size(694, 646);
            this.moMap.TabIndex = 3;
            this.moMap.MapScaleChanged += new MyMapObjects.moMapControl.MapScaleChangedHandle(this.moMap_MapScaleChanged);
            this.moMap.AfterTrackingLayerDraw += new MyMapObjects.moMapControl.AfterTrackingLayerDrawHandle(this.moMap_AfterTrackingLayerDraw);
            this.moMap.Load += new System.EventHandler(this.moMap_Load);
            this.moMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseClick);
            this.moMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseDown);
            this.moMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseMove);
            this.moMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseUp);
            // 
            // FrmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 603);
            this.Controls.Add(this.moMap);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMapObjectDemo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMap_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}

