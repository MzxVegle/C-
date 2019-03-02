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
    public partial class deleteFrm : Form
    {
        public deleteFrm()
        {
            InitializeComponent();
        }

        private void deleteFrm_Load(object sender, EventArgs e)
        {
            SQLHelper.cbbselect(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqltext;
            sqltext = "select * from " + comboBox1.Text;
            SQLHelper.search(sqltext, dataGridView1);
            
            SQLHelper.find(comboBox2, sqltext,dataGridView1);
            
            comboBox2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqltext;
            DialogResult r = MessageBox.Show("确定要删除吗？删除的数据不可恢复！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            try
            {
                if (r == DialogResult.Yes)
                {
                    sqltext = "delete from " + comboBox1.Text + " where " + dataGridView1.Columns[0].Name + " = " + comboBox2.Text;
                    MessageBox.Show(sqltext);
                    SQLHelper.cmd(sqltext).ExecuteNonQuery();
                    dataGridView1.Refresh();
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sql;
            sql = "select * from  " + comboBox1.SelectedItem.ToString() + " where " + dataGridView1.Columns[0].Name.ToString() + " like '%" + comboBox2.Text + "%'";
            SQLHelper.search(sql, dataGridView1);
        }
    }
}
