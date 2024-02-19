using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFID_Attendance_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            timer.Start();
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
            Methods.openForm(new FormPrint(), panelMain);
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
