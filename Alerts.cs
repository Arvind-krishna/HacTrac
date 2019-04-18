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
    public partial class Alerts : Form
    {
        public static DataTable alerts = new DataTable();
        public Alerts()
        { 
            InitializeComponent();
    
            


        }

        private void Alerts_Load(object sender, EventArgs e)
        {
            alerts = alerts.DefaultView.ToTable(true);
            dataGridView1.DataSource = alerts;
            dataGridView1.Columns["XML"].Visible = false;

            dataGridView1.Sort(dataGridView1.Columns["Time"], ListSortDirection.Ascending);
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                int EvID = Int32.Parse(drow.Cells["EventID"].Value.ToString());

                switch (EvID)
                {
                    case 11:
                        drow.DefaultCellStyle.BackColor = Color.OrangeRed;
                        drow.Cells["Threat-Type"].Value = "Payload Drop Detected";
                        break;

                    case 21:
                        drow.DefaultCellStyle.BackColor = Color.Gray;
                        drow.Cells["Threat-Type"].Value = "RDP Login";
                        break;

                    case 23:
                        drow.DefaultCellStyle.BackColor = Color.Gray;
                        drow.Cells["Threat-Type"].Value = "RDP Logoff";
                        break;

                    case 24:
                        drow.DefaultCellStyle.BackColor = Color.Gray;
                        drow.Cells["Threat-Type"].Value = "RDP Disconnect";
                        break;

                    case 25:
                        drow.DefaultCellStyle.BackColor = Color.Gray;
                        drow.Cells["Threat-Type"].Value = "RDP Session Re-connect";
                        break;

                    case 4663:
                        drow.DefaultCellStyle.BackColor = Color.Orange;
                        if (drow.Cells["XML"].Value.ToString().Contains("notepad.exe"))
                        {
                            if (drow.Cells["XML"].Value.ToString().Contains("0x6</Data>")) drow.Cells["Threat-Type"].Value = "Deception Document Modified";
                            else drow.Cells["Threat-Type"].Value = "Deception Document Opened"; }
                        else if (drow.Cells["XML"].Value.ToString().Contains("<Data Name='AccessMask'>0x10000</Data>"))
                        { drow.Cells["Threat-Type"].Value = "Deception Document Deleted"; }
                        else drow.Cells["Threat-Type"].Value = "Deception Document Accessed";
                        break;

                    case 4656:
                        drow.DefaultCellStyle.BackColor = Color.Orange;
                        drow.Cells["Threat-Type"].Value = "Deception Document Accessed";
                        break;

                    case 4690:
                        drow.DefaultCellStyle.BackColor = Color.Orange;
                        drow.Cells["Threat-Type"].Value = "Deception Document Copied/Pasted";
                        break;

                    default: break;
                  

                }
            }
            
        }
            
        

        private void BtnXML_Click(object sender, EventArgs e)
        {
            try
            {



                string str = dataGridView1.SelectedRows[0].Cells["XML"].Value.ToString();
                new EveInfo(str).Show();





            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            BtnXML.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alerts.Clear();
            dataGridView1.Refresh();
        }
    }
}
