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
using System.Xml.Linq;

namespace RFID_Attendance_System
{

    public partial class DataStatistics : Form
    {
        //Getting database path
        public static string dbname;
        public static string dbpath;
        public static string selected_eventdate;

        public DataStatistics()
        {
            InitializeComponent();
            dbname = "RFID DB.db";
            dbpath = Path.Combine(dbname);

            //Set muna natin yung visibility ng false kasi nag papakita yung chart kahit wlang value

            //then set natin by true sa ClearChartsValue na function

            PopulateDateCombobox();
            LoadLatestData();
        }

        public void PopulateDateCombobox()
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source= {dbpath}; Version= 3;"))
            {
                conn.Open();

                //need natin ng array na mag sosort ng mga events
                List<string> dates = new List<string>();


                string GetData = $"select distinct EventID from attendance";
                using (SQLiteCommand cmd = new SQLiteCommand(GetData, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        //loop natin na habang nag reread sya 
                        while (reader.Read())
                        {
                            //lalagay natin sa array yung nareread nya na data, bascially 0 kasi yung frist column target natin
                            dates.Add(reader.GetString(0));

                        }

                        ///sort natin yung arrat into decending para makuha natin yung latest date 
                        dates = dates.OrderByDescending(x => x).ToList();

                        //then looop tayo para ilagay nayung laman ng array nayun sa combobox
                        foreach (string date in dates)
                        {
                            event_date.Items.Add(date);
                            event_date.AutoCompleteCustomSource.Add(date);
                        }
                    }
                }

                conn.Close();
            }
        }

        public void LoadLatestData()
        {
            //Clear natin muna yung value to avoid duplication ng mga charts
            ClearChartsValue();


            if (event_date.Text == "Select Year and Section")

            //then itong condistion sa baba need natin alamin if may laman naba yung combobox then dun tayo mag
            //launch ng activities 
            {
                if (event_date.Items.Count > 0)
                {
                    event_date.Text = event_date.Items[0].ToString();


                    //Extract natin yung date kasi yung nakukuha natin value is ganto EventName(12,12,2005)
                    //need lang nati yung 2005
                    selected_eventdate = event_date.SelectedItem.ToString();
                    int startIndex = selected_eventdate.LastIndexOf('(');
                    string year = selected_eventdate.Substring(startIndex + 7, 4);
                    Console.WriteLine(year);
                }
            }

        }

