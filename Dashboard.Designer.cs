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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnFetch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnXML = new System.Windows.Forms.Button();
            this.TxtEventID = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.EventID = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioSecurity = new System.Windows.Forms.RadioButton();
            this.RadioSysmon = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Keywords = new System.Windows.Forms.CheckBox();
            this.timebox = new System.Windows.Forms.ComboBox();
            this.LevelList = new System.Windows.Forms.CheckedListBox();
            this.Levelbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnFetch
            // 
            this.BtnFetch.Location = new System.Drawing.Point(83, 578);
            this.BtnFetch.Name = "BtnFetch";
            this.BtnFetch.Size = new System.Drawing.Size(118, 42);
            this.BtnFetch.TabIndex = 0;
            this.BtnFetch.Text = "Fetch Logs";
            this.BtnFetch.UseVisualStyleBackColor = true;
            this.BtnFetch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1127, 457);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // BtnXML
            // 
            this.BtnXML.Enabled = false;
            this.BtnXML.Location = new System.Drawing.Point(71, 657);
            this.BtnXML.Name = "BtnXML";
            this.BtnXML.Size = new System.Drawing.Size(141, 33);
            this.BtnXML.TabIndex = 3;
            this.BtnXML.Text = "Download XML";
            this.BtnXML.UseVisualStyleBackColor = true;
            this.BtnXML.Click += new System.EventHandler(this.BtnXML_Click);
            // 
            // TxtEventID
            // 
            this.TxtEventID.Enabled = false;
            this.TxtEventID.Location = new System.Drawing.Point(456, 529);
            this.TxtEventID.Name = "TxtEventID";
            this.TxtEventID.Size = new System.Drawing.Size(131, 20);
            this.TxtEventID.TabIndex = 4;
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(390, 657);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(141, 33);
            this.BtnApply.TabIndex = 10;
            this.BtnApply.Text = "Apply Filters";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // EventID
            // 
            this.EventID.AutoSize = true;
            this.EventID.Location = new System.Drawing.Point(349, 529);
            this.EventID.Name = "EventID";
            this.EventID.Size = new System.Drawing.Size(83, 17);
            this.EventID.TabIndex = 11;
            this.EventID.Text = "By Event ID";
            this.EventID.UseVisualStyleBackColor = true;
            this.EventID.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioSecurity);
            this.groupBox1.Controls.Add(this.RadioSysmon);
            this.groupBox1.Location = new System.Drawing.Point(63, 498);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 67);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Log source";
            // 
            // RadioSecurity
            // 
            this.RadioSecurity.AutoSize = true;
            this.RadioSecurity.Location = new System.Drawing.Point(86, 31);
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
            this.RadioSysmon.Location = new System.Drawing.Point(18, 31);
            this.RadioSysmon.Name = "RadioSysmon";
            this.RadioSysmon.Size = new System.Drawing.Size(62, 17);
            this.RadioSysmon.TabIndex = 0;
            this.RadioSysmon.TabStop = true;
            this.RadioSysmon.Text = "Sysmon";
            this.RadioSysmon.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // Keywords
            // 
            this.Keywords.AutoSize = true;
            this.Keywords.Location = new System.Drawing.Point(349, 592);
            this.Keywords.Name = "Keywords";
            this.Keywords.Size = new System.Drawing.Size(97, 17);
            this.Keywords.TabIndex = 14;
            this.Keywords.Text = "By Time Period";
            this.Keywords.UseVisualStyleBackColor = true;
            this.Keywords.CheckedChanged += new System.EventHandler(this.Keywords_CheckedChanged);
            // 
            // timebox
            // 
            this.timebox.Enabled = false;
            this.timebox.FormattingEnabled = true;
            this.timebox.Items.AddRange(new object[] {
            "Last Hour",
            "Last 12 Hours",
            "Last 24 Hours",
            "Last 7 Days",
            "Last 30 Days"});
            this.timebox.Location = new System.Drawing.Point(456, 590);
            this.timebox.Name = "timebox";
            this.timebox.Size = new System.Drawing.Size(131, 21);
            this.timebox.TabIndex = 15;
            // 
            // LevelList
            // 
            this.LevelList.ColumnWidth = 200;
            this.LevelList.Enabled = false;
            this.LevelList.FormattingEnabled = true;
            this.LevelList.Items.AddRange(new object[] {
            "File Create/Drop",
            "Process Create",
            "Network Connection",
            "Sysmon Status Change",
            "Process Access",
            "Registry (Creation and Deletion)",
            "Registry (Modification)",
            "Successful Logon",
            "Successful Logoff",
            "Failed Logon"});
            this.LevelList.Location = new System.Drawing.Point(622, 558);
            this.LevelList.MultiColumn = true;
            this.LevelList.Name = "LevelList";
            this.LevelList.Size = new System.Drawing.Size(417, 79);
            this.LevelList.TabIndex = 17;
            // 
            // Levelbox
            // 
            this.Levelbox.AutoSize = true;
            this.Levelbox.Location = new System.Drawing.Point(622, 528);
            this.Levelbox.Name = "Levelbox";
            this.Levelbox.Size = new System.Drawing.Size(69, 17);
            this.Levelbox.TabIndex = 18;
            this.Levelbox.Text = "By Event";
            this.Levelbox.UseVisualStyleBackColor = true;
            this.Levelbox.CheckedChanged += new System.EventHandler(this.Levelbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 667);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Fetch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(734, 667);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "records";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(659, 665);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown1.TabIndex = 22;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(810, 657);
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
            // Dash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 727);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

