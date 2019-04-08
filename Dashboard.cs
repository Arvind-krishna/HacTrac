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
        String query;
        Boolean filter;
        

        public Dashboard(Queryobj o)
        {
            InitializeComponent();
            a = o;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log l = new log();
            query = "*";
            DataSet ds = new DataSet();
            mode m;
            if (RadioSysmon.Checked) { a.logname = "Microsoft-Windows-Sysmon/Operational"; m = mode.sysmon; }
            else { a.logname = "Security"; m = mode.security; }

                ds =  l.QueryRemoteComputer(query,a,m);
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
                saveFileDialog1.Title = "Download Event XML";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                saveFileDialog1.ShowDialog();
                
                File.WriteAllText(saveFileDialog1.FileName, xml);
            }
            catch (Exception)
            { MessageBox.Show("Error"); }
           
        }

        private void GenerateQuery()
        {
            int count = 0;
            query = "*[System[";
            if (EventID.Checked)
                if (TxtEventID.Text == "") MessageBox.Show("Please enter an Event ID");
            {
                string subquery = "(EventID=" + TxtEventID.Text + ")";
                query += subquery;
                count = 1;
            }

             query += "]]";

        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (filter==true) GenerateQuery(); else query = "*";
            
            log l = new log();
            mode m;
            DataSet ds = new DataSet();
            if (RadioSysmon.Checked) { a.logname = "Microsoft-Windows-Sysmon/Operational"; m = mode.sysmon; }
            else { a.logname = "Security"; m = mode.security; }
           
                ds = l.QueryRemoteComputer(query, a, m);
            try
            {
                dataGridView1.DataSource = ds; // dataset
                dataGridView1.DataMember = "Events";
            }
            catch (Exception) { MessageBox.Show("No Events to show"); }
                

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (EventID.Checked)
            {
                TxtEventID.Enabled = true;
                filter = true;
            }
            else
            {
                TxtEventID.Enabled = false;
                filter = false;
            }
        }
    }
}
