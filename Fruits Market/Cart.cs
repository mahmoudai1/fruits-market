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
    public partial class Cart : Form
    {
        
        int total;
        int saveIndex;
        int saveIndex2;
        int f = 0;
        int f2 = 0;
        bool finished = false;
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            if (Market.index2> 0)
            {
                
                InsertinListBox();
                ChangeInterface();
                label1.Text = "You Cart";
                listBox1.SelectedIndex = 0;
            }
            else
            {
                label1.Text = "You Cart is empty";
                label3.Text = "";
                label2.Text = "";
            }
        }

        void InsertinListBox()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < Market.index2; i++)
            {
                listBox1.Items.Insert(i, Market.L2[i].name + " * " + Market.L2[i].qty + "  " + Market.L2[i].price + "$");
            }
            
        }

        void ChangeInterface()
        {
            try
            {
                this.BackColor = Color.FromName(Market.L2[0].color);
                pictureBox1.Image = Image.FromFile(Market.L2[0].loc);
                label2.Text = Market.L2[0].name;
                for (int i = 0; i < Market.index2; i++)
                {
                    total += Market.L2[i].price * Market.L2[i].qty;
                }
                label3.Text = "Total= " + total;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    this.BackColor = Color.FromName(Market.L2[listBox1.SelectedIndex].color);
                    pictureBox1.Image = Image.FromFile(Market.L2[listBox1.SelectedIndex].loc);
                    label2.Text = Market.L2[listBox1.SelectedIndex].name;
                }
            }
            else
            {
                //MessageBox.Show("Your cart becomes empty, please put anything in the cart and come back :)", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //this.Close();

                this.BackColor = Color.WhiteSmoke;
                pictureBox1.Image = null;
                label2.Text = "";
                total = 0;
                label3.Text = "";
                label1.Text = "You Cart is empty";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                f = 0;
                saveIndex = listBox1.SelectedIndex;

                Market.L2[listBox1.SelectedIndex].qty--;
               
                if (Market.L2[listBox1.SelectedIndex].qty == 0)
                {
                    if (listBox1.Items.Count > 1)
                    {
                        saveIndex2 = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        Market.L2.RemoveAt(saveIndex2);
                        Market.index2--;
                        saveIndex = 0;

                        f = 1;
                    }
                    else
                    {
                        saveIndex2 = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        Market.L2.RemoveAt(saveIndex2);
                        listBox1.Items.Clear();
                        Market.index2--;
                        finished = true;
                    }
                }
                else
                {
                    listBox1.Items.Clear();
                    f = 0;
                }

                if (!finished)
                {
                    total = 0;
                    InsertinListBox();
                    ChangeInterface();

                    if (f == 0)
                    {
                        listBox1.SelectedIndex = saveIndex;
                    }
                    else
                    {
                        if (listBox1.Items.Count > 0)
                        {
                            listBox1.SelectedIndex = 0;
                        }

                    }
                }

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
