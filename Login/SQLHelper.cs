using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Login
{
    class SQLHelper
    {
        public static SqlConnection conet()/*创建SQL链接函数*/
        {
            String conetstring = "server=localhost;database=教务管理201525040248;integrated security = SSPI";
            SqlConnection conn = new SqlConnection(conetstring);
            try
            {
                conn.Open();
                
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接异常！请联系管理员获得帮助" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return conn;
        }
        public static SqlCommand cmd(string sql)/*SQL代码执行函数*/
        {

            SqlCommand cmd = SQLHelper.conet().CreateCommand();
            cmd.CommandText = sql;
            return cmd;
        }
        public static void search(String sql,DataGridView dgv)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(SQLHelper.cmd(sql));
            
            DataSet ds = new DataSet();
            adapter.Fill(ds, "table1");
            dgv.DataSource = ds.Tables["table1"];
            SQLHelper.conet().Close();
            
        }

       
        public static void find(ComboBox cbb1, string sql, DataGridView dgv)
        {
            
            cbb1.Items.Clear();
            cbb1.Text = "";
            SqlDataAdapter adapter = new SqlDataAdapter(SQLHelper.cmd(sql));
            
                DataSet ds = new DataSet();
                adapter.Fill(ds, "table1");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cbb1.Items.Add(ds.Tables[0].Rows[i][dgv.Columns[0].Name.ToString()].ToString());
                }
                SQLHelper.conet().Close();
            
        }
        public static void deleteInfo(String sql,ComboBox cbb,DataGridView dgv) 
        {
           
        }



        public static void AlterPasswords(String sql)/*密码修改模块*/
        {
            SQLHelper.cmd(sql).ExecuteNonQuery();
            SQLHelper.conet().Close();
            
        }
        public static void cbbselect(ComboBox cbb)
        {
            cbb.Items.Add("班级");
            cbb.Items.Add("部门");
            cbb.Items.Add("成绩");
            cbb.Items.Add("教师");
            cbb.Items.Add("课程");
            cbb.Items.Add("课程表");
            cbb.Items.Add("选课");
            cbb.Items.Add("学生");
            cbb.Items.Add("专业");
        }
        public static Boolean check(string code)
        {
            Boolean i = false;
            for (int count = 0; count < code.Length; count++)
            {
                if ((int)code[count] > 0 && (int)code[count] < 127)
                    i = true;
                else
                {
                    i = false;
                    break;
                }
            }
            return i;
        }
    }
    
    
    
}
