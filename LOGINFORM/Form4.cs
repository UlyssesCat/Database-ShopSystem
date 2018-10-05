using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGINFORM
{
    public partial class Form4 : Form
    {


        public Form4()
        {
            InitializeComponent();

        }
        
        DataTable dt = new DataTable();

     
        private void Form4_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
           
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Checked = false;
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "select stock_id,quantity,stockrecord.Product_id,product.product_name,stock_time from stockrecord,product where product.product_id=stockrecord.product_id;";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集



            dt = ds.Tables[0];
            this.dataGridView1.DataSource = dt;


            dataGridView1.ReadOnly = true;
            con.Close();
        }
        
       

        private void button2_Click(object sender, EventArgs e)
        {
            string strcmd = "select stock_id,quantity,stockrecord.Product_id,product.product_name,stock_time from stockrecord,product where product.product_id=stockrecord.product_id;";

            string id = textBox1.Text;
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            if (textBox1.Text!="")
            {
               
                if (this.dateTimePicker1.Checked != false)
                {
                    string date = dateTimePicker1.Text;
                    strcmd = "select stock_id,quantity,stockrecord.Product_id,product.product_name,stock_time from stockrecord,product where product.product_id=stockrecord.product_id and stockrecord.Product_id = " + id + " and stock_time = '"+date+"';";

                }else
                {
                    strcmd = "select stock_id,quantity,stockrecord.Product_id,product.product_name,stock_time from stockrecord,product where product.product_id=stockrecord.product_id and stockrecord.Product_id = " + id + ";";
    
                }
            }else
            {
                if (this.dateTimePicker1.Checked != false)
                {
                    string date = dateTimePicker1.Text;
                    strcmd = "select stock_id,quantity,stockrecord.Product_id,product.product_name,stock_time from stockrecord,product where product.product_id=stockrecord.product_id and stock_time = '" + date + "';";
                   
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"^[0-9]*$"))
            {
                textBox1.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dataGridView1);
        }

        private void Form4_SizeChanged(object sender, EventArgs e)
        {
         

        }

    }
}
