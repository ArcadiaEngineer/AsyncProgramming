using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTest.Winform
{
    public partial class Form1 : Form
    {

        public static int Count { get; set; } = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private async void btnGetFile_Click(object sender, EventArgs e)
        {
            string data = await ReadFile();
            tbxFile.Text = data; 
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            Count++;
            tbxCount.Text = Count.ToString();
        }

        private async Task<string> ReadFile()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader(@"C:\Users\Asus\source\repos\AsynchronousMultithreadProgramming\AsyncTest.Winform\File.txt"))
            {
                data = await s.ReadToEndAsync();
                await Task.Delay(5000);
                return  data;
            }
        }
    }
}
