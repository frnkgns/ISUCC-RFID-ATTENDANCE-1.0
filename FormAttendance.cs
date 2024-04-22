using Attendance_with_RFID;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
        //Get the Events name from the MainForm
        string events_name = MainForm.instance.eventname;

        //Getting the path of database
        public static string dbname = @"RFID DB.db";
        public static string dbpath = Path.Combine(Application.StartupPath, dbname);

        //Sound effects
        static string logged_in_sound = @"livechat-129007.wav";
        static string error_sound = @"error-call-to-attention-129258.wav";
        static string error_path = Path.Combine(Application.StartupPath, error_sound);
        static string logged_in_path = Path.Combine(Application.StartupPath, logged_in_sound);
        static System.Media.SoundPlayer login = new System.Media.SoundPlayer(logged_in_path);
        static System.Media.SoundPlayer error = new System.Media.SoundPlayer(error_path);

        SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;");

        // Constructor that takes an instance of FormRegister as a parameter
        private FormAttendance formAttendance;
        public formAttendanceCR(FormAttendance formAttendance)
        {
            this.formAttendance = formAttendance;
        }

        public static DateTime dt = DateTime.Now;
        public static string dateTime = dt.ToString("hh:mm tt");
        public static string ampm = dateTime.Substring(dateTime.Length - 2);

        public override void ChangeStatus()
        {
            conn.Open();


            if (ConnectCard())
            {
                //d ko alam paano gumana tong errors message hahaha bast wag niyo nalang to tanggalin
                events_name = MainForm.instance.eventname;
                if (events_name == "" || events_name == null || events_name == "EVENT NAME HERE")
                {
                    MessageBox.Show("Please enter events name to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    events_name = MainForm.instance.eventname;

                }
                else
                {
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

                                AddAttendaceToDatabase();

                            }
                            else
                            {
                                error.Play();
                                ChangeStatus(formAttendance, formAttendance.lbl_info, "No Record Found");
                                formAttendance.lbl_info.BackColor = Color.Red;
                                formAttendance.lbl_info.ForeColor = Color.White;
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
                formAttendance.lbl_info.ForeColor = Color.Black;
            }

            conn.Close();
        }

        static string dateOnly = dt.ToString("MM/dd/yyyy");
        public void AddAttendaceToDatabase()
        {
            string eventid = events_name + "(" + dateOnly + ")";
            string stdntid = formAttendance.lbl_stdidText.Text;
            string name = formAttendance.lbl_nameText.Text;
            string course = formAttendance.lbl_courseText.Text;
            string timein = formAttendance.lbl_timeInText.Text;
            string AddTimeIn = $"insert into attendance (EventID, StudentID, Name, Course, TimeIn, Late) values (@Evntid , @Stdntid , @Name, @Course, @TimeIn, @Late)";
            string AddTimeOut = $"update attendance set TimeOut = '{timein}' where Name = '{name}'";
            string Check = $"select StudentID from attendance where StudentID = '{stdntid}'";

            //This will ensure kung may na reread ba ng tama yung card, minsan kasi hindi nareread yung details merong missing input
            if (stdntid.Length > 0 && name.Length > 0 && course.Length > 0 && timein.Length > 0)
            {
                //so here we will calculate if the student is late or not
                // we will extract two index from this 08:00 format we will get the 08
                string strhours = timein.Substring(0, 2);
                int inthours = int.Parse(strhours);         //then convert it into int so we can use it in condition
                string late = "";

                //First we will check if he is already logged in, if yes then we will not record again his attempt
                using (SQLiteCommand cmd = new SQLiteCommand(Check, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        //checking if the attendance contains something, if may na read syang lines ibig sabihin merong laman na yung table
                        if (reader.Read())
                        {
                            //Test lang if tama ba yung match name sa table 
                            Console.WriteLine(reader.GetString(0) + " = " + stdntid);

                            //then kukunin natin yung per row sa column dapat match yung name sa row column name then ibig sabihin already recorded.
                            //this is good to verify kung meron naba syang attendance
                            if (reader.GetString(0) == stdntid)
                            {
                                login.Play();

                                if (inthours <= 12 && ampm == "AM")
                                {
                                    login.Play();
                                    using (SQLiteCommand Timeout = new SQLiteCommand(AddTimeOut, conn))
                                    {
                                        Timeout.Parameters.AddWithValue("@timeout", timein);
                                        Timeout.ExecuteNonQuery();
                                    }

                                    formAttendance.Invoke((MethodInvoker)delegate
                                    {
                                        formAttendance.lbl_info.Text = "Your participation is greatly appreciated. Thank you!";
                                        formAttendance.lbl_info.ForeColor = Color.Black;
                                        formAttendance.lbl_info.BackColor = Color.Chartreuse;

                                    });

                                }
                                else
                                {
                                    formAttendance.Invoke((MethodInvoker)delegate
                                    {
                                        formAttendance.lbl_info.Text = "Your attendance has already been logged.";
                                        formAttendance.lbl_info.ForeColor = Color.Black;
                                    });
                                }
                            }

                            //Opkors laging iclose ang binuksan
                            reader.Close();


                        }
                        else
                        {
                            login.Play();
                            if (ampm == "PM")
                            {
                                late = "Yes";

                            }
                            else
                            {
                                late = "No";
                            }

                            //If his not logged in, then we will record his attempt
                            using (SQLiteCommand Timein = new SQLiteCommand(AddTimeIn, conn))
                            {
                                Timein.Parameters.AddWithValue("@Evntid", eventid);
                                Timein.Parameters.AddWithValue("@Stdntid", stdntid);
                                Timein.Parameters.AddWithValue("@Name", name);
                                Timein.Parameters.AddWithValue("@Course", course);
                                Timein.Parameters.AddWithValue("@TimeIn", timein);
                                Timein.Parameters.AddWithValue("@Late", late);

                                Timein.ExecuteNonQuery();
                            }

                            formAttendance.Invoke((MethodInvoker)delegate
                            {
                                formAttendance.lbl_info.Text = "Your attendance has been logged. Thank you!";
                                formAttendance.lbl_info.BackColor = Color.Chartreuse;
                                formAttendance.lbl_info.ForeColor = Color.Black;
                            });
                        }
                    }
                }
            }
            else
            {
                error.Play();
                formAttendance.Invoke((MethodInvoker)delegate {
                    formAttendance.lbl_info.Text = "Please tap your ID again in 3 seconds";
                    formAttendance.lbl_info.BackColor = Color.Red;
                    formAttendance.lbl_info.ForeColor = Color.White;
                });

            }

            conn.Close();
        }
    }
}
