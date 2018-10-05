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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public int itemHeight = 10;
        public double totalCost = 0;
        public double totalCost0 = 0;
        public bool VIPIfExist = false;
        ArrayList myArr= new ArrayList();

        DateTime today = DateTime.Now;
        string today_date = "";
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text.ToString(), @"^[0-9]*$"))
            {
                textBox2.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("exit?", "hint:", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)   //如果单击“是”按钮
            {
                Form1 f1 = new Form1();
                f1 = (Form1)this.Owner;
                f1.Show();
                e.Cancel = false;                 //关闭窗体
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;                  //不执行操作
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text.ToString(), @"^[0-9]*$"))
            {
                textBox3.Text = "";
                MessageBox.Show("please input numbers");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "";

            string id = textBox2.Text;
            string quantity = textBox3.Text;
            if (id!="" && quantity!="")
            {
                strcmd = "select Product_id from shelf where Product_id = " + id + ";";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataReader mysqldr = cmd.ExecuteReader();
                if (mysqldr.HasRows)
                {
                    mysqldr.Close();
                    strcmd = "select Product_id,product_name,sale_price,description from product where Product_id = " + id + ";";
                    cmd = new MySqlCommand(strcmd, con);
                    MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);//查询结果填充数据集
                    
                    double totalpriceofoneproduct = (Convert.ToDouble(ds.Tables[0].Rows[0]["sale_price"].ToString())) * (Convert.ToInt32(quantity));

                    orderItem newOrderItem = new orderItem();
                    newOrderItem.Location = new Point(10, itemHeight);
                    newOrderItem.ID = id;
                    newOrderItem.name = ds.Tables[0].Rows[0]["product_name"].ToString();
                    newOrderItem.money = totalpriceofoneproduct.ToString();
                    newOrderItem.description = ds.Tables[0].Rows[0]["description"].ToString();
                    newOrderItem.quantity = quantity;
                    panel1.Controls.Add(newOrderItem);

                    myArr.Add(newOrderItem);

                    itemHeight += 40;

                    con.Close();
                }
                else
                {
                    MessageBox.Show("There is no such product with this id in shelf now!");
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }else
            {
                MessageBox.Show("Both ID and quantity are required!");
            }
            textBox2.Text = "";
            textBox3.Text = "";
         
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
     
        private void button3_Click(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";
           
            MySqlConnection con = new MySqlConnection(str);
            con.Open();
            string strcmd = "";

            string strcmd0 = "";

            string VIPid = textBox1.Text;
            if (VIPid != "")
            {
                strcmd0 = "select user_id from user where user_type = 'member' and user_id = " + VIPid + ";";
                MySqlCommand cmd0 = new MySqlCommand(strcmd0, con);
                MySqlDataReader mysqldr0 = cmd0.ExecuteReader();
                if (mysqldr0.HasRows)
                {
                    mysqldr0.Close();
                    VIPIfExist = true;
                }else
                {
                    mysqldr0.Close();
                    VIPIfExist = false;
                }
            }
            else{
                VIPIfExist = true;
            }

            if (VIPIfExist)
            {
                MessageBox.Show("Order completed with cost : " + totalCost0);

                for (int i = 0; i < myArr.Count; i++)
                {
                    orderItem o = myArr[i] as orderItem;
                    strcmd += "UPDATE shelf SET quantity=quantity - " + o.quantity + " WHERE Product_id=" + o.ID + ";";
                    if (VIPid != "")
                    {
                        strcmd += "INSERT INTO `salerecord` (`product_id`, `quantity`, `Sale_date`, `user_id`) VALUES ('" + o.ID + "', '" + o.quantity + "', '" + today_date + "', '" + VIPid + "');";
                    }else
                    {
                        strcmd += "INSERT INTO `salerecord` (`product_id`, `quantity`, `Sale_date`) VALUES ('" + o.ID + "', '" + o.quantity + "', '" + today_date + "');";
                    }
                }
                strcmd += "INSERT INTO assets (`change_date`, `changeofmoney`) VALUES ('" + today_date + "', '" + totalCost0.ToString() + "');";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();
                con.Close();

                myArr.Clear();

                totalCost = 0;
                textBox1.Text = "";
                this.label4.Text = "0￥";
                this.panel1.Controls.Clear();
            }else
            {
                DialogResult result = MessageBox.Show("VIP not exist! Do you want to create a new VIP with this id ?", "Sorry", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string strcmd1 = "INSERT INTO `user` (`user_id`, `user_type`, `user_name`, `passward`) VALUES ('"+VIPid+ "', 'member', 'admin', '" + VIPid + "');";
                    MySqlCommand cmd = new MySqlCommand(strcmd1, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("VIP created! Please click OK again to complete the order!");
                }
                else
                {
                    textBox1.Text = "";
                }
            }
            itemHeight = 10;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            today_date = today.ToString("yyyy-MM-dd");
            totalCost = 0;
            for (int i = 0; i < myArr.Count; i++)
            {
                orderItem o = myArr[i] as orderItem;
                totalCost += Convert.ToDouble(o.money);
            }
            totalCost0 = totalCost;
            this.label4.Text = totalCost.ToString() + "￥";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
