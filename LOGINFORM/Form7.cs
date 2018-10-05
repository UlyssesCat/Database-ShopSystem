using MySql.Data.MySqlClient;
using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Checked = false;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Checked = false;
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            //string str = "Server=localhost;User ID=root;Password=19990204ljjljj;Database=supermarket;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "select * from assets;";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;
            string strcmd1 = "select sum(changeofmoney) as totalAsset from assets;";
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            ada1.Fill(ds1);//查询结果填充数据集
            string totalAsset = ds1.Tables[0].Rows[0][0].ToString();
            label2.Text = totalAsset + "￥";
            con.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
          
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            string strcmd = "select * from assets;";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            bool d1 = false, d2 = false;
            string date1 = "", date2 = "";
            d1 = (dateTimePicker1.Checked);
            d2 = (dateTimePicker2.Checked);
            if ((!d1 && d2) || (d1 && !d2) || (dateTimePicker1.Value > dateTimePicker2.Value))
            {//wrong time format
                MessageBox.Show("Wrong date format!");
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;
            }else if (d1 && d2)
            {
                date1 = dateTimePicker1.Text;
                date2 = dateTimePicker2.Text;
                strcmd = "select * from assets where change_date >= '" + date1 + "' and change_date <= '" + date2 + "';"; 
            }
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;

            string strcmd1 = "select sum(changeofmoney) as totalAsset from assets where change_date >= '" + date1 + "' and change_date <= '" + date2 + "';";
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            ada1.Fill(ds1);//查询结果填充数据集
            string totalAsset = ds1.Tables[0].Rows[0][0].ToString();
            label6.Text = totalAsset + "￥";

            con.Close();
        }

        private void Form7_SizeChanged(object sender, EventArgs e)
        {
      
        }
    }
}
