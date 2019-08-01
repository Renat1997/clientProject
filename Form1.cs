using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenatGaynullin
{


    public partial class Form1 : Form
    {

        public delegate void SendState(string state);
        public event SendState Send;
       
        public Form1()
        {
            InitializeComponent();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            int power = checkBox1.Checked ? 1 : 0;
            int cycle = checkBox2.Checked ? 1 : 0;
            int crash = checkBox3.Checked ? 1 : 0;
            Send?.Invoke(String.Concat(power, cycle, crash));

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


            int power = checkBox1.Checked ? 1 : 0;
            int cycle = checkBox2.Checked ? 1 : 0;
            int crash = checkBox3.Checked ? 1 : 0;
            Send?.Invoke(String.Concat(power, cycle, crash));

        }
        private void check()
        {
            int power = checkBox1.Checked ? 1 : 0;
            int cycle = checkBox2.Checked ? 1 : 0;
            int crash = checkBox3.Checked ? 1 : 0;
            Send?.Invoke(String.Concat(power, cycle, crash));
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {


            check();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }




        public int GetPort
        {
            get {
                int result = 0;
                int.TryParse(textBox1.Text, out result);
                return result;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }





        private CancellationTokenSource tokenSource;
        private void button1_Click(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            Task.Run(() =>
            {
                try
                {
                    listen.lis(this,tokenSource.Token);
                }
                catch
                {

                }
            });

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }
    }
}
