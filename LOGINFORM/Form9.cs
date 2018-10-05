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
    public partial class Form9 : Form
    {
        public Form9()
        {
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
            InitializeComponent();
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "select * from user;";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;
            con.Close();
        }
      
        private void Form9_Load(object sender, EventArgs e) {


            this.MaximizeBox = false;
            comboBox1.Text = "salesperson";
            comboBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"^[0-9]*$"))
            {
                textBox1.Text = "";
                MessageBox.Show("输入数字");
            }
        }

        public bool accountIfExist = false;
        public bool accountIfExist1 = false;

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text.ToString(), @"^[0-9]*$"))
            {
                textBox4.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string str = "Server=localhost;User ID=root;Password=980112sky;Database=project;CharSet=gbk";
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();

             
            string id = textBox4.Text;
            string type = comboBox2.Text;

            string strcmd0 = "select * from user;"; 
            if (id != "" && type != "all" && type != "")
            {
                strcmd0 = "select * from user where user_id = " + id + " and user_type = '" + type + "';";
                MySqlCommand cmd0 = new MySqlCommand(strcmd0, con);
                MySqlDataReader mysqldr0 = cmd0.ExecuteReader();
                if (mysqldr0.HasRows)
                {
                    mysqldr0.Close();
                    accountIfExist1 = true;
                }
                else
                {
                    mysqldr0.Close();
                    accountIfExist1 = false;
                }
            }
            else if(id == "" && (type != "all" && type != ""))
            {
                accountIfExist1 = true;
                strcmd0 = "select * from user where user_type = '" + type + "';";
            }
            else if (id != "" && (type == "all" || type == ""))
            {
                strcmd0 = "select * from user where user_id = " + id + ";";
                MySqlCommand cmd0 = new MySqlCommand(strcmd0, con);
                MySqlDataReader mysqldr0 = cmd0.ExecuteReader();
                if (mysqldr0.HasRows)
                {
                    mysqldr0.Close();
                    accountIfExist1 = true;
                }
                else
                {
                    mysqldr0.Close();
                    accountIfExist1 = false;
                }
            }
            else
            {
                accountIfExist1 = true;
                strcmd0 = "select * from user;";
            }

            if (accountIfExist1)
            {
                MySqlCommand cmd = new MySqlCommand(strcmd0, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.ReadOnly = true;
                con.Close();
            }
            else
            {
                MessageBox.Show("Not exist!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form9_SizeChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text.ToString(), @"^[0-9]*$"))
            {
                textBox5.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.ToString(), @"^[0-9]*$"))
            {
                textBox3.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"^[0-9]*$"))
            {
                textBox1.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string accountId = textBox1.Text.Trim();
            string accountName = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();
            string accontType = comboBox1.Text.Trim();
            //string str = "Server=localhost;User ID=root;Password=980112sky;Database=project;CharSet=gbk";
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";

            MySqlConnection con = new MySqlConnection(str);
            con.Open();




            string strcmd0 = "";
            if (accountId != "")
            {
                strcmd0 = "select user_id from user where user_type != 'member' and user_id = " + accountId + ";";
                MySqlCommand cmd0 = new MySqlCommand(strcmd0, con);
                MySqlDataReader mysqldr0 = cmd0.ExecuteReader();
                if (mysqldr0.HasRows)
                {
                    mysqldr0.Close();
                    accountIfExist = true;
                }
                else
                {
                    mysqldr0.Close();
                    accountIfExist = false;
                }
            }
            else
            {
                accountIfExist = true;
            }

            if (accountIfExist)
            { MessageBox.Show("This account has already existed, please enter another ID."); }
            else
            {
                MessageBox.Show("Successfully create a new account!");
                foreach (Control Ctrol in this.Controls)
                {
                    if (Ctrol is TextBox) Ctrol.Text = "";
                }
                string strcmd = "INSERT INTO `project`.`user` (`user_id`, `user_type`, `user_name`, `passward`) VALUES (" + accountId + ", '" + accontType + "', '" + accountName + "', '" + password + "');";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();

                string stt = "select * from user;";
                MySqlCommand cm = new MySqlCommand(stt, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cm);
                DataSet ds = new DataSet();
                ada.Fill(ds);//查询结果填充数据集
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.ReadOnly = true;

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();


            string ids = textBox5.Text;

            MySqlCommand cmd = new MySqlCommand("select user_id from user where user_id=\'" + textBox5.Text + "\'", con);
            MySqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Close();
                MySqlCommand cmd1 = new MySqlCommand("select user_type from user where user_id=\'" + textBox5.Text + "\'", con);
                MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                ada2.Fill(ds1);
                string val = ds1.Tables[0].Rows[0]["user_type"].ToString();

                if (val == "boss" || val == "member")
                {
                    MessageBox.Show("no permission");
                    textBox5.Text = "";
                }
                else
                {
                    string strcmd0 = "delete from user where user_id=" + ids + ";";
                    MySqlCommand cmd0 = new MySqlCommand(strcmd0, con);
                    cmd0.ExecuteNonQuery();
                    textBox5.Text = "";
                }


            }
            else
            {
                dr1.Close();
                MessageBox.Show("not found");
                textBox5.Text = "";
            }




            string stt = "select * from user;";
            MySqlCommand cm = new MySqlCommand(stt, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cm);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void skinEngine1_CurrentSkinChanged(object sender, Sunisoft.IrisSkin.SkinChangedEventArgs e)
        {

        }
    }
}
