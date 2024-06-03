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
    public partial class ProjectionForm : Form
    {
        public moProjectionCS SelectedProjection { get; private set; }
        public ProjectionForm()
        {
            InitializeComponent();
            LoadProjections();
        }
        private void LoadProjections()
        {
            comboBoxProjections.Items.Add(new moProjectionCS("WGS84", "WGS84", "WGS84", "WGS84", 6378137.0, 298.257223563,
            moProjectionTypeConstant.None, 0, 0, 0, 0, 1, 0, 0, moLinearUnitConstant.Meter));
            comboBoxProjections.Items.Add(new moProjectionCS("UTM Zone 33N", "WGS84", "WGS84", "WGS84", 6378137.0, 298.257223563,
                moProjectionTypeConstant.UTM, 0, 15, 500000, 0, 0.9996, 0, 0, moLinearUnitConstant.Meter));
            comboBoxProjections.Items.Add(new moProjectionCS("Mercator", "WGS84", "WGS84", "WGS84", 6378137.0, 298.257223563,
                moProjectionTypeConstant.Mercator, 0, 0, 0, 0, 1, 0, 0, moLinearUnitConstant.Meter));
            comboBoxProjections.Items.Add(new moProjectionCS("Gauss Kruger", "WGS84", "WGS84", "WGS84", 6378137.0, 298.257223563,
                moProjectionTypeConstant.Gauss_Kruger, 0, 0, 500000, 0, 1, 0, 0, moLinearUnitConstant.Meter));
            comboBoxProjections.Items.Add(new moProjectionCS("Lambert Conformal Conic", "WGS84", "WGS84", "WGS84", 6378137.0, 298.257223563,
                moProjectionTypeConstant.Lambert_Conformal_Conic_2SP, 0, 0, 0, 0, 1, 30, 60, moLinearUnitConstant.Meter));
            comboBoxProjections.Items.Add(new moProjectionCS("Albers Equal Area", "WGS84", "WGS84", "WGS84", 6378137.0, 298.257223563,
                moProjectionTypeConstant.Albers_Equal_Area, 0, 0, 0, 0, 1, 29.5, 45.5, moLinearUnitConstant.Meter));

            comboBoxProjections.SelectedIndex = 0;
        }

        private void comboBoxProjections_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取当前选中的投影坐标系
            moProjectionCS selectedProjection = (moProjectionCS)comboBoxProjections.SelectedItem;
            

            // 更新界面显示或其他处理逻辑
            // 例如，可以显示当前选中投影的详细信息
            lblProjectionDetails.Text = $"投影坐标系名称: {selectedProjection.ProjCSName}\n" +
                                        $"地理坐标系名称: {selectedProjection.GeoCSName}\n" +
                                        $"大地基准面名称: {selectedProjection.DatumName}\n" +
                                        $"椭球体名称: {selectedProjection.SpheroidName}\n" +
                                        $"长半轴: {selectedProjection.SemiMajor}\n" +
                                        $"短半轴: {selectedProjection.SemiMinor}\n" +
                                        $"中央经线: {selectedProjection.CentralMeridian}\n" +
                                        $"原点纬度: {selectedProjection.OriginLatitude}\n" +
                                        $"第一标准纬线: {selectedProjection.StandardParallelOne}\n" +
                                        $"第二标准纬线: {selectedProjection.StandardParallelTwo}\n" +
                                        $"比例因子: {selectedProjection.ScaleFactor}\n" +
                                        $"东伪偏移: {selectedProjection.FalseEasting}\n" +
                                        $"北伪偏移: {selectedProjection.FalseNorthing}\n" +
                                        $"投影后的长度单位: {selectedProjection.LinearUnit}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedProjection = (moProjectionCS)comboBoxProjections.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
