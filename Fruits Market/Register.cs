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
    public partial class Register : Form
    {
        int f = 1;
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox2.Text == textBox3.Text)
            {

                StreamReader SR = new StreamReader("User.txt");
                while (!SR.EndOfStream)
                {
                    string line = SR.ReadLine();
                    string[] temp = line.Split(',');
                    if (temp[0] == textBox1.Text)
                    {
                        f = 0;
                        break;
                    }

                }
                SR.Close();
                if (f == 1)
                {
                    StreamWriter SW = new StreamWriter("User.txt", true);
                    string username = textBox1.Text;
                    string pass = textBox2.Text;
                    SW.WriteLine(username + "," + pass);
                    SW.Close();
                    MessageBox.Show("Your Account has been Successfuly Created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login LogForm = new Login();
                    LogForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This Username is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    f = 1;
                }
            }
            else
            {
                MessageBox.Show(" Something not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                button1.Visible = true;
                button2.Width = 391;
                button2.Location = new Point(349, 642);
            }
            else
            {
                button1.Visible = false;
                button2.Width = 698;
                button2.Location = new Point(42, 642);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form = new Form1();
            Form.ShowDialog();
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
