using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackGWorker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < 7500; i++)
            {
                Thread.Sleep(100);
                sum += i;
                backgroundWorker1.ReportProgress(i);
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
            }
            e.Result = sum;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = e.ProgressPercentage.ToString() + " %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label1.Text = "Bitti";
            }
            else if(e.Error!=null)
            {
                label1.Text = e.Error.Message;
            }
            else
            {
                label1.Text = "Sum = " + e.Result.ToString();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            btnGetData.Text = label1.Text;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
