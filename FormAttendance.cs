using SnappyWinscard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;
using System.Xml.Linq;
using System.Data.Entity.Core.Mapping;
using Attendance_with_RFID;

namespace RFID_Attendance_System
{
    public partial class FormAttendance : Form
    {
        private formAttendanceCR formAttendanceCR;
        public FormAttendance()
        {
            InitializeComponent();
            formAttendanceCR = new formAttendanceCR(this);
            formAttendanceCR.Initialize();
            timer.Start();
        }
        private void FormAttendance_Resize(object sender, EventArgs e)
        {
            ResizeAll();
        }
        private void ResizeAll()
        {
            functions.ResizePanelWidth(panelMain, panelTime, 40);
            functions.ResizePanelWidth(panelMain, panelInfo, 40);
            functions.ResizePanelWidth(panelMain, panelStudent, 40);
            functions.ResizePanelHeight(panelMain, panelStudent, 300);
            functions.ResizeLabelWidth(panelStudent, lbl_courseText, 340);
            functions.ResizeLabelWidth(panelStudent, lbl_nameText, 340);
            functions.ResizeLabelWidth(panelStudent, lbl_stdidText, 340);
            functions.ResizeLabelWidth(panelStudent, lbl_timeInText, 340);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lbl_date.Text = dt.ToString("MMMM dd, yyyy");
            lbl_time.Text = dt.ToString("hh:mm:ss tt");
        }
    }
    class formAttendanceCR : cardReader 
    {
        private FormAttendance formAttendance;

        // Constructor that takes an instance of FormRegister as a parameter
        public formAttendanceCR(FormAttendance formAttendance)
        {
            this.formAttendance = formAttendance;
        }

        public override void ChangeStatus()
        {
            //Getting the path of database

            string dbname = @"RFID DB.db";
            string dbpath = Path.Combine(Application.StartupPath, dbname);

            //Initializing connection to database
            SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;");
            conn.Open();


            if (ConnectCard())
            {
                DateTime time1 = DateTime.Now;
                String dateTime = time1.ToString("hh:mm tt");

                //Storing Rfid Code
                string StudentRfid = GetCardUId(CardIo);

                //Creating query to retrieve data from data base
                string findid = $"select * from idinfo where rfid = '{StudentRfid}'";

                //Executing Command
                using (SQLiteCommand cmd = new SQLiteCommand(findid, conn))
                {
                    cmd.Parameters.AddWithValue("@id", StudentRfid);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string id = reader.GetString(1);
                            string name = reader.GetString(2);
                            string course = reader.GetString(3);

                            //Pringting just for debugging if naread nya ba talaga
                            Console.WriteLine($"Student ID: {id} Name: {name} Course and Field: {course}");
                            //Changing text of every labels
                            ChangeStatus(formAttendance, formAttendance.lbl_stdidText, id);
                            ChangeStatus(formAttendance, formAttendance.lbl_nameText, name);
                            ChangeStatus(formAttendance, formAttendance.lbl_courseText, course);
                            ChangeStatus(formAttendance, formAttendance.lbl_timeInText, dateTime);

                        }
                        else
                        {
                            ChangeStatus(formAttendance, formAttendance.lbl_info, "No Record Found");
                            formAttendance.lbl_info.BackColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                ChangeStatus(formAttendance, formAttendance.lbl_stdidText, "");
                ChangeStatus(formAttendance, formAttendance.lbl_nameText, "");
                ChangeStatus(formAttendance, formAttendance.lbl_courseText, "");
                ChangeStatus(formAttendance, formAttendance.lbl_timeInText, "");
                ChangeStatus(formAttendance, formAttendance.lbl_info, "Tap the card into the reader.");
                formAttendance.lbl_info.BackColor = Color.PaleGreen;
            }

            conn.Close();
        }
    }
}
