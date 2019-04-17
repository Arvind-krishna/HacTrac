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


        public Dash(Queryobj o)
        {
            InitializeComponent();
            a = o;
            DataColumnCollection columns = Alerts.alerts.Columns;
            columns.Add("EventID");
            columns.Add("Level");
            columns.Add("Time");

            columns.Add("Task");
            columns.Add("User");
            columns.Add("Operation");
            columns.Add("XML");
            columns.Add("Threat-Type");


            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log l = new log();
            DataSet ds = new DataSet();
            if (sender == null && e == null) { ds=l.fullquery(a); }
            
            
            mode m;
            if (RadioSecurity.Checked) { a.logname = "Security"; m = mode.security; ds = l.QueryRemoteComputer("*[System[(EventID = 4656) or(EventID = 4663) or(EventID = 4690) or (EventID = 4634) or (EventID = 4624)]]", a, m); }
            else { a.logname = "Microsoft-Windows-Sysmon/Operational"; m = mode.sysmon; ds = l.QueryRemoteComputer("*[System[(EventID=11) or (EventID=1) or (EventID=3)]]", a, m); }
            
            
            try
            {
                DataTable dt = ds.Tables["Events"];
                dataGridView1.DataSource = dt;
                l.FilterLog(dataGridView1);
                dataGridView1.Columns["XML"].Visible = false;

            }
            catch (Exception exx) { MessageBox.Show(exx.Message); }

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
                                subquery += "EventID=1";
                                ++countr;
                                break;

                            case 2:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=3";
                                ++countr;
                                break;

                            case 3:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=";
                                ++countr;
                                break;

                            case 4:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=10";
                                ++countr;
                                break;

                            case 5:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=12";
                                ++countr;
                                break;

                            case 6:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=13";
                                ++countr;
                                break;

                            case 7:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=4624";
                                ++countr;
                                break;

                            case 8:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=4634";
                                ++countr;
                                break;

                            case 9:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "EventID=4625";
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

            if (filter == true) GenerateQuery(); else query = "*";

            log l = new log();
            mode m;
            DataSet ds = new DataSet();
            if (RadioSysmon.Checked) { a.logname = "Microsoft-Windows-Sysmon/Operational"; m = mode.sysmon; }
            else { a.logname = "Security"; m = mode.security; }
            log.viewcount = (int)numericUpDown1.Value;
            ds = l.QueryRemoteComputer(query, a, m);
            try
            {
                
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Events";
                l.FilterLog(dataGridView1);
                dataGridView1.Columns["XML"].Visible = false;

            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }


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

            string csv = string.Empty;

            //Add the Header row for CSV file.
            try
            {
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    csv += column.HeaderText + ',';
                }

                //Add new line.
                csv += "\r\n";

                //Adding the Rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //Add the Data rows.
                        csv += cell.Value.ToString().Replace(",", ";") + ',';
                    }

                    //Add new line.
                    csv += "\r\n";
                }
            }
            catch (Exception) { MessageBox.Show("Nothing to export"); }
            //Exporting to CSV.
            saveFileDialog2.DefaultExt = "csv";
            saveFileDialog2.Filter = "CSV files (*.csv)|*.csv";
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            { File.WriteAllText(saveFileDialog2.FileName, csv); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string logname = "Security";
            if (RadioSysmon.Checked) { logname = "Microsoft-Windows-Sysmon/Operational"; }

            log l = new log();
            if (MessageBox.Show("Are you sure you want to clear the " + logname + " log?", "Confirm Log Deletion",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
               
                    l.ClearLog(logname, a, false);
                    MessageBox.Show("Log ClearSuccessful");
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Alerts().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            log l = new log();
            DataSet ds = new DataSet();
            ds = l.fullquery(a); 


            try
            {
                DataTable dt = ds.Tables["Events"];
                dataGridView1.DataSource = dt;
                l.FilterLog(dataGridView1);
                dataGridView1.Columns["XML"].Visible = false;

            }
            catch (Exception exx) { MessageBox.Show(exx.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.SelectedRows[0].Cells["XML"].Value.ToString());
            MessageBox.Show("C:\\Users\\akrish\\");
        }
    }
}
