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
using System.Windows.Forms.VisualStyles;

namespace MyMapObjectDemo
{
    public partial class moMapRenender : Form
    {
        #region 字段

        private MyMapObjects.moMapLayer _Layer; //輸入圖層對象
        private MyMapObjects.moRenderer _Renderer; //輸出的圖層對象
        private MyMapObjects.moMapControl _moMap; //地圖對象
        



        #endregion

        #region 方法

        internal void SetData(MyMapObjects.moMapLayer layer, MyMapObjects.moMapControl moMap)
        { 
            _Layer = layer;
            _moMap = moMap;
            InitializeFieldComboBoxes();
            FillLayerComboBox();
            InitializeLayerComboBox();
        }
        private void InitializeLayerComboBox()
        {
            comboBoxLayer.Items.Clear();
            foreach (var layer in _moMap.Layers)
            {
                comboBoxLayer.Items.Add(layer.Name);
            }
            if (comboBoxLayer.Items.Count > 0)
            {
                comboBoxLayer.SelectedIndex = 0;
            }
        }
        private void FillLayerComboBox()
        {
            comboBoxLayer.Items.Clear();
            foreach (var layer in _moMap.Layers)
            {
                comboBoxLayer.Items.Add(layer.Name);
            }
            if (comboBoxLayer.Items.Count > 0)
            {
                comboBoxLayer.SelectedIndex = 0;
            }
        }
        internal void GetData(out MyMapObjects.moRenderer renderer)
        {
            renderer = _Renderer;
 
        }

        #endregion



