namespace RFID_Attendance_System
{
    partial class FormAttendance
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelStudent = new System.Windows.Forms.Panel();
            this.lbl_timeInText = new System.Windows.Forms.Label();
            this.lbl_courseText = new System.Windows.Forms.Label();
            this.lbl_nameText = new System.Windows.Forms.Label();
            this.lbl_stdidText = new System.Windows.Forms.Label();
            this.lbl_timeIn = new System.Windows.Forms.Label();
            this.lbl_course = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_stdid = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lbl_info = new System.Windows.Forms.Label();
            this.panelTime = new System.Windows.Forms.Panel();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelStudent.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.panelStudent);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Controls.Add(this.panelTime);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(669, 550);
            this.panelMain.TabIndex = 3;
            // 
            // panelStudent
            // 
            this.panelStudent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelStudent.Controls.Add(this.lbl_timeInText);
            this.panelStudent.Controls.Add(this.lbl_courseText);
            this.panelStudent.Controls.Add(this.lbl_nameText);
            this.panelStudent.Controls.Add(this.lbl_stdidText);
            this.panelStudent.Controls.Add(this.lbl_timeIn);
            this.panelStudent.Controls.Add(this.lbl_course);
            this.panelStudent.Controls.Add(this.lbl_name);
            this.panelStudent.Controls.Add(this.lbl_stdid);
            this.panelStudent.Location = new System.Drawing.Point(17, 222);
            this.panelStudent.Margin = new System.Windows.Forms.Padding(2);
            this.panelStudent.Name = "panelStudent";
            this.panelStudent.Size = new System.Drawing.Size(636, 308);
            this.panelStudent.TabIndex = 3;
            // 
            // lbl_timeInText
            // 
            this.lbl_timeInText.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_timeInText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeInText.Location = new System.Drawing.Point(262, 150);
            this.lbl_timeInText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_timeInText.Name = "lbl_timeInText";
            this.lbl_timeInText.Size = new System.Drawing.Size(352, 25);
            this.lbl_timeInText.TabIndex = 3;
            this.lbl_timeInText.Text = "09:00 AM";
            // 
            // lbl_courseText
            // 
            this.lbl_courseText.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_courseText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_courseText.Location = new System.Drawing.Point(262, 108);
            this.lbl_courseText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_courseText.Name = "lbl_courseText";
            this.lbl_courseText.Size = new System.Drawing.Size(352, 25);
            this.lbl_courseText.TabIndex = 3;
            this.lbl_courseText.Text = "BSCS - 3A DM";
            // 
            // lbl_nameText
            // 
            this.lbl_nameText.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_nameText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nameText.Location = new System.Drawing.Point(262, 67);
            this.lbl_nameText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nameText.Name = "lbl_nameText";
            this.lbl_nameText.Size = new System.Drawing.Size(352, 25);
            this.lbl_nameText.TabIndex = 3;
            this.lbl_nameText.Text = "Mark Joseph Orino";
            // 
            // lbl_stdidText
            // 
            this.lbl_stdidText.BackColor = System.Drawing.Color.Gainsboro;
            this.lbl_stdidText.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stdidText.Location = new System.Drawing.Point(262, 25);
            this.lbl_stdidText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stdidText.Name = "lbl_stdidText";
            this.lbl_stdidText.Size = new System.Drawing.Size(352, 25);
            this.lbl_stdidText.TabIndex = 3;
            this.lbl_stdidText.Text = "21-11929";
            // 
            // lbl_timeIn
            // 
            this.lbl_timeIn.AutoSize = true;
            this.lbl_timeIn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeIn.Location = new System.Drawing.Point(148, 150);
            this.lbl_timeIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_timeIn.Name = "lbl_timeIn";
            this.lbl_timeIn.Size = new System.Drawing.Size(87, 23);
            this.lbl_timeIn.TabIndex = 2;
            this.lbl_timeIn.Text = "Time In: ";
            // 
            // lbl_course
            // 
            this.lbl_course.AutoSize = true;
            this.lbl_course.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_course.Location = new System.Drawing.Point(24, 108);
            this.lbl_course.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_course.Name = "lbl_course";
            this.lbl_course.Size = new System.Drawing.Size(212, 23);
            this.lbl_course.TabIndex = 2;
            this.lbl_course.Text = "Course and Section: ";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(77, 67);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(163, 23);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "Student Name: ";
            // 
            // lbl_stdid
            // 
            this.lbl_stdid.AutoSize = true;
            this.lbl_stdid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stdid.Location = new System.Drawing.Point(118, 25);
            this.lbl_stdid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_stdid.Name = "lbl_stdid";
            this.lbl_stdid.Size = new System.Drawing.Size(122, 23);
            this.lbl_stdid.TabIndex = 0;
            this.lbl_stdid.Text = "Student ID: ";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.PaleGreen;
            this.panelInfo.Controls.Add(this.lbl_info);
            this.panelInfo.Location = new System.Drawing.Point(17, 162);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(2);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(636, 42);
            this.panelInfo.TabIndex = 2;
            // 
            // lbl_info
            // 
            this.lbl_info.BackColor = System.Drawing.Color.PaleGreen;
            this.lbl_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_info.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.Location = new System.Drawing.Point(0, 0);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(636, 42);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "Tap the card into the reader.";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTime
            // 
            this.panelTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTime.Controls.Add(this.lbl_date);
            this.panelTime.Controls.Add(this.lbl_time);
            this.panelTime.Location = new System.Drawing.Point(17, 19);
            this.panelTime.Margin = new System.Windows.Forms.Padding(2);
            this.panelTime.Name = "panelTime";
            this.panelTime.Size = new System.Drawing.Size(636, 128);
            this.panelTime.TabIndex = 1;
            // 
            // lbl_date
            // 
            this.lbl_date.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_date.BackColor = System.Drawing.Color.Transparent;
            this.lbl_date.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.Location = new System.Drawing.Point(0, 67);
            this.lbl_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(636, 38);
            this.lbl_date.TabIndex = 1;
            this.lbl_date.Text = "January 01, 2024";
            this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_time
            // 
            this.lbl_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(0, 8);
            this.lbl_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(636, 66);
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "00:00:00 AM";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(669, 550);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAttendance";
            this.Text = "AttendanceForm";
            this.Resize += new System.EventHandler(this.FormAttendance_Resize);
            this.panelMain.ResumeLayout(false);
            this.panelStudent.ResumeLayout(false);
            this.panelStudent.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelStudent;
        private System.Windows.Forms.Label lbl_timeIn;
        private System.Windows.Forms.Label lbl_course;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_stdid;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelTime;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_time;
        public System.Windows.Forms.Label lbl_info;
        public System.Windows.Forms.Label lbl_courseText;
        public System.Windows.Forms.Label lbl_nameText;
        public System.Windows.Forms.Label lbl_stdidText;
        public System.Windows.Forms.Label lbl_timeInText;
    }
}