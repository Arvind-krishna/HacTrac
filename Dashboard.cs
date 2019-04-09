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
    public partial class Dash : Form
    {
        Queryobj a = new Queryobj();
        String query;
        Boolean filter;
        

        public Dash(Queryobj o)
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
                MessageBox.Show(subquery);


                query += subquery;
                MessageBox.Show(query);
                ++count;
            }

            if (Levelbox.Checked)

            {
                string subquery="";
                if (count > 0) { query += " and "; --count; }

               
                if (LevelList.CheckedIndices.Count > 0)
                {
                    int countr=0;
                    subquery += "(";
                    foreach (int a in LevelList.CheckedIndices)
                    {
                        switch (a)
                        {
                            case 0:
                                if (countr > 0) { subquery += " or "; --countr; }

                                subquery += "Level=1";
                                ++countr;

                                break;

                            case 1:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "Level=2";
                                ++countr;
                                break;

                            case 2:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "Level=3";
                                ++countr;
                                break;

                            case 3:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "Level=4 or Level=0";
                                ++countr;
                                break;

                            case 4:
                                if (countr > 0) { subquery += " or "; --countr; }
                                subquery += "Level=5";
                                ++countr;
                                break;


                            default:
                                break;


                        }


                    }
                    subquery += ")";
                    query += subquery;
                    ++count;
                    MessageBox.Show(query);                }
               

            }



            query += "]]";
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            CheckFilter();

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
    }
}