        public moMapRenender()
        {
            InitializeComponent();
            InitializeTabPages();
            CreateSimpleRenderer();

        }
        private void InitializeTabPages()
        {
            // 初始化 tabPage1 的控件
            tabPage1.Text = "简单渲染";
            panelColor1.Size = new Size(50, 50);
            panelColor1.BackColor = Color.FromArgb(204,255,153);
            panelColor1.BorderStyle = BorderStyle.FixedSingle;
            panelColor1.Location = new Point(85, 45);
            panelColor1.Click += new EventHandler(panelColor1_Click);
            tabPage1.Controls.Add(panelColor1);

            // 设置选择颜色文本
            TextBox textColor = new TextBox();
            textColor.Location = new Point(20, 60);
            textColor.Width = 100;
            textColor.Text = "选择颜色：";
            textColor.ReadOnly = true; // 設置為只讀
            textColor.BorderStyle = BorderStyle.None; // 去掉邊框
            tabPage1.Controls.Add(textColor);

            // 初始化 tabPage2 的控件
            tabPage2.Text = "分级渲染";

            // 设置 labelField2
            Label labelField2 = new Label();
            labelField2.Text = "字段：";
            labelField2.Location = new Point(20, 20);
            labelField2.BackColor = Color.Transparent;
            labelField2.AutoSize = true;
            tabPage2.Controls.Add(labelField2);

            // 设置 comboBoxField2
            comboBoxField2 = new ComboBox();
            comboBoxField2.Location = new Point(20, 40);
            comboBoxField2.Width = 200;
            comboBoxField2.SelectedIndexChanged += comboBoxField2_SelectedIndexChanged;
            tabPage2.Controls.Add(comboBoxField2);

            // 设置 labelStartColor
            Label labelStartColor = new Label();
            labelStartColor.Text = "起始颜色(小)：";
            labelStartColor.Location = new Point(20, 80);
            labelStartColor.BackColor = Color.Transparent;
            labelStartColor.AutoSize = true;
            tabPage2.Controls.Add(labelStartColor);

            // 设置 panelColor2
            panelColor2 = new Panel();
            panelColor2.Size = new Size(50, 50);
            panelColor2.BackColor = Color.FromArgb(255, 255, 185); // 設置為漸變色的起始顏色
            panelColor2.BorderStyle = BorderStyle.FixedSingle;
            panelColor2.Location = new Point(115, 75);
            panelColor2.Click += new EventHandler(panelColor2_Click);
            tabPage2.Controls.Add(panelColor2);

            // 设置 labelEndColor
            Label labelEndColor = new Label();
            labelEndColor.Text = "终止颜色(大)：";
            labelEndColor.Location = new Point(20, 140);
            labelEndColor.BackColor = Color.Transparent;
            labelEndColor.AutoSize = true;
            tabPage2.Controls.Add(labelEndColor);

            // 设置 panelColor3
            panelColor3 = new Panel();
            panelColor3.Size = new Size(50, 50);
            panelColor3.BackColor = Color.FromArgb(128, 128, 0); // 設置為漸變色的終止顏色
            panelColor3.BorderStyle = BorderStyle.FixedSingle;
            panelColor3.Location = new Point(115, 135);
            panelColor3.Click += new EventHandler(panelColor3_Click);
            tabPage2.Controls.Add(panelColor3);

            // 设置 labelClassBreaks
            Label labelClassBreaks = new Label();
            labelClassBreaks.Text = "分级数：";
            labelClassBreaks.Location = new Point(20, 200);
            labelClassBreaks.BackColor = Color.Transparent;
            labelClassBreaks.AutoSize = true;
            tabPage2.Controls.Add(labelClassBreaks);

            // 设置 textBoxClassBreaks
            textBoxClassBreaks = new TextBox();
            textBoxClassBreaks.Location = new Point(100, 200);
            textBoxClassBreaks.Width = 200;
            tabPage2.Controls.Add(textBoxClassBreaks);

            // 设置 listBoxFields2
            listBoxFields2 = new ListBox();
            listBoxFields2.Location = new Point(315, 25); // 放在右邊
            listBoxFields2.Width = 200;
            listBoxFields2.Height = 280;
            tabPage2.Controls.Add(listBoxFields2);

            // 设置 exampleTextBox
            TextBox exampleTextBox = new TextBox();
            exampleTextBox.Location = new Point(100, 230);
            exampleTextBox.Width = 200;
            exampleTextBox.Text = "例：100, 500, 1000...";
            exampleTextBox.ReadOnly = true; // 設置為只讀
            exampleTextBox.BorderStyle = BorderStyle.None; // 去掉邊
            tabPage2.Controls.Add(exampleTextBox);

            // 初始化 tabPage3 的控件
            tabPage3.Text = "唯一值渲染";

            // 设置 labelField3
            Label labelField3 = new Label();
            labelField3.Text = "字段：";
            labelField3.Location = new Point(20, 20);
            labelField3.BackColor = Color.Transparent;
            labelField3.AutoSize = true;
            tabPage3.Controls.Add(labelField3);

            // 设置 comboBoxField3
            comboBoxField3 = new ComboBox();
            comboBoxField3.Location = new Point(20, 40);
            comboBoxField3.Width = 200;
            comboBoxField3.SelectedIndexChanged += comboBoxField3_SelectedIndexChanged;
            tabPage3.Controls.Add(comboBoxField3);

            // 设置 listBoxFields3
            listBoxFields3 = new ListBox();
            listBoxFields3.Location = new Point(315, 25); // 放在右邊
            listBoxFields3.Width = 200;
            listBoxFields3.Height = 280;
            tabPage3.Controls.Add(listBoxFields3);

            // 初始化 tabPage4 的控件
            tabPage4.Text = "点/线符号";

            // 设置 labelLayer
            Label labelLayer = new Label();
            labelLayer.Text = "图层：";
            labelLayer.Location = new Point(20, 20);
            labelLayer.BackColor = Color.Transparent;
            labelLayer.AutoSize = true;
            tabPage4.Controls.Add(labelLayer);

            // 设置 comboBoxLayer
            comboBoxLayer = new ComboBox();
            comboBoxLayer.Location = new Point(20, 40);
            comboBoxLayer.Width = 200;
            comboBoxLayer.SelectedIndexChanged += new EventHandler(comboBoxLayer_SelectedIndexChanged);
            tabPage4.Controls.Add(comboBoxLayer);

            // 设置 labelStyle
            labelStyle = new Label();
            labelStyle.Text = "样式：";
            labelStyle.Location = new Point(20, 80);
            labelStyle.BackColor = Color.Transparent;
            labelStyle.AutoSize = true;
            tabPage4.Controls.Add(labelStyle);

            // 设置 comboBoxStyle
            comboBoxStyle = new ComboBox();
            comboBoxStyle.Location = new Point(20, 100);
            comboBoxStyle.Width = 200;
            tabPage4.Controls.Add(comboBoxStyle);

            // 设置 labelSize
            labelSize = new Label();
            labelSize.Text = "大小：";
            labelSize.Location = new Point(20, 140);
            labelSize.BackColor = Color.Transparent;
            labelSize.AutoSize = true;
            tabPage4.Controls.Add(labelSize);

            // 设置 numericUpDownSize
            numericUpDownSize = new NumericUpDown();
            numericUpDownSize.Location = new Point(20, 160);
            numericUpDownSize.Width = 200;
            numericUpDownSize.Minimum = 1;
            numericUpDownSize.Maximum = 10;
            tabPage4.Controls.Add(numericUpDownSize);

            // 设置 labelColor
            labelColor = new Label();
            labelColor.Text = "颜色：";
            labelColor.Location = new Point(20, 200);
            labelColor.BackColor = Color.Transparent;
            labelColor.AutoSize = true;
            tabPage4.Controls.Add(labelColor);

            // 设置 panelSymbolColor
            panelSymbolColor = new Panel();
            panelSymbolColor.Size = new Size(50, 50);
            panelSymbolColor.Location = new Point(20, 220);
            panelSymbolColor.BackColor = Color.Black;
            panelSymbolColor.BorderStyle = BorderStyle.FixedSingle;
            panelSymbolColor.Click += new EventHandler(panelSymbolColor_Click);
            tabPage4.Controls.Add(panelSymbolColor);

            // 设置 buttonApplySymbol
            buttonApplySymbol = new Button();
            buttonApplySymbol.Text = "应用符号";
            buttonApplySymbol.Location = new Point(20, 280);
            buttonApplySymbol.Click += new EventHandler(buttonApplySymbol_Click);
            tabPage4.Controls.Add(buttonApplySymbol);
        }
        private void InitializeFieldComboBoxes()
        {
            if (_Layer != null)
            {
                FillFieldComboBox(comboBoxField2, _Layer, new List<MyMapObjects.moValueTypeConstant>
                {
                    MyMapObjects.moValueTypeConstant.dInt16,
                    MyMapObjects.moValueTypeConstant.dInt32,
                    MyMapObjects.moValueTypeConstant.dDouble // 替換 dString
                });
                FillFieldComboBox(comboBoxField3, _Layer, new List<MyMapObjects.moValueTypeConstant>
                {
                    MyMapObjects.moValueTypeConstant.dText,
                    MyMapObjects.moValueTypeConstant.dInt16,
                    MyMapObjects.moValueTypeConstant.dInt32 // 替換 dFloat
                });

            }
        }

