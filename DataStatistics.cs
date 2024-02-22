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
using System.Data.SQLite;
using System.IO;
using System.Web.UI.WebControls;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace RFID_Attendance_System
{
    public partial class DataStatistics : Form
    {
        public DataStatistics()
        {
            InitializeComponent();
            LoadData();
        }


        public void LoadData()
        {
            //Getting database path
            string dbname = "RFID DB.db";
            string dbpath = Path.Combine(dbname);
            string [] Sections = {
                "BSCS - 1A DM", "BSCS - 1A BA", "BSIT - 1A BA" , "BSIT - 1A BPO", "BSIT - 1B BPO", "BSIT - 1A NS", "BSIT - 1B NS", "BSIT - 1A WMAD", "BSIT - 1B WMAD", "BSEMC - 1A GD", "BSEMC - 1A DA",
                "BSCS - 2A DM", "BSCS - 2A BA", "BSIT - 2A BA" ,"BSIT - 2A BPO", "BSIT - 2B BPO", "BSIT - 2A NS", "BSIT - 2B NS", "BSIT - 2A WMAD", "BSIT - 2B WMAD", "BSEMC - 2A GD", "BSEMC - 2A DA",
                "BSCS - 3A DM", "BSCS - 3A BA", "BSIT - 3A BA" ,"BSIT - 3A BPO", "BSIT - 3B BPO", "BSIT - 3A NS", "BSIT - 3B NS", "BSIT - 3A WMAD", "BSIT - 3B WMAD","BSEMC - 3A GD", "BSEMC - 3A DA",
                "BSCS - 4A DM", "BSCS - 4A BA", "BSIT - 4A BA" ,"BSIT - 4A BPO", "BSIT - 4B BPO", "BSIT - 4A NS","BSIT - 4B NS", "BSIT - 4A WMAD", "BSIT - 4B WMAD", "BSEMC - 4A GD", "BSEMC - 4A DA"
                };

            Console.WriteLine(Sections.Length);
            string [] NoOfPresent = new string[Sections.Length];
            string[] NoOfLatePerSection = new string[Sections.Length];
            int NoOfStudents = 0;
            string strNos;

            //Connecting to database
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;"))
            {
                conn.Open();

                //loop the query
                for (int i = 0; i < Sections.Length; i++)
                {
                    //Creating query and Running Query
                    string GetData = $"select * from idinfo where courseandfield = '{Sections[i]}'";
                    using (SQLiteCommand cmd = new SQLiteCommand(GetData, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            //Serve lang as counter since d ko alam paano mag count pa sa sql ayaw gumana dito ee
                            //habang may line syang nababasa mag iincrement tayo ng 1
                            while (reader.Read())
                            {
                                NoOfStudents++;
                            }

                            //since naka integer yon needed natin iconvert it into string
                            //then needed natin ilagay yung value na into index no# ng array
                            //then reset natin value ng NoOfStudent into 0 kasi mag iincrement lang if hindi
                            strNos = Convert.ToString(NoOfStudents);
                            NoOfPresent[i] = strNos;
                            Console.WriteLine(NoOfPresent[i]);

                            NoOfStudents = 0;
                        }
                    }
                }

                //Get specific yearlevel
                NoOfStudents = 0;
                int [] NoOfStudentPerYear = new int[4];
                for (int i = 1; i < 5; i++)
                {
                    string StudentPerYear = $"select * from idinfo where courseandfield like '%{i}%'";
                    using (SQLiteCommand cmd1 = new SQLiteCommand(StudentPerYear, conn))
                    {
                        using (SQLiteDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NoOfStudents ++;
                            }

                            NoOfStudentPerYear[i - 1] = NoOfStudents;
                            Console.WriteLine($"{i}: {NoOfStudents}");
                            NoOfStudents = 0;
                        }
                    }
                }

                //Get all late students from 1st - 4th year
                string[] late = { "No", "Yes" };
                int [] NoOfLates = new int[2]; 
                for (int i = 0; i < 2; i++)
                {
                    string GetLate = $"select * from idinfo where late = '{late[i]}'";
                    using (SQLiteCommand cmd1 = new SQLiteCommand(GetLate, conn))
                    {
                        using (SQLiteDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NoOfStudents++;
                            }
                            NoOfLates[i] = NoOfStudents;
                            NoOfStudents = 0;

                        }
                    }
                }

                //Setting up charts para may value
                frsttofrth.Series["1stYear"].Points.AddXY("1st Year", NoOfStudentPerYear[0]);
                frsttofrth.Series["2ndYear"].Points.AddXY("2nd Year", NoOfStudentPerYear[1]);
                frsttofrth.Series["3rdYear"].Points.AddXY("3rd Year", NoOfStudentPerYear[2]);
                frsttofrth.Series["4thYear"].Points.AddXY("4th Year", NoOfStudentPerYear[3]);

                lates.Series["Late"].Points.AddXY("On Time", NoOfLates[0]);
                lates.Series["Late"].Points.AddXY("Late", NoOfLates[1]);

                //Looping kasi nakakatamad
                for(int i = 0; i <= Sections.Length; i++)
                {
                    if (i <= 5)
                    {
                        frstyrtb1.Series["1st Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if (i >= 6 && i <= 10)
                    {
                        frstyrtb2.Series["1st Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if(i >= 11 & i <= 16)
                    {
                        scndyr1.Series["2nd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if(i >= 17 & i <= 21)
                    {
                        scndyr2.Series["2nd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if (i >= 22 & i <= 27)
                    {
                        thrdyr1.Series["3rd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if(i >= 28 & i <= 32)
                    {
                        thrdyr2.Series["3rd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if (i >= 33 & i <= 38)
                    {
                        frthyr1.Series["4th Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    } else if ( i >= 39 & i <= 43)
                    {
                        frthyr2.Series["4th Year"].Points.AddXY(Sections[i], NoOfPresent[i]);
                        Console.WriteLine($"{Sections[i]} {NoOfPresent[i]}");

                    }
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void frstyrtb2_Click(object sender, EventArgs e)
        {

        }
    }
}
