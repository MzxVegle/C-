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
    public partial class findFrm : Form
    {
        private DataGridView dataGridView1;

        public findFrm(DataGridView dataGridView1)
        {
            InitializeComponent();
            this.dataGridView1 = dataGridView1;
        }

       

        private void findFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqltext = "select 学生.学号,姓名,性别,班级编号,籍贯,民族,成绩,考试次数,是否补修,是否重考,成绩确定 from 学生 join 成绩 on 成绩.学号 = 学生.学号 where 学生.姓名='"+textBox1.Text+"'";
            //systemFrm frm = new systemFrm();

            SQLHelper.search(sqltext, dataGridView1);
            
                
                MessageBox.Show("查询完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
