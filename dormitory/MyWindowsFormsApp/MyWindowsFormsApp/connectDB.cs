using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;

namespace MyWindowsFormsApp
{
    class connectDB
    {
        public static void testConnect(string empno,ref string[] values)
        {
            //声明定义链接字符串
<<<<<<< HEAD
            //string strCon = "Data Source=orcl;Persist Security Info=True;User ID=scott;Password=tiger;Unicode=True";
            string strCon = "Data Source = bisdev; Persist Security Info = True; User ID = format; Password = format123; Unicode = True";
=======
            string strCon = "Data Source=orcl;Persist Security Info=True;User ID=scott;Password=tiger;Unicode=True";
>>>>>>> cccc549be7be453826a556ef27ece9613208f9f6
            //实例化链接对象8
            OracleConnection conn = new OracleConnection();
            //try
            //{
                //链接字符
                conn.ConnectionString = strCon;
                //打开数据
                conn.Open();
                MessageBox.Show("打开成功，状态" + conn.State);
                //操作数据库的方法，传递一个雇员工号，数据库的链接，查询出雇员
                values = selectEmp(empno,conn);
            conn.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("链接失败");
            //}
            //finally {
            //    conn.Close();
            //    MessageBox.Show("关闭数据库成功");
            //}
        }
        /// <summary>
        /// OracleCommand.ExecuteReader() 作用于select 查询语句，返回DataRead 对象
        /// OracleCommand.ExecuteNonQuery()作用于 insert update delete 更新操作，返回影响的行数
        /// 
        /// OracleDataReader 如何访问数据库
        /// </summary>
        /// <param name="empno"></param>
        /// <param name="conn"></param>
        public static string[] selectEmp(string empno, OracleConnection conn)
        {
            //定义一个数组存放查询的结果集
            string[] values = new string[8];
            //需要执行的sql语句，CommandText 属性的内容
            string empnoEnquirySql = "select * from EMP where empno='" + empno + "'";
            //执行 commandText 值
            OracleCommand commandEmpno = new OracleCommand(empnoEnquirySql, conn);
            //执行 commandText 属性指定的内容，返回DataReader对象。创建 DataRead 对象
            OracleDataReader empDataRead = commandEmpno.ExecuteReader();

            //如下：如何通过 DataReader 对象访问数据库
            if (empDataRead.HasRows) //有数据
            {
                while (empDataRead.Read()) {//依次读取行
                    empDataRead.GetValues(values);//取得所有字段的值，存放于 values 数组中。
                    return values;
                    //foreach (var value in values)
                    //    dataGridView1.Rows.Add(value);
                }
            }
            else { //没数据
                MessageBox.Show("不存在该员工");
                return values;
            }
            return values;
        }
        /// <summary>
        /// 说明Command 的Command.CommandType 属性的不同处
        /// </summary>
        /// <param name="empno"></param>
        /// <param name="conn"></param>
        //public static void selectEmp(string empno, OracleConnection conn)
        //{
        //    //CommandType属性设置为CommandType.TableDirect时，要求CommandText 的值必须是表名，不能是SQL
        //    //需要执行的sql语句，CommandText 属性的内容
        //    string empnoEnquirySql = "select * from EMP where empno=" + empno + ";";

        //    //使用无参构造
        //    OracleCommand commandEmpno = new OracleCommand();

        //    //为commandEmpno 对象的属性赋值，两种方法作用是一样的
        //    commandEmpno.CommandText = empnoEnquirySql;//执行的sql 语句属性
        //    commandEmpno.CommandType = CommandType.TableDirect;//CommandText 需要是表名
        //    commandEmpno.Connection = conn;//数据库链接对象

        //    //为commandEmpno 对象的属性赋值，两种方法作用是一样的
        //    commandEmpno.CommandText = "select * from emp";//执行的sql 语句属性
        //    commandEmpno.CommandType = CommandType.Text;//CommandText 需要是表名
        //    commandEmpno.Connection = conn;//数据库链接对象
        //}
    }
}
