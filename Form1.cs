using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventTracer
{
    public partial class Form1 : Form
    {
        int start = 0;

        public Form1()
        {
            InitializeComponent();
        }

        static async void RunConsumer()
        {
            var eventConsumer = new EventConsumer();

            var e1 = await eventConsumer.ReadEvent(0);
            var e2 = await eventConsumer.ReadEvent(1);

            for (int i = 2; i < 400; i++)
            {
                var e3 = await eventConsumer.ReadEvent(i);

                if (e3.priority == e1.priority && e3.priority == e2.priority)
                {
                    eventConsumer.Alert(e1, e2, e3);
                }

                e1 = e2;
                e2 = e3;
            }
        }

        async void RunProducer()
        {
            var eventProducer = new EventProducer();

            for (int i = 0; i < 400; i++)
            {
                var event1 = eventProducer.GenerateRandomEvent(i);
                await eventProducer.PutEvent(event1);

                progressBar1.Value = ((i + 1) * 100) / 400;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();

            RunProducer();
            RunConsumer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
            int second = start++;
            label1.Text = GetTimeText(second);
        }

        public string GetTimeText(int second)
        {
            var s = second % 60;
            var m = (second - s) / 60;

            return m + " Dakika " + s + " Saniye";
        }

        public void WriteAlert(string message)
        {
            richTextBox1.Text += "\n" + message;
        }
    }
}
