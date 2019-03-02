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
    public partial class SandT : Form
    {
        DataGridView dgv;
        public SandT(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        private void SandT_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqltext;
            if (radioButton1.Checked == true)
            {
                sqltext = "select * from 教师 where 姓名 = '"+textBox1.Text+"'";
                SQLHelper.search(sqltext,dgv);
                MessageBox.Show("教师查询成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (radioButton2.Checked == true)
            {
                sqltext = "select * from 学生 where 姓名 = '" + textBox1.Text+"'";
                SQLHelper.search(sqltext, dgv);
                MessageBox.Show("学生查询成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string sqltext = "select * from 教师";
            SQLHelper.search(sqltext, dgv);
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string sqltext = "select * from 学生";
            SQLHelper.search(sqltext, dgv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
