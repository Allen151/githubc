using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace MyWindowsFormsApp
{
    public partial class Form2 : Form
    {
        string strcon = @"Data Source=orcl;Persist Security Info=True;User ID=scott;Password=tiger;Unicode=True";//链接字符
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            using (OracleConnection orclcon = new OracleConnection(strcon)) { //链接完会自动关闭
                orclcon.Open();//打开数据库
                string sql = "select * from student";//需要执行的sql语句
                OracleCommand command = new OracleCommand(sql,orclcon);//实例化OracleCommand对象
                OracleDataReader reader = command.ExecuteReader();//创建OracleDataReader对象
                if (reader.HasRows) {//判断是否有结果返回
                    while (reader.Read()) {//依次读取行
                        txtAllStu.Text += reader[0].ToString() + reader[1].ToString()+reader[2].ToString() + 
                            reader[3].ToString()+ reader[4].ToString() + reader[5].ToString();
                    }
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OracleConnection orclcon = null;
            try {
                string stuID = txtStuID.Text.Trim();//取值，去空格
                string stuName = txtName.Text.Trim();
                string stuXB;//性别
                if (cckXB.Checked)
                {
                    stuXB = "M";
                }
                else {
                    stuXB = "W";
                }
                DateTime stuBirthday1 = Convert.ToDateTime(dateTimePicker1.Text);//类型的转换
                string stuBirthday = stuBirthday1.ToShortDateString();//只保留到d才可以插入数据库
                string stuNative = txtNative.Text.Trim();
                string stuAddress = txtAddress.Text.Trim();
                orclcon = new OracleConnection(strcon);//链接
                OracleCommand command = new OracleCommand();
                string inSql = "insert into student (studentno, studentname, XB, birthday, native, address) values ('" + stuID + "', '" + stuName + "', '" + stuXB + "', to_date('" + stuBirthday + "', 'yyyy.MM.dd'), '" + stuNative + "', '" + stuAddress + "')";
                command.CommandText = inSql;
                command.CommandType = CommandType.Text;
                command.Connection = orclcon;
                orclcon.Open();
                if (command.ExecuteNonQuery() > 0) {
                    MessageBox.Show("添加成功！");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                orclcon.Close();
            }
        }
    }
}
