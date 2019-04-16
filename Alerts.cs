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
            DataTable distinctTable = alerts.DefaultView.ToTable(true);
            dataGridView1.DataSource = distinctTable;
            foreach (DataGridViewRow drow in dataGridView1.Rows)
            {
                if (drow.Cells["EventID"].Value.ToString() == "11")
                { drow.DefaultCellStyle.BackColor = Color.OrangeRed;
                    drow.Cells["Threat-Type"].Value = "Payload Drop Detected";
                }
            }
            dataGridView1.Columns["XML"].Visible = false;
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
