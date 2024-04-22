using SnappyWinscard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using Attendance_with_RFID;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Data.SQLite;
using System.Web.UI.WebControls;

namespace RFID_Attendance_System
{
    public partial class FormRegister : Form
    {
        public string uid = "";
        private formRegisterCR function;

        //Sound effects
        static string logged_in_sound = @"livechat-129007.wav";
        static string error_sound = @"error-call-to-attention-129258.wav";
        static string error_path = Path.Combine(Application.StartupPath, error_sound);
        static string logged_in_path = Path.Combine(Application.StartupPath, logged_in_sound);
        static System.Media.SoundPlayer login = new System.Media.SoundPlayer(logged_in_path);
        static System.Media.SoundPlayer error = new System.Media.SoundPlayer(error_path);

        public FormRegister()
        {
            InitializeComponent();
            function = new formRegisterCR(this);
            function.Initialize();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Getting the path of database
                string dbname = @"RFID DB.db";
                string dbpath = Path.Combine(Application.StartupPath, dbname);

                //Initializing connection to database
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;"))
                {

                    //Check if ID EXist
                    string getid = $"select * from idinfo where rfid = '{uid}'";
                    conn.Open();

                    //Creating query to insert data to data base
                    string insert = $"insert into idinfo values ('{uid}', '{tb_id.Text}', '{tb_name.Text}', '{tb_course.Text}');";

                    using (SQLiteCommand cmd = new SQLiteCommand(getid, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                GoBackToAttendanceForm("RecordExist");

                            }
                            else
                            {
                                //Executing Command
                                using (SQLiteCommand insertcmd = new SQLiteCommand(insert, conn))
                                {

                                    insertcmd.ExecuteNonQuery();
                                }

                                conn.Close();

                                GoBackToAttendanceForm("NoRecord");

                            }
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error on saving the data.");
            }
        }
        private void ResizeAll()
        {
            functions.ResizeGunaTextBoxWidth(panelMain, tb_uid, 222);
            functions.ResizeGunaTextBoxWidth(panelMain, tb_name, 222);
            functions.ResizeGunaTextBoxWidth(panelMain, tb_id, 222);
            functions.ResizeGunaTextBoxWidth(panelMain, tb_course, 222);
            functions.ResizePanelWidth(panelMain, panelReg, 40);
        }

        private void FormRegister_Resize(object sender, EventArgs e)
        {
            ResizeAll();
        }


        public void GoBackToAttendanceForm(string cmd)
        {
            MessageBoxButtons okbtn = MessageBoxButtons.OK;
            DialogResult recordsaved;


            if (cmd == "NoRecord")
            {
                login.Play();
                recordsaved = MessageBox.Show("Student Record Saved.", "", okbtn);


            }
            else
            {
                error.Play();
                recordsaved = MessageBox.Show("Student Record Exist.", "", okbtn);
            }

            if (recordsaved == DialogResult.OK)
            {
                Methods.openForm(new FormAttendance(), panelMain);
            }
        }
    }

    class formRegisterCR : cardReader
    {
        private FormRegister formRegister;

        // Constructor that takes an instance of FormRegister as a parameter
        public formRegisterCR(FormRegister formRegister)
        {
            this.formRegister = formRegister;
        }

        public override void ChangeStatus()
        {
            if (ConnectCard())
            {
                Console.WriteLine("Card connected");
                formRegister.uid = GetCardUId(CardIo);
                ChangeStatus(formRegister, formRegister.tb_uid, GetCardUId(CardIo)); // Use the instance of FormRegister passed in the constructor
            }
            else
            {
                Console.WriteLine("Card not connected");
            }
        }
    }
}
