namespace RFID_Attendance_System
{
    partial class MainForm
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.btn_print = new FontAwesome.Sharp.IconButton();
            this.btn_reg = new FontAwesome.Sharp.IconButton();
            this.btn_attendance = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelSide.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.panelSide.Controls.Add(this.btn_print);
            this.panelSide.Controls.Add(this.btn_reg);
            this.panelSide.Controls.Add(this.btn_attendance);
            this.panelSide.Controls.Add(this.panel1);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(284, 653);
            this.panelSide.TabIndex = 0;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.btn_print.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btn_print.IconColor = System.Drawing.Color.White;
            this.btn_print.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_print.IconSize = 35;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.Location = new System.Drawing.Point(0, 191);
            this.btn_print.Margin = new System.Windows.Forms.Padding(0);
            this.btn_print.Name = "btn_print";
            this.btn_print.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btn_print.Size = new System.Drawing.Size(284, 60);
            this.btn_print.TabIndex = 3;
            this.btn_print.Text = "  Print";
            this.btn_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_reg
            // 
            this.btn_reg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.btn_reg.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_reg.FlatAppearance.BorderSize = 0;
            this.btn_reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reg.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reg.ForeColor = System.Drawing.Color.White;
            this.btn_reg.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.btn_reg.IconColor = System.Drawing.Color.White;
            this.btn_reg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_reg.IconSize = 35;
            this.btn_reg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_reg.Location = new System.Drawing.Point(0, 131);
            this.btn_reg.Margin = new System.Windows.Forms.Padding(0);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btn_reg.Size = new System.Drawing.Size(284, 60);
            this.btn_reg.TabIndex = 2;
            this.btn_reg.Text = "  Register";
            this.btn_reg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reg.UseVisualStyleBackColor = false;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // btn_attendance
            // 
            this.btn_attendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(55)))), ((int)(((byte)(61)))));
            this.btn_attendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_attendance.FlatAppearance.BorderSize = 0;
            this.btn_attendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_attendance.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_attendance.ForeColor = System.Drawing.Color.White;
            this.btn_attendance.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.btn_attendance.IconColor = System.Drawing.Color.White;
            this.btn_attendance.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_attendance.IconSize = 35;
            this.btn_attendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_attendance.Location = new System.Drawing.Point(0, 71);
            this.btn_attendance.Margin = new System.Windows.Forms.Padding(0);
            this.btn_attendance.Name = "btn_attendance";
            this.btn_attendance.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btn_attendance.Size = new System.Drawing.Size(284, 60);
            this.btn_attendance.TabIndex = 1;
            this.btn_attendance.Text = "  Attendance";
            this.btn_attendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_attendance.UseVisualStyleBackColor = false;
            this.btn_attendance.Click += new System.EventHandler(this.btn_attendance_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 71);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(48)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "CCSICT Attendance";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(284, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(803, 71);
            this.panelTop.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(284, 71);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(803, 582);
            this.panelMain.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 653);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSide);
            this.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSide.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_attendance;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btn_print;
        private FontAwesome.Sharp.IconButton btn_reg;
        private System.Windows.Forms.Timer timer;
    }
}

