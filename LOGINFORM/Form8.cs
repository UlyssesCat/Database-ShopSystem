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

namespace LOGINFORM
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            comboBox2.Text = "all";
            comboBox2.SelectedIndex = 0;
            comboBox1.Text = "all";
            comboBox1.SelectedIndex = 0;
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
        }
 

        private void Form8_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);//Instantiation link
            con.Open();//Open collection
            //Show warehouse information
            DataSet ds1 = new DataSet();
            string strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id order by s1.Product_id";
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            ada1.Fill(ds1);//Query results populate the data set
            dataGridView1.DataSource = ds1.Tables[0];
            //Show warehouse information
            DataSet ds2 = new DataSet();
            string strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type,w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
            MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
            MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd2);
            ada2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            con.Close();//Close collection
        }
       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            comboBox1.Text = "all";
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id order by s1.Product_id";
            string strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
            //Select according to conditions
            if (!textBox4.Text.Equals(""))
            {
                strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id where s1.Product_id = \'" + textBox4.Text + "\' order by s1.Product_id";
                strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where w1.product_id=\'" + textBox4.Text + "\' order by w1.Product_id";
            }
            else if (!textBox5.Text.Equals(""))
            {
                if (comboBox2.Text.Equals("all"))
                {
                    strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id where s1.quantity= \'" + textBox5.Text + "\' order by s1.Product_id";
                    strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where w1.quantity=\'" + textBox5.Text + "\' order by w1.Product_id";
                }
                else
                {
                    strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id  where s1.quantity= \'" + textBox5.Text + "\'  and p1.product_type= \'" + comboBox2.Text + "\' order by s1.Product_id";
                    strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_type =\'" + comboBox2.Text + "\' and w1.quantity=\'" + textBox5.Text + "\' order by w1.Product_id";
                }
            }
            else if (textBox5.Text.Equals(""))
            {
                if (comboBox2.Text.Equals("all"))
                {
                    strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id order by s1.Product_id";
                    strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
                }
                else
                {
                    strcmd1 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id where p1.product_type= \'" + comboBox2.Text + "\' order by s1.Product_id";
                    strcmd2 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_type =\'" + comboBox2.Text + "\' order by w1.Product_id";
                }
            }
            //Show shelf information
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            ada1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
        
            //Show warehouse information
            MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
            MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd2);
            ada2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();

            //Check if this product_id exists in warehouse
            MySqlCommand cmd = new MySqlCommand("select Product_id from warehouse where Product_id=\'" + textBox1.Text + "\'", con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd);
            MySqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Close();
                //Get the quantity of the product on the warehouse
                String strcmd7 = "select quantity from warehouse where Product_id=\'" + textBox1.Text + "\'";
                MySqlCommand cmd7 = new MySqlCommand(strcmd7, con);
                MySqlDataAdapter ada7 = new MySqlDataAdapter(cmd7);
                DataSet ds7 = new DataSet();
                ada7.Fill(ds7);
                string val2 = ds7.Tables[0].Rows[0]["quantity"].ToString();
                //Check if this product_id exists in shelf
                string strcmd1 = "select Product_id from shelf where Product_id=\'" + textBox1.Text + "\'";
                MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd1);
                MySqlDataReader dr2 = cmd1.ExecuteReader();
                string result1 = "";
                string result2 = "";
                string result3 = "";
                if (dr2.HasRows)
                {
                    dr2.Close();
                    //Get the quantity of the product on the shelf
                    String strcmd8 = "select quantity from shelf where Product_id=\'" + textBox1.Text + "\'";
                    MySqlCommand cmd8 = new MySqlCommand(strcmd8, con);
                    MySqlDataAdapter ada8 = new MySqlDataAdapter(cmd8);
                    DataSet ds8 = new DataSet();
                    ada8.Fill(ds8);
                    string val1 = ds8.Tables[0].Rows[0]["quantity"].ToString();
                    //Send product from warehouse to shelf if shelf has this product
                    if (int.Parse(val2) - int.Parse(textBox2.Text) >= 0)
                    {
                        
                        result1 = (int.Parse(val2) - int.Parse(textBox2.Text)).ToString();
                        string strcmd2 = "update warehouse set quantity = \'" + result1 + "\' where Product_id=\'" + textBox1.Text + "\'";
                        MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
                        cmd2.ExecuteNonQuery();
                        

                        result2 = (int.Parse(val1) + int.Parse(textBox2.Text)).ToString();
                        string strcmd3 = "update shelf set quantity = \'" + result2 + "\' where Product_id=\'" + textBox1.Text + "\'";
                        MySqlCommand cmd3 = new MySqlCommand(strcmd3, con);
                        cmd3.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("there is no enough product in the warehouse!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
                //Send product from warehouse to shelf if shelf does not have this product
                else
                {
                    dr2.Close();
                    String strcmd11 = "select shelf_id from shelf where shelf_id=1";
                    MySqlCommand cmd11 = new MySqlCommand(strcmd11, con);
                    MySqlDataAdapter ada11 = new MySqlDataAdapter(cmd11);
                    MySqlDataReader dr3 = cmd11.ExecuteReader();
                    if (dr3.HasRows)
                    {
                        dr3.Close();
                        //Get the largest id of shelf
                        String strcmd9 = "select MAX(shelf_id) from shelf";
                        MySqlCommand cmd9 = new MySqlCommand(strcmd9, con);
                        MySqlDataAdapter ada9 = new MySqlDataAdapter(cmd9);
                        DataSet ds9 = new DataSet();
                        ada9.Fill(ds9);
                        string val3 = ds9.Tables[0].Rows[0]["MAX(shelf_id)"].ToString();

                        //Get the largest column of shelf with largest shelf id
                        String strcmd10 = "select MAX(s1.column) from shelf s1 where s1.shelf_id = (select MAX(s2.shelf_id) from shelf s2)";
                        MySqlCommand cmd10 = new MySqlCommand(strcmd10, con);
                        MySqlDataAdapter ada10 = new MySqlDataAdapter(cmd10);
                        DataSet ds10 = new DataSet();
                        ada10.Fill(ds10);
                        string val4 = ds10.Tables[0].Rows[0]["MAX(s1.column)"].ToString();
                        if (int.Parse(val2) - int.Parse(textBox2.Text) >= 0)
                        {
                            result3 = (int.Parse(val2) - int.Parse(textBox2.Text)).ToString();
                            string strcmd2 = "update warehouse set quantity = \'" + result3 + "\' where Product_id=\'" + textBox1.Text + "\'";
                            MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
                            cmd2.ExecuteNonQuery();
                            string strcmd4 = "";
                            if (int.Parse(val4) == 9)
                            {
                                int newid = int.Parse(val3) + 1;
                                strcmd4 = "insert into shelf (Product_id , quantity, shelf_id, shelf.column) values (\'" + textBox1.Text + "\',\'" + textBox2.Text + "\',\'" + newid.ToString() + "\',\'" + 1 + "\')";
                            }
                            else
                            {
                                int newcolumn = int.Parse(val4) + 1;
                                strcmd4 = "insert into shelf (Product_id , quantity, shelf_id, shelf.column) values (\'" + textBox1.Text + "\',\'" + textBox2.Text + "\',\'" + val3 + "\',\'" + newcolumn.ToString() + "\')";
                            }
                            MySqlCommand cmd4 = new MySqlCommand(strcmd4, con);
                            cmd4.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("there is no enough product in the warehouse!");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                    }
                    else
                    {
                        dr3.Close();
                        string strcmd12 = "insert into shelf(Product_id, quantity, shelf_id, shelf.column) values(\'" + textBox1.Text + "\',\'" + textBox2.Text + "\',\'" + 1+ "\',\'" + 1 + "\')";
                        MySqlCommand cmd12 = new MySqlCommand(strcmd12, con);
                        cmd12.ExecuteNonQuery();
                    }
                }
                dr2.Close();
                textBox1.Text = "";
                textBox2.Text = "";
            }
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
            string strcmd5 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type,w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id order by w1.Product_id";
            MySqlCommand cmd5 = new MySqlCommand(strcmd5, con);
            MySqlDataAdapter ada5 = new MySqlDataAdapter(cmd5);
            ada5.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            DataSet ds3 = new DataSet();
            string strcmd6 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id order by s1.Product_id";
            MySqlCommand cmd6 = new MySqlCommand(strcmd6, con);
            MySqlDataAdapter ada6 = new MySqlDataAdapter(cmd6);
            ada6.Fill(ds3);
            dataGridView1.DataSource = ds3.Tables[0];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            comboBox1.Text = "all";
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            if (!textBox7.Text.Equals(""))
            {
                if (comboBox2.Text.Equals("all"))
                {

                    string strcmd1 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_name like \'%" + textBox7.Text + "%\' or p1.description like \'% " + textBox7.Text + "%\'";
                    string strcmd2 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id where p1.product_name like \'%" + textBox7.Text + "%\' or p1.description like \'% " + textBox7.Text + "%\'";
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
                    string strcmd3 = "select p1.Product_id,p1.product_name,p1.cost_price,p1.description,p1.product_type, w1.quantity  from warehouse w1 join product p1 on w1.Product_id = p1.Product_id where p1.product_name like \'%" + textBox7.Text + "%\' or p1.description like \'% " + textBox7.Text + "%\'and product_type=\'" + comboBox2.Text + "\'";
                    string strcmd4 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity  from shelf s1 join product p1 on s1.Product_id = p1.Product_id where p1.product_name like \'%" + textBox7.Text + "%\' or p1.description like \'% " + textBox7.Text + "%\' and product_type=\'" + comboBox2.Text + "\'";
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
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            MySqlCommand cmd1 = new MySqlCommand("select shelf_id from shelf where shelf_id=\'" + textBox3.Text + "\'", con);
            MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
            MySqlDataReader dr1 = cmd1.ExecuteReader();
            if (!textBox3.Text.Equals(""))
            {
               if(dr1.HasRows)
                {
                    dr1.Close();
                    if (comboBox1.Text.Equals("all"))
                    {
                        string strcmd2 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity from shelf s1 join product p1 on s1.Product_id = p1.Product_id where s1.shelf_id = \'" + textBox3.Text + "\' ";
                        MySqlCommand cmd2 = new MySqlCommand(strcmd2, con);
                        MySqlDataAdapter ada2 = new MySqlDataAdapter(cmd2);
                        ada2.Fill(ds1);
                        dataGridView1.DataSource = ds1.Tables[0];
                    }
                    else
                    {
                        string strcmd3 = "select s1.Product_id,p1.product_name,p1.sale_price,p1.description,p1.product_type,s1.shelf_id,s1.column,s1.quantity from shelf s1 join product p1 on s1.Product_id = p1.Product_id where s1.shelf_id = \'" + textBox3.Text + "\' and s1.column=\'"+comboBox1.Text+"\'";
                        MySqlCommand cmd3 = new MySqlCommand(strcmd3, con);
                        MySqlDataAdapter ada3 = new MySqlDataAdapter(cmd3);
                        ada3.Fill(ds2);
                        dataGridView1.DataSource = ds2.Tables[0];
                    }
                }
               else
                {
                    dr1.Close();
                    MessageBox.Show("There is no that shelf!");
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please input Shelf ID!");
                textBox3.Text = "";
            }
            con.Close();
        }
    }
}
