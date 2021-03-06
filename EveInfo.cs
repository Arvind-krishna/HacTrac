﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HacTrac
{
    public partial class EveInfo : Form
    {
        string xmlstr;
        public EveInfo(string str)
        {
            xmlstr = str;
            InitializeComponent();
        }

        private void EveInfo_Load(object sender, EventArgs e)
        {
            XDocument xml = XDocument.Parse(xmlstr);
            XNamespace ns = "http://schemas.microsoft.com/win/2004/08/events/event";

            foreach (var node in xml.Descendants(ns + "Data"))
            {
                textBox1.Text += (string)node.Attribute("Name") + ": " + node.Value;
                textBox1.Text += "\r\n";

            }
            if (textBox1.Text == "") { textBox1.Text = xml.ToString(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringReader theReader = new StringReader(xmlstr);
                saveFileDialog1.DefaultExt = "xml";
                saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, xmlstr);
                    MessageBox.Show("Success");
                } 
        }
    }
}
