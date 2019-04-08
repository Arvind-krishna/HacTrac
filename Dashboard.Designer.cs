namespace HacTrac
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnFetch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnXML = new System.Windows.Forms.Button();
            this.TxtEventID = new System.Windows.Forms.TextBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.EventID = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioSecurity = new System.Windows.Forms.RadioButton();
            this.RadioSysmon = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnFetch
            // 
            this.BtnFetch.Location = new System.Drawing.Point(62, 566);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1443, 448);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // BtnXML
            // 
            this.BtnXML.Enabled = false;
            this.BtnXML.Location = new System.Drawing.Point(296, 712);
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
            this.TxtEventID.Location = new System.Drawing.Point(701, 642);
            this.TxtEventID.Name = "TxtEventID";
            this.TxtEventID.Size = new System.Drawing.Size(89, 20);
            this.TxtEventID.TabIndex = 4;
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(640, 687);
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
            this.EventID.Location = new System.Drawing.Point(612, 645);
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
            this.groupBox1.Location = new System.Drawing.Point(44, 486);
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
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 799);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EventID);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TxtEventID);
            this.Controls.Add(this.BtnXML);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnFetch);
            this.Name = "Dashboard";
            this.Text = "Sysmon";
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
    }
}

