using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsFormsApp
{
    class showData
    {
        public static void dataGridViewShow(string[] values) {
            Form1 form = new Form1();
            //展示内容
            foreach (var value in values)
                form.dataGridView1.Rows.Add(value);
        }
    }
}
