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
using System.Windows.Shapes;

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
            Console.WriteLine(formAttendanceCR.intervalCheck("834cdb93"));
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
        //Getting the path of database

        public static string dbname = @"RFID DB.db";
        public static string dbpath = @"URI=file:" + Application.StartupPath + "\\" + dbname; // Database in debug folder
        private FormAttendance formAttendance;

        // Constructor that takes an instance of FormRegister as a parameter
        public formAttendanceCR(FormAttendance formAttendance)
        {
            this.formAttendance = formAttendance;
        }

        public override void ChangeStatus()
        {
            if (ConnectCard())
            {
                DateTime time1 = DateTime.Now;
                String dateTime = time1.ToString("hh:mm tt");
                String dateToday = time1.ToString("yyyy-MM-dd");
                //Storing Rfid Code
                string StudentRfid = GetCardUId(CardIo);

                //Creating query to retrieve data from data base
                string findid = $"SELECT * FROM IDInfo WHERE rfid = '{StudentRfid}'";

                //Initializing connection to database
                using (SQLiteConnection conn = new SQLiteConnection(dbpath))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(findid, conn))
                    {
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
                                //ChangeStatus(formAttendance, formAttendance.lbl_timeInText, dateTime);
                                
                                if (!timedToday(id))//Has no time in record today
                                {
                                    string insertQuery = "INSERT INTO Attendance (StudentID, StudentName, Course, Date, TimeIn) VALUES" +
                                        $"('{id}', '{name}', '{course}', '{dateToday}', '{dateTime}');";
                                    Console.WriteLine(insertQuery);
                                }
                                else if (timedToday(id) //Has a time in record
                                    && !timedIn(id) //Has no time out record
                                    )
                                {
                                    string updateQuery = $"UPDATE Attendance SET TimeOut = '{dateTime}' WHERE StudentID = '{id}' AND Date = '{dateToday}';";
                                    Console.WriteLine(updateQuery);
                                }
                            }
                            else
                            {
                                ChangeStatus(formAttendance, formAttendance.lbl_info, "No Record Found");
                                formAttendance.lbl_info.BackColor = Color.Red;
                            }
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
        }
        bool timedToday(string id)
        {
            DateTime date = DateTime.Now;
            string dateToday = date.ToString("yyyy-MM-dd");
            string query = $"SELECT * FROM Attendance WHERE StudentID = '{id}' AND Date = '{dateToday}'";

            //Initializing connection to database
            using (SQLiteConnection conn = new SQLiteConnection(dbpath))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("Time in found today.");
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("No time in found today.");
                            conn.Close();
                            return false;
                        }
                    }
                }
            }
        }

        bool timedIn(string id)
        {
            DateTime date = DateTime.Now;
            string dateToday = date.ToString("yyyy-MM-dd");
            string query = $"SELECT TimeOut FROM Attendance WHERE StudentID = '{id}' AND Date = '{dateToday}'";
            Console.WriteLine(query);

            //Initializing connection to database
            using (SQLiteConnection conn = new SQLiteConnection(dbpath))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !(reader.IsDBNull(0) || reader.GetString(0) == ""))
                        {
                            Console.WriteLine("Time out found.");
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("No time out found.");
                            conn.Close();
                            return false;
                        }
                    }
                }
            }
        }

        public bool intervalCheck(string id)
        {
            DateTime date = DateTime.Now;
            string dateToday = date.ToString("yyyy-MM-dd");
            string query = $"SELECT TimeIn FROM Attendance WHERE rfid = '{id}' AND Date = '{dateToday}'";
            Console.WriteLine(query);
            //Initializing connection to database
            using (SQLiteConnection conn = new SQLiteConnection(dbpath))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string timeIn = reader.GetString(0);
                            if (isAllowed(timeIn))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No time in found.");
                            conn.Close();
                            return false;
                        }
                    }
                }
            }
        }
        public bool isAllowed(string timeIn)
        {
            double intervalMin = 5;
            DateTime time = DateTime.Now;
            string timeOut = time.ToString("hh:mm tt");
            // Converting string to datetime
            DateTime dtTimeIn = DateTime.ParseExact(timeIn, "hh:mm tt", null);
            DateTime dtTimeOut = DateTime.ParseExact(timeOut, "hh:mm tt", null);

            // Calculating the difference between time1 and time2
            TimeSpan difference = dtTimeIn - dtTimeOut;

            // Creating a TimeSpan representing 5 minutes
            TimeSpan intervalMinTS = TimeSpan.FromMinutes(intervalMin);

            // Checking if the difference is greater than 5 minutes
            if (difference >= intervalMinTS)
            {
                Console.WriteLine("Allowed to time out");
                return true;
            }
            else
            {
                Console.WriteLine("Not yet allowed to time out");
                return false;
            }
        }
        void toSQL(string query)
        {
            //Initializing connection to database
            using (SQLiteConnection connToSQL = new SQLiteConnection(dbpath))
            {
                connToSQL.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, connToSQL))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
