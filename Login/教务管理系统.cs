using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class systemFrm : Form
    {
        String name;
        public systemFrm(String username)
        {
            InitializeComponent();
            this.name = username;
        }

        private void systemFrm_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎您使用教务管理系统";
            string sqltext;
            object result;
            /*********获取用户名、启用日期、用户类型*********/
            sqltext = "select 姓名 from 用户 where 姓名 = '"+name+"'";
            result =SQLHelper.cmd(sqltext).ExecuteScalar();
            Username.Text = result.ToString();
            sqltext = "select 启用日期 from 用户 where 姓名 = '" + name + "'";
            result = SQLHelper.cmd(sqltext).ExecuteScalar();
            Usetime.Text = result.ToString();
            sqltext = "select 用户类型 from 用户 where 姓名 = '" + name + "'";
            result = SQLHelper.cmd(sqltext).ExecuteScalar();
            Usertype.Text = result.ToString();
            SQLHelper.cbbselect(comboBox1);
        }

        private void systemFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginFrm loginfrm = new LoginFrm();
            loginfrm.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            findFrm findfrm = new findFrm(dataGridView1);
            
            findfrm.Show();

        }

        private void regBtn_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegisterFrm regfrm = new RegisterFrm();
            regfrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteFrm df = new deleteFrm();
            df.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlterpasswordFrm AFrm = new AlterpasswordFrm(name);
            AFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SandT sandt = new SandT(dataGridView1);
            sandt.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            selectClass selclass = new selectClass(dataGridView1);
            selclass.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrmHelper.moveEffects(this, timer1, panel1);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqltext = "select * from " + comboBox1.Text;
            SQLHelper.search(sqltext, dataGridView1);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
