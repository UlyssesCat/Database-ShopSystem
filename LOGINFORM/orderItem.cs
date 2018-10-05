using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGINFORM
{
    public partial class orderItem : UserControl
    {
        public orderItem()
        {
            InitializeComponent();
        }
        public string ID,name,quantity,money,description;

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label7.Text = "╳";
            this.label2.Text = "0";
            money = "0";
            quantity = "0";
            this.label3.Text = "0";
            Controls.Remove(button1);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.label1.Text = ID;
            this.label2.Text = quantity;
            this.label3.Text = money;
            this.label6.Text = description;
            this.label5.Text = name;

        }
    }
}
