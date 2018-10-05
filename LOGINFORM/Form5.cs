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
    public partial class Form5 : Form
    {

   


        public Form5()
        {
            InitializeComponent();
         
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
           
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Checked = false;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.Checked = false;
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "select * from salerecord;";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            string strcmd = "select * from salerecord;";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();

            bool d1 = false, d2 = false, t1 = false, t2 = false;
            string date1 = "", date2 = "";
            d1 = (dateTimePicker1.Checked);
            d2 = (dateTimePicker2.Checked);
            t1 = (textBox1.Text == "");
            t2 = (textBox3.Text == "");
            if ((!d1 && d2) || (d1 && !d2) || (dateTimePicker1.Value > dateTimePicker2.Value))
            {//wrong time format
                MessageBox.Show("Wrong date format!");
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;
            }
            else if (d1 && d2)
            {
                date1 = dateTimePicker1.Text;
                date2 = dateTimePicker2.Text;
                if (t1 && t2)
                {
                    strcmd = "select * from salerecord where Sale_date<= '" + date2 + "' and Sale_date>= '" + date1 + "';";
                }
                else if (!t1 && t2)
                {
                    strcmd = "select * from salerecord where product_id= " + textBox1.Text + " and Sale_date<= '" + date2 + "' and Sale_date>= '" + date1 + "';";
                }
                else if (t1 && !t2)
                {
                    strcmd = "select * from salerecord where user_id= " + textBox3.Text + " and Sale_date<= '" + date2 + "' and Sale_date>= '" + date1 + "';";
                }
                else
                {
                    strcmd = "select * from salerecord where product_id= " + textBox1.Text + " and user_id= " + textBox3.Text + " and Sale_date<= '" + date2 + "' and Sale_date>= '" + date1 + "';";
                }
            }
            else
            {
                if (t1 && t2)
                {
                    strcmd = "select * from salerecord;";
                }
                else if (!t1 && t2)
                {
                    strcmd = "select * from salerecord where product_id= " + textBox1.Text + ";";
                }
                else if (t1 && !t2)
                {
                    strcmd = "select * from salerecord where user_id= " + textBox3.Text + ";";
                }
                else
                {
                    //strcmd = "select * from salerecord where product_id= " + textBox1.Text + " and user_id= " + textBox3.Text + ";";
                }
            }
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集

    

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;
            con.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"^[0-9]*$"))
            {
                textBox1.Text = "";
                MessageBox.Show("please input numbers");
               
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.ToString(), @"^[0-9]*$"))
            {
                textBox3.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dataGridView1);
        }

        private void Form5_SizeChanged(object sender, EventArgs e)
        {
          
         
        }
    }
}