        public void LoadData(string event_year)
        {
            string[] Sections = {
                "BSCS - 1A DM", "BSCS - 1A BA", "BSIT - 1A BA" , "BSIT - 1A BPO", "BSIT - 1B BPO", "BSIT - 1A NS", "BSIT - 1B NS", "BSIT - 1A WMAD", "BSIT - 1B WMAD", "BSEMC - 1A GD", "BSEMC - 1A DA",
                "BSCS - 2A DM", "BSCS - 2A BA", "BSIT - 2A BA" ,"BSIT - 2A BPO", "BSIT - 2B BPO", "BSIT - 2A NS", "BSIT - 2B NS", "BSIT - 2A WMAD", "BSIT - 2B WMAD", "BSEMC - 2A GD", "BSEMC - 2A DA",
                "BSCS - 3A DM", "BSCS - 3A BA", "BSIT - 3A BA" ,"BSIT - 3A BPO", "BSIT - 3B BPO", "BSIT - 3A NS", "BSIT - 3B NS", "BSIT - 3A WMAD", "BSIT - 3B WMAD","BSEMC - 3A GD", "BSEMC - 3A DA",
                "BSCS - 4A DM", "BSCS - 4A BA", "BSIT - 4A BA" ,"BSIT - 4A BPO", "BSIT - 4B BPO", "BSIT - 4A NS","BSIT - 4B NS", "BSIT - 4A WMAD", "BSIT - 4B WMAD", "BSEMC - 4A GD", "BSEMC - 4A DA"
                };

            Console.WriteLine(Sections.Length);
            string[] NoOfPresent = new string[Sections.Length];
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
                    string GetData = $"select * from attendance where EventID like @Event_ID and Course = '{Sections[i]}'";
                    using (SQLiteCommand cmd = new SQLiteCommand(GetData, conn))
                    {
                        cmd.Parameters.AddWithValue("@Event_ID", "%" + event_year + "%");
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
                int[] NoOfStudentPerYear = new int[4];
                for (int i = 1; i < 5; i++)
                {
                    string StudentPerYear = $"select * from attendance where EventID like @Event_ID and Course like '%{i}%'";
                    using (SQLiteCommand cmd1 = new SQLiteCommand(StudentPerYear, conn))
                    {
                        cmd1.Parameters.AddWithValue("@Event_ID", "%" + event_year + "%");
                        using (SQLiteDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NoOfStudents++;
                            }

                            NoOfStudentPerYear[i - 1] = NoOfStudents;
                            Console.WriteLine($"{i}: {NoOfStudents}");
                            NoOfStudents = 0;
                        }
                    }
                }

                //Get all late students from 1st - 4th year
                string[] late = { "No", "Yes" };
                int[] NoOfLates = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    string GetLate = $"select * from attendance where EventID like @Event_ID and late = '{late[i]}'";
                    using (SQLiteCommand cmd1 = new SQLiteCommand(GetLate, conn))
                    {
                        cmd1.Parameters.AddWithValue("@Event_ID", "%" + event_year + "%");
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
                for (int i = 0; i <= Sections.Length; i++)
                {
                    if (i <= 5)
                    {
                        frstyrtb1.Series["1st Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 6 && i <= 10)
                    {
                        frstyrtb2.Series["1st Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 11 & i <= 16)
                    {
                        scndyr1.Series["2nd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 17 & i <= 21)
                    {
                        scndyr2.Series["2nd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 22 & i <= 27)
                    {
                        thrdyr1.Series["3rd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 28 & i <= 32)
                    {
                        thrdyr2.Series["3rd Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 33 & i <= 38)
                    {
                        frthyr1.Series["4th Year"].Points.AddXY(Sections[i], NoOfPresent[i]);

                    }
                    else if (i >= 39 & i <= 43)
                    {
                        frthyr2.Series["4th Year"].Points.AddXY(Sections[i], NoOfPresent[i]);
                        Console.WriteLine($"{Sections[i]} {NoOfPresent[i]}");

                    }
                }

                conn.Close();
            }
        }


        //since my default value yung combox once then tinawag nating yung LoadLatestData na function nag change yung value then na trigger itong function
        private void event_date_SelectedValueChanged(object sender, EventArgs e)
        {
            //Clear natin muna yung value to avoid duplication ng mga charts
            ClearChartsValue();
            //This code below willrun once the combobox is been clicked
            string[] cmbbx_items = new string[event_date.Items.Count];
            event_date.Items.CopyTo(cmbbx_items, 0);

            if (cmbbx_items.Contains(event_date.Text))
            {

                //Extract natin yung date kasi yung nakukuha natin value is ganto EventName(12,12,2005)
                //need lang nati yung 2005
                selected_eventdate = event_date.SelectedItem.ToString();
                int startIndex = selected_eventdate.LastIndexOf('(');
                string year = selected_eventdate.Substring(startIndex + 7, 4);
                Console.WriteLine(year);

                //Then tawagin natin yung function na mag papopulate ng mga charts
                LoadData(year);

            }
            else
            {
                MessageBox.Show("You've entered invalid event name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearChartsValue()
        {
            frsttofrth.Series["1stYear"].Points.Clear();
            frsttofrth.Series["2ndYear"].Points.Clear();
            frsttofrth.Series["3rdYear"].Points.Clear();
            frsttofrth.Series["4thYear"].Points.Clear();

            lates.Series["Late"].Points.Clear();

            frstyrtb1.Series["1st Year"].Points.Clear();
            frstyrtb2.Series["1st Year"].Points.Clear();
            scndyr1.Series["2nd Year"].Points.Clear();
            scndyr2.Series["2nd Year"].Points.Clear();
            thrdyr1.Series["3rd Year"].Points.Clear();
            thrdyr2.Series["3rd Year"].Points.Clear();
            frthyr1.Series["4th Year"].Points.Clear();
            frthyr2.Series["4th Year"].Points.Clear();

            frsttofrth.Visible = true;
            frstyrtb1.Visible = true;
            frstyrtb2.Visible = true;
            scndyr1.Visible = true;
            scndyr2.Visible = true;
            thrdyr1.Visible = true;
            thrdyr2.Visible = true;
            lates.Visible = true;
        }
    }
}