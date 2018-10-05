using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGINFORM
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void test_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "";
            strcmd = "select * from product ;";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;
            con.Close();
        }
    }
}
