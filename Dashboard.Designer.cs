namespace HacTrac
{
    partial class Dash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnFetch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnXML = new System.Windows.Forms.Button();
            this.TxtEventID = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.EventID = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RDP = new System.Windows.Forms.RadioButton();
            this.RadioSecurity = new System.Windows.Forms.RadioButton();
            this.RadioSysmon = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Keywords = new System.Windows.Forms.CheckBox();
            this.timebox = new System.Windows.Forms.ComboBox();
            this.LevelList = new System.Windows.Forms.CheckedListBox();
            this.Levelbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnFetch
            // 
            this.BtnFetch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnFetch.Location = new System.Drawing.Point(104, 589);
            this.BtnFetch.Name = "BtnFetch";
            this.BtnFetch.Size = new System.Drawing.Size(143, 27);
            this.BtnFetch.TabIndex = 0;
            this.BtnFetch.Text = "Fetch Log";
            this.BtnFetch.UseVisualStyleBackColor = true;
            this.BtnFetch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1266, 380);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // BtnXML
            // 
            this.BtnXML.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnXML.Enabled = false;
            this.BtnXML.Location = new System.Drawing.Point(507, 416);
            this.BtnXML.Name = "BtnXML";
            this.BtnXML.Size = new System.Drawing.Size(209, 33);
            this.BtnXML.TabIndex = 3;
            this.BtnXML.Text = "View Event Details";
            this.BtnXML.UseVisualStyleBackColor = true;
            this.BtnXML.Click += new System.EventHandler(this.BtnXML_Click);
            // 
            // TxtEventID
            // 
            this.TxtEventID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.TxtEventID.Enabled = false;
            this.TxtEventID.Location = new System.Drawing.Point(617, 477);
            this.TxtEventID.Name = "TxtEventID";
            this.TxtEventID.Size = new System.Drawing.Size(131, 20);
            this.TxtEventID.TabIndex = 4;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnApply.Location = new System.Drawing.Point(558, 587);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(141, 35);
            this.BtnApply.TabIndex = 10;
            this.BtnApply.Text = "Apply Filters";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // EventID
            // 
            this.EventID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EventID.AutoSize = true;
            this.EventID.Location = new System.Drawing.Point(510, 477);
            this.EventID.Name = "EventID";
            this.EventID.Size = new System.Drawing.Size(83, 17);
            this.EventID.TabIndex = 11;
            this.EventID.Text = "By Event ID";
            this.EventID.UseVisualStyleBackColor = true;
            this.EventID.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.RDP);
            this.groupBox1.Controls.Add(this.RadioSecurity);
            this.groupBox1.Controls.Add(this.RadioSysmon);
            this.groupBox1.Location = new System.Drawing.Point(111, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 67);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Log source";
            // 
            // RDP
            // 
            this.RDP.AutoSize = true;
            this.RDP.Location = new System.Drawing.Point(155, 32);
            this.RDP.Name = "RDP";
            this.RDP.Size = new System.Drawing.Size(109, 17);
            this.RDP.TabIndex = 30;
            this.RDP.Text = "Terminal Services";
            this.RDP.UseVisualStyleBackColor = true;
            // 
            // RadioSecurity
            // 
            this.RadioSecurity.AutoSize = true;
            this.RadioSecurity.Checked = true;
            this.RadioSecurity.Location = new System.Drawing.Point(86, 32);
            this.RadioSecurity.Name = "RadioSecurity";
            this.RadioSecurity.Size = new System.Drawing.Size(63, 17);
            this.RadioSecurity.TabIndex = 1;
            this.RadioSecurity.TabStop = true;
            this.RadioSecurity.Text = "Security";
            this.RadioSecurity.UseVisualStyleBackColor = true;
            // 
            // RadioSysmon
            // 
            this.RadioSysmon.AutoSize = true;
            this.RadioSysmon.Location = new System.Drawing.Point(18, 32);
            this.RadioSysmon.Name = "RadioSysmon";
            this.RadioSysmon.Size = new System.Drawing.Size(62, 17);
            this.RadioSysmon.TabIndex = 0;
            this.RadioSysmon.Text = "Sysmon";
            this.RadioSysmon.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // Keywords
            // 
            this.Keywords.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Keywords.AutoSize = true;
            this.Keywords.Location = new System.Drawing.Point(510, 540);
            this.Keywords.Name = "Keywords";
            this.Keywords.Size = new System.Drawing.Size(97, 17);
            this.Keywords.TabIndex = 14;
            this.Keywords.Text = "By Time Period";
            this.Keywords.UseVisualStyleBackColor = true;
            this.Keywords.CheckedChanged += new System.EventHandler(this.Keywords_CheckedChanged);
            // 
            // timebox
            // 
            this.timebox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.timebox.Enabled = false;
            this.timebox.FormattingEnabled = true;
            this.timebox.Items.AddRange(new object[] {
            "Last Hour",
            "Last 12 Hours",
            "Last 24 Hours",
            "Last 7 Days",
            "Last 30 Days"});
            this.timebox.Location = new System.Drawing.Point(617, 538);
            this.timebox.Name = "timebox";
            this.timebox.Size = new System.Drawing.Size(131, 21);
            this.timebox.TabIndex = 15;
            // 
            // LevelList
            // 
            this.LevelList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LevelList.ColumnWidth = 200;
            this.LevelList.Enabled = false;
            this.LevelList.FormattingEnabled = true;
            this.LevelList.Items.AddRange(new object[] {
            "File Create/Drop",
            "RDP Logon",
            "RDP Logoff",
            "RDP Disconnect",
            "RDP Re-connect",
            "File Access",
            "File Copy/Paste",
            "File Modify/Delete"});
            this.LevelList.Location = new System.Drawing.Point(783, 499);
            this.LevelList.MultiColumn = true;
            this.LevelList.Name = "LevelList";
            this.LevelList.Size = new System.Drawing.Size(145, 124);
            this.LevelList.TabIndex = 17;
            // 
            // Levelbox
            // 
            this.Levelbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Levelbox.AutoSize = true;
            this.Levelbox.Location = new System.Drawing.Point(783, 476);
            this.Levelbox.Name = "Levelbox";
            this.Levelbox.Size = new System.Drawing.Size(69, 17);
            this.Levelbox.TabIndex = 18;
            this.Levelbox.Text = "By Event";
            this.Levelbox.UseVisualStyleBackColor = true;
            this.Levelbox.CheckedChanged += new System.EventHandler(this.Levelbox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(994, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 33);
            this.button1.TabIndex = 23;
            this.button1.Text = "Export CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "csv";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Location = new System.Drawing.Point(253, 590);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 26);
            this.button2.TabIndex = 24;
            this.button2.Text = "Clear Log";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1034, 575);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 42);
            this.label5.TabIndex = 25;
            this.label5.Text = "HacTrac ";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(994, 499);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(229, 63);
            this.button3.TabIndex = 26;
            this.button3.Text = "View Alerts";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button4.Location = new System.Drawing.Point(86, 416);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 33);
            this.button4.TabIndex = 27;
            this.button4.Text = "Fetch All Logs";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Log specific operations";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button5.Location = new System.Drawing.Point(741, 416);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(209, 33);
            this.button5.TabIndex = 29;
            this.button5.Text = "View Event XML";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button6.Location = new System.Drawing.Point(253, 416);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 33);
            this.button6.TabIndex = 30;
            this.button6.Text = "Clear All Logs";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Dash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 650);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Levelbox);
            this.Controls.Add(this.LevelList);
            this.Controls.Add(this.timebox);
            this.Controls.Add(this.Keywords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EventID);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TxtEventID);
            this.Controls.Add(this.BtnXML);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnFetch);
            this.Name = "Dash";
            this.Text = "Sysmon";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dash_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFetch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnXML;
        private System.Windows.Forms.TextBox TxtEventID;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.CheckBox EventID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioSecurity;
        private System.Windows.Forms.RadioButton RadioSysmon;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox Keywords;
        private System.Windows.Forms.ComboBox timebox;
        private System.Windows.Forms.CheckedListBox LevelList;
        private System.Windows.Forms.CheckBox Levelbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton RDP;
        private System.Windows.Forms.Button button6;
    }
}

