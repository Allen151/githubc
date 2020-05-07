using System;
using System.Data;

namespace aboutDataset
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet("dsText");  // DataSet 对象
            DataTable dt = new DataTable("dtText");// DataTable 对象
            ds.Tables.Add(dt);  //将 DataTable 对象表添加到 DataSet 对象中
            DataColumn dc1 = new DataColumn("id", Type.GetType("System.Int32"),""); //创建一列
            DataColumn dc2 = new DataColumn("item", Type.GetType("System.String"),"");//类型为string 类型的列
            dt.Columns.Add(dc1);//将列添加到DataTable对象中
            dt.Columns.Add(dc2);
            for (int i=0;i<6 ;i++) {//循环创建5行
                DataRow dr  = dt.NewRow();
                dr["id"] = i;//为 dc1 赋值
                dr["item"] = "项" + i;
                dt.Rows.Add(dr);//将行添加到 DataTable 对象中
            }
            ds.AcceptChanges();//更新表最新的状态
            Console.WriteLine("合并前表的内容");
            printTable.printValue(ds);//调用输出表的方法输出表的内容
            
            DataTable dt1 = dt.Clone();//将 dt 对象的表结构克隆给 dt1 无内容
            //DataRow newRow = dt1.NewRow();//这部分内容可以不要
            //newRow["id"] = 0;
            //newRow["item"] = "";
            
            dt1.Rows.Add(new object[] { 8, "项8" });
            dt1.Rows.Add(new object[] { 9, "项9" });
            ds.Merge(dt1);  // dt1 合并到ds中
            Console.WriteLine("合并后表的内容");
            printTable.printValue(ds);
            Console.WriteLine("---------------DataSetc类的Clone()与Copy()方法--------------");
            ds.AcceptChanges();//取得最新数据
            Console.WriteLine("源数据");
            printTable.printValue(ds);//查看源数据

            DataSet ds1 = ds.Clone();//克隆来的
            DataSet ds2 = ds.Copy();// Copy 来的
            Console.WriteLine("-------------使用Clone()得到的DataSet-------------");
            printTable.printValue(ds1);
            Console.WriteLine("-------------使用Copy()得到的DataSet--------------");
            printTable.printValue(ds2);

            Console.ReadLine();
        }

        public class printTable {
            public static void printValue(DataSet ds) {
                foreach (DataTable table in ds.Tables) {//每个表拿出来
                    foreach (DataRow dr in table.Rows) {
                        foreach (DataColumn dc in table.Columns) {
                            Console.Write(dr[dc]+"\t");
                        }
                        Console.WriteLine();//输出完一行换行
                    }
                }
            }
        }
    }
}