        private MyMapObjects.moMapLayer GetLayerByName(string layerName)
        {
            foreach (var layer in _moMap.Layers)
            {
                if (layer.Name == layerName)
                {
                    return layer;
                }
            }
            return null;
        }
        private void FillFieldComboBox(ComboBox comboBox, MyMapObjects.moMapLayer layer, List<MyMapObjects.moValueTypeConstant> validTypes)
        {
            comboBox.Items.Clear();
            if (layer != null)
            {
                for (int i = 0; i < layer.AttributeFields.Count; i++)
                {
                    var field = layer.AttributeFields.GetItem(i);
                    if (validTypes.Contains(field.ValueType))
                    {
                        comboBox.Items.Add(field.Name);
                    }
                }
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }
        private void comboBoxSymbolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSymbolType.SelectedItem.ToString() == "Line")
            {
                comboBoxLineStyle.Visible = true;
            }
            else
            {
                comboBoxLineStyle.Visible = false;
            }
        }
        private void panelSymbolColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panelSymbolColor.BackColor = colorDialog1.Color;
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //裝載窗體
        private void moMapRenender_Load(object sender, EventArgs e)
        {
            //這時已經獲得輸入的對象Layer
            //為接下來的用戶交互作相應的準備工作
            // 初始化符號選擇控件
            
            
        }
        private void InitializeSimpleRendererTab()
        {
            // 查找一个多边形图层
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;
            // 新建一个简单渲染对象
            MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
            MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
            // 可以继续设置符号的颜色等特征
            sRenderer.Symbol = sSymbol;
            sLayer.Renderer = sRenderer;
            _moMap.RedrawMap();
        }
        private void InitializeSimpleRenderer()
        {
            if (_Layer != null)
            {
                MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol
                {
                    Color = panelColor1.BackColor // 根據用戶選擇設置顏色
                };
                sRenderer.Symbol = sSymbol;
                _Layer.Renderer = sRenderer;
                _moMap.RedrawMap();
            }
        }

