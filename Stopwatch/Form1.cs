using System;
using System.Drawing;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer1;
        int ss = 0, mm = 0;
        public Form1()
        {
            InitializeComponent();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; // specify interval time as you want
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = "";
            ss++;

            if (ss % 60 == 0)
            {
                mm++;
                ss = 0;
            }

            if (mm < 10)
            {
                if (ss < 10)
                {

                    time += "0" + mm + ":" + "0" + ss;
                }
                else
                {
                    time += "0" + mm + ":" + ss;
                }

            }
            else
            {
                if (ss < 10)
                {

                    time += mm + ":" + "0" + ss;
                }
                else
                {
                    time += mm + ":" + ss;
                }

            }
            label1.Text = time;

            if (mm >= 59 && ss >= 59)
            {
                timer1.Stop();
                DialogResult dialog = MessageBox.Show("Stoper has exceeded its maximum values!", "Error", MessageBoxButtons.OK);
                if (dialog == DialogResult.OK)
                {
                    Application.Exit();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ss = 0;
            mm = 0;
            label1.Text = "00:00";
        }
    }
}