namespace RFID_Attendance_System
{
    partial class FormRegister
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelReg = new System.Windows.Forms.Panel();
            this.lbl_time = new System.Windows.Forms.Label();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.tb_uid = new Guna.UI2.WinForms.Guna2TextBox();
            this.tb_name = new Guna.UI2.WinForms.Guna2TextBox();
            this.tb_id = new Guna.UI2.WinForms.Guna2TextBox();
            this.tb_course = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelReg);
            this.panelMain.Controls.Add(this.btnAdd);
            this.panelMain.Controls.Add(this.tb_uid);
            this.panelMain.Controls.Add(this.tb_name);
            this.panelMain.Controls.Add(this.tb_id);
            this.panelMain.Controls.Add(this.tb_course);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(803, 660);
            this.panelMain.TabIndex = 0;
            // 
            // panelReg
            // 
            this.panelReg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelReg.Controls.Add(this.lbl_time);
            this.panelReg.Location = new System.Drawing.Point(20, 25);
            this.panelReg.Name = "panelReg";
            this.panelReg.Size = new System.Drawing.Size(763, 105);
            this.panelReg.TabIndex = 3;
            // 
            // lbl_time
            // 
            this.lbl_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(0, 10);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(763, 80);
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "ID Registration";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAdd.IconColor = System.Drawing.Color.Black;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.Location = new System.Drawing.Point(573, 401);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(192, 40);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tb_uid
            // 
            this.tb_uid.BorderRadius = 10;
            this.tb_uid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_uid.DefaultText = "";
            this.tb_uid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_uid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_uid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_uid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_uid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_uid.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_uid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_uid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_uid.Location = new System.Drawing.Point(184, 156);
            this.tb_uid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_uid.Name = "tb_uid";
            this.tb_uid.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tb_uid.PasswordChar = '\0';
            this.tb_uid.PlaceholderText = "";
            this.tb_uid.SelectedText = "";
            this.tb_uid.Size = new System.Drawing.Size(580, 41);
            this.tb_uid.TabIndex = 1;
            this.tb_uid.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // tb_name
            // 
            this.tb_name.BorderRadius = 10;
            this.tb_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_name.DefaultText = "";
            this.tb_name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_name.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_name.Location = new System.Drawing.Point(184, 216);
            this.tb_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_name.Name = "tb_name";
            this.tb_name.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tb_name.PasswordChar = '\0';
            this.tb_name.PlaceholderText = "";
            this.tb_name.SelectedText = "";
            this.tb_name.Size = new System.Drawing.Size(581, 41);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // tb_id
            // 
            this.tb_id.BorderRadius = 10;
            this.tb_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_id.DefaultText = "";
            this.tb_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_id.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_id.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_id.Location = new System.Drawing.Point(184, 276);
            this.tb_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_id.Name = "tb_id";
            this.tb_id.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tb_id.PasswordChar = '\0';
            this.tb_id.PlaceholderText = "";
            this.tb_id.SelectedText = "";
            this.tb_id.Size = new System.Drawing.Size(581, 41);
            this.tb_id.TabIndex = 1;
            this.tb_id.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // tb_course
            // 
            this.tb_course.BorderRadius = 10;
            this.tb_course.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_course.DefaultText = "";
            this.tb_course.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_course.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_course.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_course.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_course.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_course.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_course.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_course.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_course.Location = new System.Drawing.Point(185, 336);
            this.tb_course.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_course.Name = "tb_course";
            this.tb_course.PasswordChar = '\0';
            this.tb_course.PlaceholderText = "";
            this.tb_course.SelectedText = "";
            this.tb_course.Size = new System.Drawing.Size(581, 41);
            this.tb_course.TabIndex = 1;
            this.tb_course.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Course: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Student ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student Name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "UID: ";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 660);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            this.Resize += new System.EventHandler(this.FormRegister_Resize);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelReg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelReg;
        private System.Windows.Forms.Label lbl_time;
        public Guna.UI2.WinForms.Guna2TextBox tb_course;
        public Guna.UI2.WinForms.Guna2TextBox tb_uid;
        public Guna.UI2.WinForms.Guna2TextBox tb_name;
        public Guna.UI2.WinForms.Guna2TextBox tb_id;
    }
}