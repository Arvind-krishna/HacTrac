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
using System.Xml;
using System.Xml.Linq;

namespace HacTrac
{
    public partial class Dash : Form
    {
        Queryobj a = new Queryobj();
        String query;
        Boolean filter;
        public static bool fullquery;
        public static DataTable dt;


        public Dash(Queryobj o)
        {
            InitializeComponent();
            a = o;
            DataColumnCollection columns = Alerts.alerts.Columns;
            columns.Add("EventID");
            columns.Add("Level");
            columns.Add("Time").Unique=true;
            columns.Add("Task");
            
            columns.Add("Operation");
            columns.Add("XML");
            columns.Add("Threat-Type");

            


            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            fullquery = false;
            progressBar1.Visible = true;
            backgroundWorker1.RunWorkerAsync();

        }



        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            BtnXML.Enabled = true;
        }

        private void CheckFilter()
        {
            if (EventID.Checked) filter = true;
            if (Keywords.Checked) filter = true;
            if (Levelbox.Checked) filter = true;
        }


        private void BtnXML_Click(object sender, EventArgs e)
        {
            try
            {



                string str = dataGridView1.SelectedRows[0].Cells["XML"].Value.ToString();
                new EveInfo(str).Show();
                


               

            }
            catch (Exception) { }
        }



        





        private void GenerateQuery()
        {
            int count = 0;
            query = "*[System[";
            if (EventID.Checked)
            {
                if (TxtEventID.Text != "")

                {
                    string subquery = "(EventID=" + TxtEventID.Text + ")";
                    query += subquery;
                    count++;
                }


            }



            if (Keywords.Checked)
            {
                if (count > 0) { query += " and "; --count; }
                string t;
                switch (timebox.SelectedIndex)
                {
                    case 0:
                        t = "3600000"; break;

                    case 1:
                        t = "43200000"; break;

                    case 2:
                        t = "86400000"; break;

                    case 3:
                        t = "604800000"; break;

                    case 4:
                        t = "2592000000"; break;

                    default:
                        t = "3600000"; break;


                }
                string subquery = String.Format("TimeCreated[timediff(@SystemTime) <= {0}]", t);
                


                query += subquery;
                
                ++count;
            }

            if (Levelbox.Checked)

            {
                string subquery = "";
                if (count > 0) { query += " and "; --count; }


                if (LevelList.CheckedIndices.Count > 0)
                {
                    int countr = 0;
                    subquery += "(";
                    foreach (int a in LevelList.CheckedIndices)
                    {
                        switch (a)
                        {
                            case 0:
                                if (countr > 0) { subquery += " or "; --countr; }

                                subquery += "EventID=11";
                                ++countr;

                                break;

                            

                            case 1:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=21";
                                ++countr;
                                break;

                            case 2:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=23";
                                ++countr;
                                break;

                            case 3:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=24";
                                ++countr;
                                break;


                            case 4:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=25";
                                ++countr;
                                break;


                            case 5:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=4656";
                                ++countr;
                                break;

                            case 6:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=4690";
                                ++countr;
                                break;

                            case 7:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=4663";
                                ++countr;
                                break;

                           


                            default:
                                break;


                        }


                    }
                    subquery += ")";
                    query += subquery;
                    ++count;
                   


                }




            }
            query += "]]";
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            CheckFilter();

            if (filter == true)

            {
                GenerateQuery();

                Log l = new Log();

                DataSet ds = new DataSet();
                if (RadioSysmon.Checked) a.logname = "Microsoft-Windows-Sysmon/Operational";
                else if (RadioSecurity.Checked) a.logname = "Security";
                else a.logname = "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational";

                ds = l.QueryRemoteComputer(query, a);
                try
                {

                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Events";
                    
                    dataGridView1.Columns["XML"].Visible = false;


                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (EventID.Checked)
            {
                TxtEventID.Enabled = true;

            }
            else
            {
                TxtEventID.Enabled = false;

            }
        }

        private void Keywords_CheckedChanged(object sender, EventArgs e)
        {
            if (Keywords.Checked)
            {
                timebox.Enabled = true;


            }
            else
            {
                timebox.Enabled = false;



            }

        }

        private void Levelbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Levelbox.Checked) { LevelList.Enabled = true; }
            else LevelList.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            
            var sb = new StringBuilder();

          
            try
            {
                
                var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }

            }
            catch (Exception) { MessageBox.Show("Nothing to export"); }
            //Exporting to CSV.
            saveFileDialog2.DefaultExt = "csv";
            saveFileDialog2.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            { File.WriteAllText(saveFileDialog2.FileName, sb.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string logname = "Security";
            
            if (RadioSysmon.Checked) { logname = "Microsoft-Windows-Sysmon/Operational"; }
            else if (RDP.Checked) { logname = "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational"; }

            Log l = new Log();
            if (MessageBox.Show("Are you sure you want to clear the " + logname + " log?", "Confirm Log Deletion",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
               
                    l.ClearLog(logname, o: a);
                    MessageBox.Show("Log ClearSuccessful");
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Alerts().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            fullquery = true;
            backgroundWorker1.RunWorkerAsync();
            



        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { MessageBox.Show(dataGridView1.SelectedRows[0].Cells["XML"].Value.ToString()); }
            catch (Exception) { }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] lognames = new string[] { "Security", "Microsoft-Windows-Sysmon/Operational", "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational" };
            Log l = new Log();
            if (MessageBox.Show("Are you sure you want to clear all logs?", "Confirm Log Deletion",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (string logname in lognames)
                {
                    l.ClearLog(logname, o: a);
                }
                MessageBox.Show("Logs successfully cleared");
                dataGridView1.DataSource = new DataTable();
                dataGridView1.Refresh();
            }
           
        }

        private void Dash_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Log l = new Log();
            DataSet ds = new DataSet();
            if (fullquery==true) { ds = l.fullquery(a); }



            else if (RadioSecurity.Checked) { a.logname = "Security"; ds = l.QueryRemoteComputer("*[System[(EventID = 4663) or (EventID = 4660) or (EventID=4690)]]", a); }
            else if (RadioSysmon.Checked) { a.logname = "Microsoft-Windows-Sysmon/Operational"; ds = l.QueryRemoteComputer("*[System[(EventID=11)]]", a); }
            else { a.logname = "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational"; ds = l.QueryRemoteComputer("*[System[(EventID=21) or (EventID=24) or (EventID=23) or (EventID=25)]]", a); }

            try
            {
                dt = ds.Tables["Events"];
                
                Alerts.alerts.Clear();
                l.FilterLog(dt);

                

            }
            catch (Exception exx) { MessageBox.Show(exx.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["XML"].Visible = false;
        }
    }
}
