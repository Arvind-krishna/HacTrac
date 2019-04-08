using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacTrac
{
    public partial class Dashboard : Form
    {
        Queryobj a = new Queryobj(); 
        

        public Dashboard(Queryobj o)
        {
            InitializeComponent();
            a = o;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log l = new log();
            string query = "*";
            DataSet ds = new DataSet();
            a.logname = "Microsoft-Windows-Sysmon/Operational";
            ds =  l.QueryRemoteComputer(query,a,mode.sysmon);
            dataGridView1.DataSource = ds; // dataset
            dataGridView1.DataMember = "Events";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log l = new log();
            string query = "*";
            DataSet ds = new DataSet();
            a.logname = "Security";
            ds = l.QueryRemoteComputer(query, a, mode.security);
            dataGridView1.DataSource = ds; // dataset
            dataGridView1.DataMember = "Events";

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            BtnXML.Enabled = true;
        }

       

        private void BtnXML_Click(object sender, EventArgs e)
        {
            try
            {
                string xml = dataGridView1.SelectedRows[0].Cells["XML"].Value.ToString();

                MessageBox.Show(xml);
                File.WriteAllText("t.xml", xml);
            }
            catch (Exception e)
            { MessageBox.Show("Please select an event to download XML"); }
           
        }
    }
}
