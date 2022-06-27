using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = " Final Lab Task - Mahmoud Ahmed Ibrahim - 191583";
        }

        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login LogForm = new Login();
            LogForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register RegForm = new Register();
            RegForm.ShowDialog();
            this.Close();
        }
    }
}


