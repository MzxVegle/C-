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
    public partial class LoginFrm : Form
    {
        
        public LoginFrm()
        {
            InitializeComponent();
            
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {          
            if (UserName.Text == "")
            {
                MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwords.Text == "")
            {
                MessageBox.Show("密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SQLHelper.check(UserName.Text) == false)
            {
                MessageBox.Show("用户名中含有非法字符！请使用英文或者数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserName.Text = "";
                UserName.Focus();
                passwords.Text = "";
            }
            else if (SQLHelper.check(passwords.Text) == false)
            {
                MessageBox.Show("密码中含有非法字符！请使用英文或者数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwords.Text = "";
                passwords.Focus();
            }
            else
            {
                String sql;
                sql = "select * from 用户 where 姓名='" + UserName.Text + "'and 密码='" + passwords.Text + "'";
                try
                {
                    if (SQLHelper.cmd(sql).ExecuteReader().Read())
                    {
                        MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        systemFrm frm = new systemFrm(UserName.Text);
                        frm.Show();
                        this.Hide();

                    }
                    else
                    {

                        MessageBox.Show("登录失败！用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("数据库连接异常！请联系管理员获得帮助"+ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
           
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            UserName.Focus();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegisterFrm regfrm = new RegisterFrm();
            regfrm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            FrmHelper.openEffects(this, timer1);
            
        }

        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