        private MyMapObjects.moMapLayer GetPolygonLayer()
        {
            if (_moMap == null) return null;
            Int32 sLayerCount = _moMap.Layers.Count;
            MyMapObjects.moMapLayer sLayer = null;
            for (Int32 i = 0; i <= sLayerCount - 1; i++)
            {
                if (_moMap.Layers.GetItem(i).ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
                {
                    sLayer = _moMap.Layers.GetItem(i);
                    break;
                }
            }
            return sLayer;
        }

        private void InitializeUniqueValueRendererTab()
        {
            // 查找一个多边形图层
            MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
            if (sLayer == null)
                return;

            if (comboBoxField2.SelectedItem == null)
                return;

            // 获取字段名称和索引
            string sFieldName = comboBoxField2.SelectedItem.ToString();
            Int32 sFieldIndex = sLayer.AttributeFields.FindField(sFieldName);
            if (sFieldIndex < 0)
                return;

            // 获取字段类型
            MyMapObjects.moValueTypeConstant sFieldType = sLayer.AttributeFields.GetItem(sFieldIndex).ValueType;

            // 新建一个渲染对象
            MyMapObjects.moUniqueValueRenderer sRenderer = new MyMapObjects.moUniqueValueRenderer();
            sRenderer.Field = sFieldName;

            // 读出所有值
            HashSet<string> sValues = new HashSet<string>();
            Int32 sFeatureCount = sLayer.Features.Count;
            for (Int32 i = 0; i < sFeatureCount; i++)
            {
                var fieldValue = sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                string sValue = fieldValue.ToString();
                if (!sValues.Contains(sValue))
                {
                    sValues.Add(sValue);
                }
            }

            // 为每个唯一值分配符号
            Random random = new Random();
            foreach (string sValue in sValues)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol
                {
                    Color = randomColor
                };
                sRenderer.AddUniqueValue(sValue, sSymbol);
            }
            sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol
            {
                Color = Color.Gray // 预设符号颜色
            };

            _Renderer = sRenderer;
        }
        private void comboBoxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLayer.SelectedItem == null)
                return;

            MyMapObjects.moMapLayer selectedLayer = GetLayerByName(comboBoxLayer.SelectedItem.ToString());
            if (selectedLayer == null)
                return;

            if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                comboBoxStyle.Items.Clear();
                comboBoxStyle.Items.AddRange(new string[] { "实线", "虚线" });
                comboBoxStyle.Enabled = true;
                numericUpDownSize.Enabled = true;
                panelSymbolColor.Enabled = true;
            }
            else if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                comboBoxStyle.Items.Clear();
                comboBoxStyle.Items.AddRange(new string[] { "空心圆", "实心圆", "空心方形", "实心方形", "空心三角形", "实心三角形", "有点空心圆", "有点实心圆" });
                comboBoxStyle.Enabled = true;
                numericUpDownSize.Enabled = true;
                panelSymbolColor.Enabled = true;
            }
            else
            {
                comboBoxStyle.Enabled = false;
                numericUpDownSize.Enabled = false;
                panelSymbolColor.Enabled = false;
            }
        }



        private void InitializeClassBreaksRendererTab()
        {
            if (_Layer == null) return;

            string sFieldName = comboBoxField2.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(sFieldName)) return;

            Int32 sFieldIndex = _Layer.AttributeFields.FindField(sFieldName);
            if (sFieldIndex < 0) return;

            if (_Layer.AttributeFields.GetItem(sFieldIndex).ValueType != MyMapObjects.moValueTypeConstant.dDouble)
                return;

            MyMapObjects.moClassBreaksRenderer sRenderer = new MyMapObjects.moClassBreaksRenderer
            {
                Field = sFieldName
            };

            List<double> sValues = new List<double>();
            Int32 sFeatureCount = _Layer.Features.Count;
            for (Int32 i = 0; i < sFeatureCount; i++)
            {
                double sValue = (double)_Layer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                sValues.Add(sValue);
            }

            double sMinValue = sValues.Min();
            double sMaxValue = sValues.Max();
            double[] classBreaks = ParseClassBreaks(textBoxClassBreaks.Text, sMinValue, sMaxValue);
            foreach (double sValue in classBreaks)
            {
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                sRenderer.AddBreakValue(sValue, sSymbol);
            }

            Color sStartColor = panelColor2.BackColor;
            Color sEndColor = panelColor3.BackColor;
            RampColor(sStartColor, sEndColor, sRenderer);
            sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol();

            _Renderer = sRenderer;
        }
        private void RampColor(Color startColor, Color endColor, MyMapObjects.moClassBreaksRenderer renderer)
        {
            int steps = renderer.BreakCount;
            for (int i = 0; i < steps; i++)
            {
                float ratio = (float)i / (steps - 1);
                int r = (int)(startColor.R * (1 - ratio) + endColor.R * ratio);
                int g = (int)(startColor.G * (1 - ratio) + endColor.G * ratio);
                int b = (int)(startColor.B * (1 - ratio) + endColor.B * ratio);
                renderer.SetSymbol(i, new MyMapObjects.moSimpleFillSymbol { Color = Color.FromArgb(r, g, b) });
            }
        }
        private double[] ParseClassBreaks(string text, double minValue, double maxValue)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new double[] { minValue, minValue + (maxValue - minValue) / 4, minValue + (maxValue - minValue) / 2, minValue + 3 * (maxValue - minValue) / 4, maxValue };
            }

            string[] parts = text.Split(',');
            double[] breaks = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!double.TryParse(parts[i], out double value))
                {
                    value = minValue + i * (maxValue - minValue) / (parts.Length - 1);
                }
                breaks[i] = value;
            }
            return breaks;
        }

        //確認按鈕
        private void btn1_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                _Renderer = CreateSimpleRenderer();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                _Renderer = CreateClassBreaksRenderer();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                _Renderer = CreateUniqueValueRenderer();
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                ApplySymbol(); // 应用符号到地图
            }
            this.DialogResult = DialogResult.OK;
        }
        private void ApplySymbol()
        {
            if (comboBoxLayer.SelectedItem == null)
                return;

            MyMapObjects.moMapLayer selectedLayer = GetLayerByName(comboBoxLayer.SelectedItem.ToString());
            if (selectedLayer == null)
                return;

            if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                MyMapObjects.moSimpleLineSymbol lineSymbol = new MyMapObjects.moSimpleLineSymbol();
                lineSymbol.Style = comboBoxStyle.SelectedItem.ToString() == "实线" ?
                                   MyMapObjects.moSimpleLineSymbolStyleConstant.Solid :
                                   MyMapObjects.moSimpleLineSymbolStyleConstant.Dash;
                lineSymbol.Size = (float)numericUpDownSize.Value;
                lineSymbol.Color = panelSymbolColor.BackColor;
                selectedLayer.Renderer = new MyMapObjects.moSimpleRenderer { Symbol = lineSymbol };
            }
            else if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                MyMapObjects.moSimpleMarkerSymbol pointSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                switch (comboBoxStyle.SelectedItem.ToString())
                {
                    case "空心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.Circle;
                        break;
                    case "实心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidCircle;
                        break;
                    case "空心方形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.Square;
                        break;
                    case "实心方形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidSquare;
                        break;
                    case "空心三角形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.Triangle;
                        break;
                    case "实心三角形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidTriangle;
                        break;
                    case "有点空心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.CircleCircle;
                        break;
                    case "有点实心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.CircleDot;
                        break;
                }
                pointSymbol.Size = (float)numericUpDownSize.Value;
                pointSymbol.Color = panelSymbolColor.BackColor;
                selectedLayer.Renderer = new MyMapObjects.moSimpleRenderer { Symbol = pointSymbol };
            }

            _moMap.RedrawMap();
        }

        private void ApplySymbolSettings()
        {
            MyMapObjects.moMapLayer selectedLayer = GetLayerByName(comboBoxLayer.SelectedItem.ToString());

            if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                MyMapObjects.moSimpleMarkerSymbol pointSymbol = new MyMapObjects.moSimpleMarkerSymbol
                {
                    Color = panelSymbolColor.BackColor,
                    Size = (int)numericUpDownSize.Value
                };
                // 將符號應用到點圖層
                MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer
                {
                    Symbol = pointSymbol
                };
                selectedLayer.Renderer = sRenderer;
            }
            else if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                MyMapObjects.moSimpleLineSymbol lineSymbol = new MyMapObjects.moSimpleLineSymbol
                {
                    Color = panelSymbolColor.BackColor,
                    Size = (int)numericUpDownSize.Value,
                    Style = comboBoxLineStyle.SelectedItem.ToString() == "Solid" ? MyMapObjects.moSimpleLineSymbolStyleConstant.Solid : MyMapObjects.moSimpleLineSymbolStyleConstant.Dash
                };
                // 將符號應用到線圖層
                MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer
                {
                    Symbol = lineSymbol
                };
                selectedLayer.Renderer = sRenderer;
            }
            _moMap.RedrawMap();
        }
        private MyMapObjects.moRenderer CreateSimpleRenderer()
        {
            MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
            MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol
            {
                Color = panelColor1.BackColor // 根據用戶選擇設置顏色
            };
            sRenderer.Symbol = sSymbol;
            return sRenderer;
        }
        private MyMapObjects.moRenderer CreateUniqueValueRenderer()
        {
            MyMapObjects.moUniqueValueRenderer sRenderer = new MyMapObjects.moUniqueValueRenderer
            {
                Field = comboBoxField2.SelectedItem.ToString() // 根據選擇的欄位設置
            };

            // 讀出所有值
            HashSet<string> sValues = new HashSet<string>();
            Int32 sFeatureCount = _Layer.Features.Count;
            Int32 sFieldIndex = _Layer.AttributeFields.FindField(sRenderer.Field);
            for (Int32 i = 0; i < sFeatureCount; i++)
            {
                var fieldValue = _Layer.Features.GetItem(i).Attributes.GetItem(sFieldIndex);
                string sValue = fieldValue.ToString();
                if (!sValues.Contains(sValue))
                {
                    sValues.Add(sValue);
                }
            }

            // 為每個唯一值分配符號
            Random random = new Random();
            foreach (string sValue in sValues)
            {
                Color randomColor = Color.FromArgb(random.Next(200, 256), random.Next(200, 256), random.Next(200, 256)); // 使用亮色系
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol
                {
                    Color = randomColor
                };
                sRenderer.AddUniqueValue(sValue, sSymbol);
            }
            sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol
            {
                Color = Color.Gray // 預設符號顏色
            };

            return sRenderer;
        }

        private MyMapObjects.moRenderer CreateClassBreaksRenderer()
        {
            MyMapObjects.moClassBreaksRenderer sRenderer = new MyMapObjects.moClassBreaksRenderer
            {
                Field = comboBoxField2.SelectedItem.ToString() // 根據選擇的欄位設置
            };

            // 讀出所有值
            List<double> sValues = new List<double>();
            Int32 sFeatureCount = _Layer.Features.Count;
            Int32 sFieldIndex = _Layer.AttributeFields.FindField(sRenderer.Field);
            for (Int32 i = 0; i < sFeatureCount; i++)
            {
                double sValue = Convert.ToDouble(_Layer.Features.GetItem(i).Attributes.GetItem(sFieldIndex));
                sValues.Add(sValue);
            }

            // 获取最小最大值，并分为5級
            double sMinValue = sValues.Min();
            double sMaxValue = sValues.Max();
            double[] classBreaks = ParseClassBreaks(textBoxClassBreaks.Text, sMinValue, sMaxValue);
            foreach (double sValue in classBreaks)
            {
                MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                sRenderer.AddBreakValue(sValue, sSymbol);
            }

            // 使用選擇的開始和結束顏色進行漸變色
            Color sStartColor = panelColor2.BackColor;
            Color sEndColor = panelColor3.BackColor;
            RampColor(sStartColor, sEndColor, sRenderer);

            return sRenderer;
        }

        //取消按鈕
        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnChooseColor1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                // 使用選擇的顏色更新渲染設置
            }
        }

        private void btnChooseColor2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                panelColor2.BackColor = selectedColor;

                if (_Layer != null && comboBoxField2.SelectedItem != null)
                {
                    _Renderer = CreateClassBreaksRenderer();
                    _Layer.Renderer = _Renderer;
                    _moMap.RedrawMap();
                }
            }
        }
        private void btnChooseColor3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                panelColor3.BackColor = selectedColor;

                if (_Layer != null && comboBoxField3.SelectedItem != null)
                {
                    _Renderer = CreateUniqueValueRenderer();
                    _Layer.Renderer = _Renderer;
                    _moMap.RedrawMap();
                }
            }
        }
        private void panelColor1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panelColor1.BackColor = colorDialog1.Color;
            }
        }

        private void panelColor2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panelColor2.BackColor = colorDialog1.Color;
            }
        }

        private void panelColor3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panelColor3.BackColor = colorDialog1.Color;
            }
        }
        private void LoadFieldValues(ListBox listBox, string fieldName)
        {
            listBox.Items.Clear();
            if (_Layer != null && !string.IsNullOrEmpty(fieldName))
            {
                int fieldIndex = _Layer.AttributeFields.FindField(fieldName);
                if (fieldIndex >= 0)
                {
                    for (int i = 0; i < _Layer.Features.Count; i++)
                    {
                        var fieldValue = _Layer.Features.GetItem(i).Attributes.GetItem(fieldIndex);
                        listBox.Items.Add(fieldValue.ToString());
                    }
                }
            }
        }


        private void panelColor1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelColor2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelColor3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxField3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxField3.SelectedItem != null)
            {
                LoadFieldValues(listBoxFields3, comboBoxField3.SelectedItem.ToString());
            }
        }

        private void comboBoxField2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxField2.SelectedItem != null)
            {
                LoadFieldValues(listBoxFields2, comboBoxField2.SelectedItem.ToString());
            }
        }

        private void textBoxClassBreaks_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBoxFields3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxFields2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSymbolType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxSymbolType.SelectedItem.ToString() == "Line")
            {
                comboBoxLineStyle.Visible = true;
            }
            else
            {
                comboBoxLineStyle.Visible = false;
            }
        }

        private void panelSymbolColor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxLineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxLayer_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonApplySymbol_Click(object sender, EventArgs e)
        {
            if (comboBoxLayer.SelectedItem == null)
                return;

            MyMapObjects.moMapLayer selectedLayer = GetLayerByName(comboBoxLayer.SelectedItem.ToString());
            if (selectedLayer == null)
                return;

            if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                MyMapObjects.moSimpleLineSymbol lineSymbol = new MyMapObjects.moSimpleLineSymbol();
                lineSymbol.Style = comboBoxStyle.SelectedItem.ToString() == "实线" ?
                                   MyMapObjects.moSimpleLineSymbolStyleConstant.Solid :
                                   MyMapObjects.moSimpleLineSymbolStyleConstant.Dash;
                lineSymbol.Size = (float)numericUpDownSize.Value;
                lineSymbol.Color = panelSymbolColor.BackColor;
                selectedLayer.Renderer = new MyMapObjects.moSimpleRenderer { Symbol = lineSymbol };
            }
            else if (selectedLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                MyMapObjects.moSimpleMarkerSymbol pointSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                switch (comboBoxStyle.SelectedItem.ToString())
                {
                    case "空心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.Circle;
                        break;
                    case "实心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidCircle;
                        break;
                    case "空心方形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.Square;
                        break;
                    case "实心方形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidSquare;
                        break;
                    case "空心三角形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.Triangle;
                        break;
                    case "实心三角形":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidTriangle;
                        break;
                    case "有点空心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.CircleCircle;
                        break;
                    case "有点实心圆":
                        pointSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.CircleDot;
                        break;
                }
                pointSymbol.Size = (float)numericUpDownSize.Value;
                pointSymbol.Color = panelSymbolColor.BackColor;
                selectedLayer.Renderer = new MyMapObjects.moSimpleRenderer { Symbol = pointSymbol };
            }

            _moMap.RedrawMap();
        }

        private void comboBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
