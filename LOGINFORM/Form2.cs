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
using System.Timers;

namespace LOGINFORM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox2.Text = "all";
            comboBox2.SelectedIndex = 0;
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open(); //Open collection
            //Show warehouse information
            DataSet ds1 = new DataSet();
            string strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type,w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            ada1.Fill(ds1);  //Query results populate the data set
            dataGridView1.DataSource = ds1.Tables[0];
            //Show product information
            DataSet ds2 = new DataSet();
            string strcmd2 = "select * from product order by Product_id";
            MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
            MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd2);
            ada2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            con.Close(); //Close collection
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit or not?", "Tip:", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)   //If click 'YES' button
            {
                Form1 f1 = new Form1();
                f1 = (Form1)this.Owner;
                f1.Show();
                //this.Parent.Visible = true;
                e.Cancel = false;                 //Close form
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;                  //No operation
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
            string strcmd2 = "select * from product order by Product_id";
            //Select according to conditions
            if (!textBox4.Text.Equals(""))
            {
                strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where w1.product_id=\'" + textBox4.Text + "\' order by w1.Product_id";
                strcmd2 = "select * from product  where Product_id= \'" + textBox4.Text + "\' order by Product_id";
            }
            else if (!textBox5.Text.Equals(""))
            {
                if (comboBox2.Text.Equals("all"))
                {
                    strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where w1.quantity=\'" + textBox5.Text + "\' order by w1.Product_id";
                    strcmd2 = "select * from product order by Product_id";
                }
                else
                {
                    strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_type =\'" + comboBox2.Text + "\' and w1.quantity=\'" + textBox5.Text + "\' order by w1.Product_id";
                    strcmd2 = "select * from product where product_type= \'"+ comboBox2.Text + "\'order by Product_id";
                }
            }
            else if (textBox5.Text.Equals(""))
            {
                if (comboBox2.Text.Equals("all"))
                {
                    strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
                    strcmd2 = "select * from product order by Product_id";
                }
                else
                {
                    strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_type =\'" + comboBox2.Text + "\' order by w1.Product_id";
                    strcmd2 = "select * from product where product_type= \'" + comboBox2.Text + "\'order by Product_id";
                }
            }
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            ada1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
            MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd2);
            ada2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            //Check if this product_id exists in product
            MySqlCommand cmd = new MySqlCommand("select Product_id from product where Product_id=\'" + textBox1.Text + "\'", con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd);
            MySqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Close();
                //get cost price of this product
                string strcmd6 = "select cost_price from product where Product_id =\'"+ textBox1.Text + "\'";
                DataSet ds6 = new DataSet();
                MySqlCommand cmd6 = new MySqlCommand(strcmd6,con);
                MySqlDataAdapter ada6 = new MySqlDataAdapter(cmd6);
                ada6.Fill(ds6);
                string cost_price = ds6.Tables[0].Rows[0]["cost_price"].ToString();
                //Check if this product_id exists in warehouse
                string strcmd1 = "select quantity from warehouse where Product_id=\'" + textBox1.Text + "\'";
                MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd1);
                MySqlDataReader dr2 = cmd1.ExecuteReader();
                string result = "";
                if (dr2.HasRows)
                {
                    dr2.Close();
                    //Get the quantity of the product on the warehouse
                    DataSet ds1 = new DataSet();
                    ada2.Fill(ds1);
                    string val = ds1.Tables[0].Rows[0]["quantity"].ToString();
                    //Purchase product from factory if warehouse has this product
                    result = (int.Parse(val) + int.Parse(textBox2.Text)).ToString();
                    string strcmd2 = "update warehouse set quantity = \'" + result + "\' where Product_id=\'" + textBox1.Text + "\'";
                    MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
                    cmd2.ExecuteNonQuery();
                   
                }
                else
                {
                    dr2.Close();
                    string strcmd3 = "insert into warehouse (Product_id , quantity) values (\'" + textBox1.Text + "\',\'" + textBox2.Text + "\')";
                    MySqlCommand cmd3 = new MySqlCommand(strcmd3, con);
                    cmd3.ExecuteNonQuery();
                }
                dr2.Close();
                string money = (0 - float.Parse(cost_price) * int.Parse(textBox2.Text)).ToString();
                DateTime now = DateTime.Now;
                string strcmd7 = "insert into assets (change_date,changeofmoney) values (\'" + now.Date.ToString("yyyy-MM-dd") + "\',\'" + money + "\')";
                string strcmd4 = "insert into stockrecord (Product_id,quantity,stock_time) values (\'" + textBox1.Text + "\',\'" + textBox2.Text +"\',"+"\'"+now.Date.ToString("yyyy-MM-dd")+"\' )";
                MySqlCommand cmd7 = new MySqlCommand(strcmd7, con);
                cmd7.ExecuteNonQuery();
                MySqlCommand cmd4 = new MySqlCommand(strcmd4, con);
                cmd4.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            //Purchase product from factory if warehouse does not  have this product
            else
            {
                dr1.Close();
                MessageBox.Show("there is no such product!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            dr1.Close();
            //Show new status after opoeration
            DataSet ds2 = new DataSet();
            string strcmd5 = "select p1.Product_id,p1.product_name,p1.cost_price, p1.description,p1.product_type,w1.quantity from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
            MySqlCommand cmd5 = new MySqlCommand(strcmd5, con);
            MySqlDataAdapter ada5 = new MySqlDataAdapter(cmd5);
            ada5.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];
            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            if (!textBox3.Text.Equals(""))
            {
                if (comboBox2.Text.Equals("all"))
                {

                    string strcmd1 = "select * from product  where product_name like \'%" + textBox3.Text + "%\' or description like \'%" + textBox3.Text + "%\'";
                    string strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_name like \'%" + textBox3.Text + "%\' or p1.description like \'% " + textBox3.Text + "%\'";

                    MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                    MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
                    ada1.Fill(ds1);
                    dataGridView2.DataSource = ds1.Tables[0];

                    MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
                    MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd2);
                    ada2.Fill(ds2);
                    dataGridView1.DataSource = ds2.Tables[0];
                }
                else
                {
                    string strcmd3 = "select * from product  where product_name like \'%" + textBox3.Text + "%\' or description like \'%" + textBox3.Text + "%\' and product_type=\'"+ comboBox2.Text+"\'";
                    string strcmd4 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_name like \'%" + textBox3.Text + "%\' or p1.description like \'% " + textBox3.Text + "%\'and product_type=\'" + comboBox2.Text + "\'";

                    MySqlCommand cmd3 = new MySqlCommand(strcmd3, con);
                    MySqlDataAdapter ada3 = new MySqlDataAdapter(cmd3);
                    ada3.Fill(ds1);
                    dataGridView2.DataSource = ds1.Tables[0];

                    MySqlCommand cmd4 = new MySqlCommand(strcmd4, con);
                    MySqlDataAdapter ada4 = new MySqlDataAdapter(cmd4);
                    ada4.Fill(ds2);
                    dataGridView1.DataSource = ds2.Tables[0];
                }
            }
            else
            {
                MessageBox.Show("Please input search condition!");
                string strcmd5 = "select * from product  ;";
                string strcmd6 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id ;";
                MySqlCommand cmd4 = new MySqlCommand(strcmd5, con);
                MySqlDataAdapter ada4 = new MySqlDataAdapter(cmd4);
                ada4.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0];

                MySqlCommand cmd5 = new MySqlCommand(strcmd6, con);
                MySqlDataAdapter ada5 = new MySqlDataAdapter(cmd5);
                ada4.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            try
            {
                DataSet ds1 = new DataSet();
                string strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type,w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
                MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
                ada1.Fill(ds1); 
                dataGridView1.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            System.Threading.Thread.Sleep(200);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Stop Fresh")
            {
                button6.Text = "Start Fresh";
                timer1.Enabled = false;
            }
            else
            {
                button6.Text = "Stop Fresh";
                timer1.Enabled = true;
            }
        }
    } 
}
  

