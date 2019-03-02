using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class selectClass : Form
    {
        DataGridView dgv;
        public selectClass(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select 选课ID,学生.学号,学生.姓名,学生.性别,班级名称,学生.身份证号,籍贯,学籍,学生.民族,班级名称,时间天,时间节,上课地点,(教师.姓名) as 授课教师 from 学生 " +
                "join 选课 on 选课.学号 = 学生.学号  " +
                "join 班级 on 选课.班级编号 = 班级.班级编号 " +
                "join 课程表 on 课程表.授课编号 = 选课.授课编号 " +
                "join 教师 on 教师.职工编号 = 课程表.授课教师 " +
                "where 学生.姓名 = '汪平'";
            //MessageBox.Show(sql);
            SQLHelper.search(sql, dgv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
