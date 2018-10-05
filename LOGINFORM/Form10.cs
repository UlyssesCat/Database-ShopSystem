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
    public partial class Form10 : Form
    {
        int id;
        public Form10()
        {
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
            InitializeComponent();
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd1 = "select max(product_id) from product;";
            MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            id++;
            label7.Text = id.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox1.Text, out oldf);

                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();

            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                string strcmd = "INSERT INTO `product` (`Product_id`, `product_name`, `cost_price`, `description`, `product_type`, `sale_price`) VALUES ('" + label7.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox5.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "');";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("Succeeded add a product!");
                id++;
                label7.Text = id.ToString();
            }
            else
            {
                MessageBox.Show("Please fullfill the information!");
            }
           
            con.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
