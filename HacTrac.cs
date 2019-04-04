using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacTrac
{
    public partial class HacTrac : Form
    {
        public HacTrac()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DomBox.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DomBox.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DomBox.Enabled = false || DomBox.Text == "") DomBox.Text = null;
            

             Queryobj a = new Queryobj(UnameBox.Text, PassBox.Text, IPbox.Text, DomBox.Text);
             this.Hide();
             new Dashboard(a).Show();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Dashboard(null).Show();
        }
    }
}
