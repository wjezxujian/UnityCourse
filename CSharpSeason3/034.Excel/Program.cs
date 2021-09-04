using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034.Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            //"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            //"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

            string fileName = "装备信息.xls";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";

            //创建连接到数据源的对象
            OleDbConnection connection = new OleDbConnection(connectionString);

            //打开链接
            connection.Open();

            string sql = "select * from [Sheet1$]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);

            DataSet dataSet = new DataSet(); //用来存放数据
            adapter.Fill(dataSet);

            connection.Close();

            DataTableCollection tableCollection = dataSet.Tables;
            DataTable dataTable = tableCollection[0];
            DataRowCollection rowCollection = dataTable.Rows;

            foreach (DataRow row in rowCollection)
            {
                //取得row中前8列的数据 索引
                for (int i = 0; i < 8; ++i)
                {
                    Console.Write(row[i] + " ");
                }

                Console.WriteLine();
                 
            }

            Console.ReadKey();

            
        }
    }
}
