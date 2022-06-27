using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Login : Form
    {
        public static string userName;
        int f = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("Admin.txt");

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Something empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    string[] temp = line.Split(',');
                    if (temp[0] == textBox1.Text && temp[1] == textBox2.Text)
                    {
                        SR.Close();
                        this.Hide();
                        Market MarketForm = new Market();
                        MarketForm.textBox1.Visible = true;
                        MarketForm.textBox2.Visible = true;
                        MarketForm.textBox3.Visible = true;
                        MarketForm.label1.Visible = true;
                        MarketForm.label2.Visible = true;
                        MarketForm.label3.Visible = true;
                        MarketForm.button1.Visible = true;
                        MarketForm.button2.Visible = true;
                        MarketForm.button4.Visible = false;
                        MarketForm.button5.Visible = false;
                        MarketForm.label5.Visible = false;
                        userName = textBox1.Text;
                        MarketForm.Height = 1093;
                        MarketForm.ShowDialog();
                        this.Close();
                        f = 1;
                        break;
                    }

                }

                if (f == 0)
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader SR2 = new StreamReader("User.txt");

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Something empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                while (!SR2.EndOfStream)
                {
                    string line = SR2.ReadLine();
                    string[] temp = line.Split(',');
                    if (temp[0] == textBox1.Text && temp[1] == textBox2.Text)
                    {
                        SR2.Close();
                        this.Hide();
                        Market MarketForm = new Market();
                        MarketForm.textBox1.Visible = false;
                        MarketForm.textBox2.Visible = false;
                        MarketForm.textBox3.Visible = false;
                        MarketForm.label1.Visible = false;
                        MarketForm.label2.Visible = false;
                        MarketForm.label3.Visible = false;
                        MarketForm.button1.Visible = false;
                        MarketForm.button2.Visible = false;
                        MarketForm.button4.Visible = true;
                        MarketForm.button5.Visible = true;
                        MarketForm.label5.Visible = true;
                        userName = textBox1.Text;
                        MarketForm.Height = 829;
                        MarketForm.ShowDialog();
                        this.Close();
                        f = 1;
                        break;
                    }

                }

                if (f == 0)
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
