﻿using System;
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
            ds =  l.QueryRemoteComputer(query,a);
            dataGridView1.DataSource = ds; // dataset
            dataGridView1.DataMember = "Events";
            
        }
    }
}
