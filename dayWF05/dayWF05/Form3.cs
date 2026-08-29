using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dayWF05
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            // 初始数据
            comboBox1.Items.AddRange(["升序", "降序"]);
            comboBox2.Items.AddRange(["升序", "降序"]);

            // 绑定事件
            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged; ;
            comboBox2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (sender as ComboBox);
            // 判断是哪个下拉框
            if (cb.Name == "comboBox1")
            {
                // 模拟排序
                if (cb.SelectedItem.ToString() == "升序")
                {
                    MessageBox.Show("按照价格升序排序");
                }
                else
                {
                    MessageBox.Show("按照价格降序排序");
                }
            }
            else
            {
                if (cb.SelectedItem.ToString() == "升序")
                {
                    MessageBox.Show("按照上架时间升序排序");
                }
                else
                {
                    MessageBox.Show("按照上架时间降序排序");
                }
            }
        }
    }
}
