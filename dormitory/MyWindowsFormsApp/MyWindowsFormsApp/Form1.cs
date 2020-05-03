using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;//链接oracle数据库用到
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string empno = textEmpno.Text;
            string[] values = new string[8];
            connectDB.testConnect(empno,ref values);
            Console.WriteLine("{0}",values[1]);
            //showData.dataGridViewShow(values);
        }
    }
}
