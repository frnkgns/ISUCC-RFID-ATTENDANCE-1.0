using Guna.UI2.WinForms;
using SnappyWinscard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Attendance_with_RFID;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Data.SQLite;

namespace RFID_Attendance_System
{
    public partial class FormRegister : Form
    {
        public string uid = "";
        private formRegisterCR function; 
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
                SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;");
                conn.Open();

                //Creating query to insert data to data base
                string insert = $"INSERT INTO IDInfo VALUES (\"{uid}\", \"{tb_id.Text}\", \"{tb_name.Text}\", \"{tb_course.Text}\");";

                //Check if ID EXist
                string getid = $"select * from idinfo where rfid = '{uid}'";
                using (SQLiteCommand cmd = new SQLiteCommand(getid, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            GoBackToAttendanceForm("RecordExist");
                        } else
                        {
                            //Executing Command
                            using (SQLiteCommand insertcmd = new SQLiteCommand(insert, conn))
                            {

                                using (SQLiteDataReader reader2 = insertcmd.ExecuteReader())
                                {
                                }
                            }

                            conn.Close();

                            GoBackToAttendanceForm("NoRecord");

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
                recordsaved = MessageBox.Show("Student Record Saved.", "", okbtn);
                
            } else
            {
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
