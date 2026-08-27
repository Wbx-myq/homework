using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace day03
{
    public partial class Form4 : Form
    {
        private int speed = 5;
        public Form4()
        {
            InitializeComponent();
            // 键盘控制方向移动
            this.KeyDown += Move_KeyDown;   
        }

        private void Move_KeyDown(object sender, KeyEventArgs e)
        {
            Point bl = panel1.Location;

            switch (e.KeyCode)
            {
                case Keys.W:
                    bl.Y -= speed;
                    break;
                case Keys.S:
                    bl.Y += speed;
                    break;
                case Keys.A:
                    bl.X -= speed;
                    break;
                case Keys.D:
                    bl.X += speed;
                    break;
                default:
                    break;
            }
            panel1.Location = bl;
        }
    }
}
