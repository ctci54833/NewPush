using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACI_318_14_RCBEAM_CODECHECK;



namespace DLLTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            string Testmsg;



            ACI_318_14_RCBEAM_CODECHECK.codecheck.code9112("TEST", "ABC", out result, out Testmsg);
            
            MessageBox.Show(result +"\r\n" + Testmsg );


        }

        private void button2_Click(object sender, EventArgs e)
        {
            double LRho;
            double Rho;
            bool result;
            string msg;

            codecheck.Code9_6_1_2_SI(280, 4200, 50, 80, 45, out Rho, out  LRho, out result, out msg);
            
            MessageBox.Show(Rho +"\r\n" + LRho +"\r" + result +"\r" + msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool OKNG;
            string MSG;
            codecheck.Code25_2_2_SI(40, out OKNG, out MSG);
            MessageBox.Show(OKNG + "\r" + MSG);


        }
    }
}
