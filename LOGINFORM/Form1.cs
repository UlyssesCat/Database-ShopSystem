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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
           
            //skinEngine1.SkinFile = Application.StartupPath + @"\mp10.ssk";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountId = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string str = "Server=localhost;User ID=root;Password=19981025;Database=project;CharSet=gbk";

            int fla = 0;

            if(accountId==""|| password=="")
            {
                MessageBox.Show("ID or password can't be empty");
                fla = 1;
                textBox1.Text = "";
                textBox2.Text = "";
            }


            if(fla==0)
                { 
                MySqlConnection con = new MySqlConnection(str);
                con.Open();


                DataSet ds = new DataSet("user");
                string strcmd = "select * from user";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                ada.Fill(ds);//查询结果填充数据集





                int flag = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (accountId == dr["user_id"].ToString() && password == ds.Tables[0].Rows[i]["passward"].ToString())
                    {
                        flag = 1;
                        if ("boss" == ds.Tables[0].Rows[i]["user_type"].ToString())
                        {
                            textBox1.Text = "";
                            textBox2.Text = "";
                            //test f6 = new test();
                            //f6.Show(this);
                            Form6 f6 = new Form6();
                            f6.Show(this);
                            this.Hide();
                            break;
                        }

                        if ("member" == ds.Tables[0].Rows[i]["user_type"].ToString())
                        {
                            //Form3 f3 = new Form3();
                            //f3.Show();
                            //this.Hide();
                            //break;
                        }

                        if ("salesperson" == ds.Tables[0].Rows[i]["user_type"].ToString())
                        {
                            textBox1.Text = "";
                            textBox2.Text = "";
                            Form3 f3 = new Form3();
                            f3.Show(this);
                            this.Hide();
                            break;
                        }

                        if ("warehousekeeper" == ds.Tables[0].Rows[i]["user_type"].ToString())
                        {
                            textBox1.Text = "";
                            textBox2.Text = "";
                            Form2 f2 = new Form2();
                            f2.Show(this);
                            this.Hide();
                            break;
                        }
                    }
                }
                if(flag==0)
                {
                    MessageBox.Show("password is wrong");
                    textBox2.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"^[0-9]*$"))
            {
                textBox1.Text = "";
                MessageBox.Show("only input numbers");
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
