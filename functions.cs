using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RFID_Attendance_System
{
    public class functions
    {
        public static void ResizePanelWidth(System.Windows.Forms.Panel basePanel, System.Windows.Forms.Panel toChangePanel, int subtrahend)
        {
            // Adjust the button's size based on the form's size
            int width = basePanel.Width - subtrahend; // Adjust the margin as needed
            toChangePanel.Width = width;
        }

        public static void ResizeLabelWidth(System.Windows.Forms.Panel basePanel, System.Windows.Forms.Label lbl, int subtrahendl)
        {
            // Adjust the button's size based on the form's size
            int width = basePanel.Width - subtrahendl; // Adjust the margin as needed
            lbl.Width = width;
        }
        public static void ResizePanelHeight(System.Windows.Forms.Panel basePanel, System.Windows.Forms.Panel toChangePanel, int subtrahend)
        {
            // Adjust the button's size based on the form's size
            int height = basePanel.Height - subtrahend; // Adjust the margin as needed
            toChangePanel.Height = height;
        }
        public static void ResizeGunaTextBoxWidth(System.Windows.Forms.Panel basePanel, Guna2TextBox tb, int subtrahendl)
        {
            // Adjust the button's size based on the form's size
            int width = basePanel.Width - subtrahendl; // Adjust the margin as needed
            tb.Width = width;
        }
    }
}
