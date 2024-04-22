using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RFID_Attendance_System
{
    public partial class MainForm : Form
    {
        public static MainForm instance;
        public string eventname;

        public MainForm()
        {
            InitializeComponent();
            timer.Start();
            eventname = eventname_txtbox.Text;
            instance = this;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Methods.openForm(new FormAttendance(), panelMain);

        }

        private void btn_attendance_Click(object sender, EventArgs e)
        {
            Methods.openForm(new FormAttendance(), panelMain);
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            Methods.openForm(new FormRegister(), panelMain);
        }


        private void btn_print_Click(object sender, EventArgs e)
        {
            Methods.openForm(new DataStatistics(), panelMain);
        }


        private void btn_prnt_Click(object sender, EventArgs e)
        {
            Methods.openForm(new FormPrinter(), panelMain);
        }

        private void eventname_txtbox_Leave(object sender, EventArgs e)
        {
            if (eventname_txtbox.Text == "")
            {
                eventname_txtbox.ForeColor = Color.LightGray;
                eventname_txtbox.Text = "ENTER EVENT NAME HERE";
            }
        }

        private void eventname_txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                eventname = eventname_txtbox.Text;
                btn_attendance.Focus();
            }
        }

        private void eventname_txtbox_Enter(object sender, EventArgs e)
        {
            if (eventname_txtbox.Text == "EVENT NAME HERE")
            {
                eventname_txtbox.Text = "";
                eventname_txtbox.ForeColor = Color.Black;

            }
        }
    }
    public static class Methods
    {
        public static void openForm(Form frm, Panel panelName)
        {
            panelName.Controls.Clear();
            frm.TopLevel = false;
            frm.TopMost = true;
            frm.Dock = DockStyle.Fill;
            panelName.Controls.Add(frm);
            frm.Show();
        }
    }
}
