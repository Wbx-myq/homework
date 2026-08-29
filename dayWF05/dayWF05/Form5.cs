using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dayWF05
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            button1.MouseMove += Button1_MouseMove;
            button1.MouseDown += Button1_MouseDown;
            button1.MouseUp += Button1_MouseUp;
        }

        private bool flag = false;

        private Point p;

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!flag) return;
            
            Point M_s = button1.PointToScreen(e.Location);

            M_s.Offset(-p.X, -p.Y);

            Point M_c = this.PointToClient(M_s);


            //边界判断，不超出Form客户区
            int left = M_c.X;
            int top = M_c.Y;

            if (left < 0) left = 0;
            if (top < 0) top = 0;
            if (left + button1.Width > this.ClientSize.Width)
                left = this.ClientSize.Width - button1.Width;
            if (top + button1.Height > this.ClientSize.Height)
                top = this.ClientSize.Height - button1.Height;

            button1.Location = new Point(left, top);

            //button1.Location = M_c;

        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            p = e.Location;
        }

        private void Button1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }
    }
}
