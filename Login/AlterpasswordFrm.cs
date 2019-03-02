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
    public partial class AlterpasswordFrm : Form
    {
        String username;
        public AlterpasswordFrm(String username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void AlterpasswordFrm_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = username;
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            /**********************开始是否为空规则验证：*******************************/
            if (txtold.Text == "")
            {
                MessageBox.Show("旧密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtnew.Text == "")
            {
                MessageBox.Show("新密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtcode.Text == "")
            {
                MessageBox.Show("验证码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /***********************开始是否正确规则验证：*********************************/
            else if(txtcode.Text != label5.Text)
            {
                 MessageBox.Show("验证码不正确！请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 txtcode.Text = "";
            }
            else 
            {
                DialogResult result;
                result = MessageBox.Show("确定修改吗？", "提示",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    String sqltext;
                    sqltext = "select * from 用户 where 密码 = '"+txtold.Text+"'";
                    //执行代码
                    if(SQLHelper.cmd(sqltext).ExecuteReader().Read())
                    {
                        sqltext = "update 用户 set 密码 = '" + txtnew.Text + "'where 姓名 ='" + txtUsername.Text + "'";
                        SQLHelper.AlterPasswords(sqltext);
                        MessageBox.Show("更改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtold.Text = "";
                        txtold.Focus();
                        MessageBox.Show("旧密码不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            Random r = new Random();
            int ran = r.Next(1000, 9999);
            label5.Text = ran.ToString();
            label5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
