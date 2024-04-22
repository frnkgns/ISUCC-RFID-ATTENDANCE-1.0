using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using DGVPrinterHelper;

namespace RFID_Attendance_System
{
    public partial class FormPrinter : Form
    {
        //Getting database path
        public static string dbname = "RFID DB.db";
        public string dbpath = Path.Combine(dbname);
        static DateTime dt = DateTime.Now;
        public static string events_name;

        public FormPrinter()
        {
            InitializeComponent();

            //Since ayaw mag load ng image sa properties dito ko nalang ilalagay
            pictureBox1.Image = Properties.Resources.cct;
            pictureBox2.Image = Properties.Resources.isulogo;

        }

        private FormAttendance formAttendanceInstance;
        public FormPrinter(FormAttendance formAttendanceInstance)
        {
            this.formAttendanceInstance = formAttendanceInstance;

        }

        //after ni user mag search tatawagin yung functions nato
        private void yrsctn_cmbbx_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] courselist = new string[yrsctn_cmbbx.Items.Count];
            yrsctn_cmbbx.Items.CopyTo(courselist, 0);

            if (courselist.Contains(yrsctn_cmbbx.Text))
            {
                ReadData();
            }
            else
            {
                MessageBox.Show("Please select on the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReadData()
        {

            //Get events name from the MainForm
            events_name = MainForm.instance.eventname;
            string yrsctn = yrsctn_cmbbx.SelectedItem.ToString();
            string selected_yrsctn = yrsctn + "\n" + dt.ToString("(MM/dd/yyyy)");
            string event_id;

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;"))
            {
                conn.Open();
                events_name = MainForm.instance.eventname;
                event_id = events_name + dt.ToString("(MM/dd/yyyy)");
                Console.WriteLine(event_id);
                string getdata = "SELECT name, timein, timeout, late FROM attendance WHERE EventID = @event_id AND Course = @yrsctn";

                using (SQLiteCommand cmd = new SQLiteCommand(getdata, conn))
                {
                    cmd.Parameters.AddWithValue("@event_id", event_id);
                    cmd.Parameters.AddWithValue("@yrsctn", yrsctn);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        DataGrid.Columns.Clear();           //Need natin iclear muna yung default columns na nilagay natin sa properties
                        DataGrid.DataSource = dataTable;

                        //itong DGVPrinter galing sa github since d natin alam pano gumawa ng sariling dll tyaka kakapusin sa oras
                        DGVPrinter printer = new DGVPrinter();
                        printer.Title = events_name;
                        printer.SubTitle = selected_yrsctn;
                        printer.PageNumbers = true;
                        printer.PageNumberInHeader = false;
                        printer.PorportionalColumns = true;
                        printer.FooterSpacing = 15;
                        printer.PrintPreviewDataGridView(DataGrid);
                    }
                }
            }
        }

        private void yrsctn_cmbbx_KeyDown(object sender, KeyEventArgs e)
        {
            string[] courselist = new string[yrsctn_cmbbx.Items.Count];
            yrsctn_cmbbx.Items.CopyTo(courselist, 0);

            if (e.KeyCode == Keys.Enter)
            {
                if (courselist.Contains(yrsctn_cmbbx.Text))
                {
                    ReadData();

                } else
                {
                    MessageBox.Show("Please select on the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            } 
        }
    }
}
