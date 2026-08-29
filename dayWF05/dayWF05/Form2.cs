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
    public partial class Form2 : Form
    {
        private List<provinceCity> provinceCities = new();
        public Form2()
        {
            InitializeComponent();
            InitProvince();
        }

        private void InitProvince()
        {
            provinceCities.AddRange([
               new provinceCity(1,"广东省",0),
               new provinceCity(2,"广州市",1),
               new provinceCity(3,"深圳市",1),
               new provinceCity(4,"佛山市",1),
               new provinceCity(5,"广西省",0),
               new provinceCity(6,"南宁市",5),
               new provinceCity(7,"柳州市",5),
               new provinceCity(8,"桂林市",5),
               new provinceCity(9,"湖南省",0),
               new provinceCity(10,"长沙市",9),
               new provinceCity(11,"永州市",9),
               new provinceCity(12,"衡阳市",9),
             ]);
            var pc = provinceCities.FindAll(item => item.Parent_id == 0);
            var p = pc.Select(item => item.Name);

            comboBox1.Items.AddRange(p.ToArray());
            comboBox1.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取选中的省份名称
            string selProvince = comboBox1.Text;
            // 找到该省份对象，拿到省份ID
            var province = provinceCities.FirstOrDefault(x => x.Name == selProvince && x.Parent_id == 0);
            if (province == null) return;

            // 根据省份ID筛选下属城市 Parent_id = 省份ID
            var cities = provinceCities.FindAll(x => x.Parent_id == province.Id);

            // 绑定到城市下拉框 comboBox2
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(cities.Select(x => x.Name).ToArray());
        }
    }

    public class provinceCity
    {
        public int Id;
        public string Name;
        public int Parent_id;

        public provinceCity(int Id, string Name, int Parent_id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Parent_id = Parent_id;
        }

    }
}
