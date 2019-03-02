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
    public partial class RegisterFrm : Form
    {
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
             string sqltext; 
             sqltext = "select * from 用户 where 姓名='" + textBox1.Text + "'";             
             if (textBox1.Text == "" || textBox2.Text == "")
             {
                 MessageBox.Show("用户名和密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else if(textBox3.Text!= label4.Text)
             {
                 MessageBox.Show("验证码错误！请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 textBox3.Text = "";
                 textBox3.Focus();
             }
             else if (SQLHelper.check(textBox1.Text) == false)
             {
                 MessageBox.Show("用户名中含有非法字符！请使用英文或者数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 textBox1.Text = "";
                 textBox1.Focus();
                 textBox2.Text = "";
             }
             else if (SQLHelper.check(textBox2.Text) == false)
             {
                 MessageBox.Show("密码中含有非法字符！请使用英文或者数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 textBox2.Text = "";
                 textBox2.Focus();
             }
             else
             {
                 if (SQLHelper.cmd(sqltext).ExecuteReader().Read())
                 {
                     MessageBox.Show("用户名已存在！请选择其他用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     SQLHelper.cmd(sqltext).ExecuteReader().Close();
                 }
                 else
                 {

                     SQLHelper.cmd(sqltext).ExecuteReader().Close();
                     sqltext = "insert into 用户(姓名,密码,用户类型,启用日期) values ('" + textBox1.Text + "','" + textBox2.Text + "','管理员',getdate())";
                     SQLHelper.cmd(sqltext).ExecuteNonQuery();
                     MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                 }
             }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            Random rd = new Random();
            int ran = rd.Next(1000, 9999);
            label4.Text = ran.ToString();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterFrm_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }
    }
}
