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
    public partial class Market : Form
    {
        int f = 0;
        int f2 = 0;
        public class Fruit1
        {
            public string name;
            public int price;
            public string loc;
            public string color;
            public int qtyShow;
        }

        public class Fruit2
        {
            public string name;
            public int price;
            public string loc;
            public string color;
            public int qty;
        }

        public static List<Fruit1> L1 = new List<Fruit1>();
        public static List<Fruit2> L2 = new List<Fruit2>();
        int index = 0;
        public static int index2 = 0;
        string picpath = null;
        bool ImageUploaded = false;

        public Market()
        {
            InitializeComponent();
        }

        private void Market_Load(object sender, EventArgs e)
        {
            L1.Clear();
            L2.Clear();
            label5.Visible = false;
            index2 = 0;
            label6.Text = "Welcome " + Login.userName;
            CreateFruits();
        }

        void CreateFruits()
        {
            StreamReader SR = new StreamReader("Fruits.txt");

            
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();
                string[] temp = line.Split(',');
                Fruit1 pnn = new Fruit1();
                pnn.name = temp[0];
                pnn.price = Int32.Parse(temp[1]);
                pnn.loc = temp[2];
                pnn.color = temp[3];
                L1.Add(pnn);
                f = 1;
            }
            SR.Close();
            if (f == 1)
            {
                ShowFruit();
            }
            if (f == 0)
            {
                MessageBox.Show("There is no fruit yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void ShowFruit()
        {
            try
            {
                this.BackColor = Color.FromName(L1[index].color);
            }
                pictureBox1.Image = Image.FromFile(L1[index].loc);
                fruitName.Text = L1[index].name;
                fruitPrice.Text = "" + L1[index].price;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (f == 1)
            {
                index++;
                if (index > L1.Count - 1)
                {
                    index = 0;
                }

                label5.Text = "" + L1[index].qtyShow;

                ShowFruit();
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (f == 1)
            {
                index--;
                if (index < 0)
                {
                    index = L1.Count - 1;
                }

                label5.Text = "" + L1[index].qtyShow;
                

                ShowFruit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                picpath = OFD.FileName;
                MessageBox.Show("" + picpath, "Picture Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label4.Visible = true;
                ImageUploaded = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ImageUploaded)
            {
                if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    StreamWriter SW = new StreamWriter("Fruits.txt", true);
                    Fruit1 pnn = new Fruit1();
                    pnn.name = textBox1.Text;
                    pnn.price = Int32.Parse(textBox2.Text);
                    pnn.loc = picpath;
                    pnn.color = textBox3.Text;
                    
                    SW.WriteLine(pnn.name + "," + pnn.price + "," + pnn.loc + "," + pnn.color);
                    SW.Close();
                    MessageBox.Show(pnn.name + " has ben added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    L1.Add(pnn);
                    label4.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    picpath = null;

                }
                else
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Upload the fruit's image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login LogForm = new Login();
            LogForm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fruit2 pnn = new Fruit2();
            
            pnn.name = L1[index].name;
            pnn.price = L1[index].price;
            pnn.loc = L1[index].loc;
            pnn.color = L1[index].color;
            pnn.qty = 1;
            
            f2 = 0;
            for (int i = 0; i < L2.Count; i++)
            {
                if (pnn.name == L2[i].name)
                {
                    L2[i].qty++;
                    L1[index].qtyShow++;
                    f2 = 1;
                    label5.Text = "" + L1[index].qtyShow;
                    MessageBox.Show("Your " + pnn.name + " has been added successfully", "Fruit Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                else
                {
                    f2 = 0;
                }
            }
            if (f2 == 0)
            {
                MessageBox.Show("Your " + pnn.name + " has been added successfully", "Fruit Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                L2.Add(pnn);
                index2++;
                L1[index].qtyShow = 1;
                
                label5.Text = "" + L1[index].qtyShow;
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
                Cart CartForm = new Cart();
                CartForm.ShowDialog();
            
        }

        public void QtyF()
        {
            label5.Text = "" + L1[index].qtyShow;
        }
    }

   
}
