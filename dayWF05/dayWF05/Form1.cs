using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace dayWF05
{


    public partial class Form1 : Form
    {
        private List<BcColor> ColorList = new();

        public Form1()
        {
            InitializeComponent();
            InitColor();
        }

        private void InitColor()
        {
            // 初始化数据
            ColorList.AddRange([
                new BcColor("红色",Color.Red),
                new BcColor("橙色",Color.Orange),
                new BcColor("黄色",Color.Yellow),
                new BcColor("绿色",Color.Green),
                new BcColor("青色",Color.Cyan),
                new BcColor("蓝色",Color.Blue),
                new BcColor("紫色",Color.Purple),

             ]);
            comboBox1.Items.AddRange(ColorList.ConvertAll(item => item.Name).ToArray());

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (sender as ComboBox).SelectedItem.ToString();

            Color c = ColorList.Find(item => item.Name == name)._Color;

            this.BackColor = c;

        }

       
    }
    public class BcColor
    {
        public string Name;
        public Color _Color;
        public BcColor(string Name, Color _Color)
        {
            this.Name = Name;
            this._Color = _Color;
        }
    }




}
