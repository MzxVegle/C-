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
    public partial class check : Form
    {
        public check()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string code;
            char[] b = new char[20];
            //textBox1.Text.GetEnumerator().MoveNext();
            Boolean i = false;
            code = textBox1.Text;
            char[] codeArray = new char[20];
            for (int count = 0; count < code.Length; count++)
            {
                if ((int)code[count]>0 && (int)code[count]<127)
                {
                    i = true;
                    MessageBox.Show("成功！"+codeArray[count].ToString() + i.ToString());
                }
                else
                {
                    i = false;
                    MessageBox.Show("错误！"+ codeArray[count] + i.ToString());
                    break;
                }
            }
            if (i == true)
            {
                MessageBox.Show("合法允许登录！");
            }
            else
            {
                MessageBox.Show("非法字符不允许登录！");
            }
        }

    }
}

