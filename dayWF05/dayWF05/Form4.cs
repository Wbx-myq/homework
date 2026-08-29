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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            checkBox1.CheckedChanged += All_CheckedChanged;

            foreach(CheckBox check in panel1.Controls) check.CheckedChanged += Check_CheckedChanged;
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState != CheckState.Indeterminate)
            {
                foreach (CheckBox check in panel1.Controls) check.Checked = checkBox1.Checked ? true : false;
            }
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            List<CheckBox> checkBoxes = panel1.Controls.OfType<CheckBox>().ToList();
            bool isAll = checkBoxes.All(checkBox => checkBox.Checked);
            bool isAny = checkBoxes.Any(checkBox => checkBox.Checked);

            if (isAll)
            {
                checkBox1.CheckState = CheckState.Checked;
            }
            else
            {
                if (isAny)
                {
                    checkBox1.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    checkBox1.CheckState = CheckState.Unchecked;
                }
            }
        }
    }
}
