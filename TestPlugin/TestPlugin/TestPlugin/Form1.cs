using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TestPlugin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text +=  ":"  + System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = "I am created from Plugin Context";
            form.StartPosition = FormStartPosition.CenterParent;
            form.WindowState = FormWindowState.Normal;
            form.Width = 200;
            form.Height = 200;
            form.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process closeProc = System.Diagnostics.Process.GetProcessById(proc.Id);
            string Message = "";
            Message += "Current Plugin : " + Application.ExecutablePath;
            Message += "\nProcess Host ID: " + closeProc.Id;
            Message += "\nProcess Host Name:" + closeProc.ProcessName;
            MessageBox.Show(this, Message, "Show MessageBox via Plugin Context", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process closeProc = System.Diagnostics.Process.GetProcessById(proc.Id);
            MessageBox.Show(this, "Closing Application =>" + closeProc.Id + ":" + closeProc.ProcessName, "Close Process Test via Plugin Context", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            closeProc.Close();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Closing UI running inside Plugin Context and Exit Plugin Instance", "Close UI and Plugin Test via Plugin Context", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string UIThread = Thread.CurrentThread.ManagedThreadId.ToString();
            Thread thread = new Thread(() => { 
                 System.Diagnostics.Process proc =  System.Diagnostics.Process.GetCurrentProcess();
                
                Thread.Sleep(2000);
                MessageBox.Show("I was executed by a new thread with ID " + Thread.CurrentThread.ManagedThreadId.ToString() + "\n" + "UI thread is " + UIThread, "Create Thread Test via Plugin Context", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });

            thread.IsBackground = true;
            thread.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\windows\system32\notepad.exe");
        }
    }
}
