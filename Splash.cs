using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacTrac
{
    public partial class Splash : Form
    {
        public Splash()
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
            if (DomBox.Enabled == false) DomBox.Text = null;

            if ((UnameBox.Text == "" || PassBox.Text == "" || IPbox.Text == "")) { MessageBox.Show("Please enter the required information"); }

            else
            {
                Queryobj a = new Queryobj(UnameBox.Text, PassBox.Text, IPbox.Text, DomBox.Text);
                this.Hide();
                Ping myPing = new Ping();
                try
                {
                    PingReply reply = myPing.Send(IPbox.Text, 1000);
                    if (reply.Status.ToString().Equals("Success"))

                    {
                        this.Hide();
                        try { new Dash(a).Show(); }
                        catch (Exception bee) { MessageBox.Show(bee.Message); }

                    }

                    else MessageBox.Show("Remote Machine doesnt exist, or is not reachable. Please check, and try again");
                }

                catch (Exception)
                {
                    MessageBox.Show("Invalid credentials. Please try again");
                    new Splash().Show();

                }

            }
        }

       
    }
}
