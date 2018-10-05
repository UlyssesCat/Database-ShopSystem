using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=shop;CharSet=gbk";



            MySqlConnection con = new MySqlConnection(str);//实例化链接
            con.Open();//开启连接


            DataSet ds = new DataSet();
            string strcmd = "select * from account";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
