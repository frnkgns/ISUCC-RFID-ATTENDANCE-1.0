using SnappyWinscard;
using System;
using System.ComponentModel;
using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace Attendance_with_RFID
{
    public class cardReader
    {
        public CardIo CardIo { get; set; }
        public cardReader()
        {
        }

        public void Initialize()
        {
            CardIo = new CardIo();
            CardIo.ReaderStateChanged += OnReaderStateChanged;
        }

        public void OnReaderStateChanged(CardIo.ReaderState readerState)
        {
            ChangeStatus();
        }
        public string GetCardUId(CardIo cardIo)
        {
            return cardIo.GetCardUID();
        }
        public bool ConnectCard()
        {
            return CardIo.ConnectCard();
        }
        public virtual void ChangeStatus()
        {
        }
        public Guna2TextBox ChangeStatus(Form form, Guna2TextBox textBox, string message)
        {
            ThreadSafe(() => { textBox.Text = message; }, form);

            return textBox;
        }
        public TextBox ChangeStatus(Form form, TextBox textBox, string message)
        {
            ThreadSafe(() => { textBox.Text = message; }, form);

            return textBox;
        }
        public Label ChangeStatus(Form form, Label lbl, string message)
        {
            ThreadSafe(() => { lbl.Text = message; }, form);

            return lbl;
        }
        public static void ThreadSafe(Action callback, Form form)
        {
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (obj, e) =>
            {
                if (form.InvokeRequired)
                    form.Invoke(callback);
                else
                    callback();
            };
            worker.RunWorkerAsync();
        }
    }
}