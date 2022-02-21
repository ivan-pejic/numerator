using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        //DEKLARACIJA
        double pomjeranje;
        int i, o;
        int[] konstanta = new int[9] { 9, 8, 7, 6, 9, 8, 7, 6, 9 };
        int[] mnozenje = new int[9];
        int[] niz = new int[9];
        int kontrola;
        int pb, zb, pb1;
        Font font1;
        Color color1;
        int bp = 1;
        string dodajnulu;

        public Form1()
        {
            InitializeComponent();
        }

        void racun()
        {
            int brojac = 8;
            int kontrola1;
            //RAZBIJANJE U NIZ
            if (pb1 < 100000000)
                while (brojac != -1)
                {
                    niz[brojac] = (pb % 10);
                    pb = pb / 10;
                    brojac--;
                }
            else
                while (pb != 0)
                {
                    niz[brojac] = (pb % 10);
                    pb = pb / 10;
                    brojac--;
                }

            //MNOZENJE
            for (i = 0; i < 9; i++)
            {
                mnozenje[i] = niz[i] * konstanta[i];
            }

            //SABIRANJE
            int zbir = 0;
            for (o = 0; o < 9; o++)
            {
                zbir = zbir + mnozenje[o];
            }

            kontrola1 = (zbir / 11) * 11;
            kontrola = zbir - kontrola1;
            if (kontrola == 10)
                kontrola = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bp = Int32.Parse(textBox1.Text);
                pb = Int32.Parse(pbtxt.Text);
                pb1 = pb;
                zb = Int32.Parse(zbtxt.Text);

                //PROVJERA
                if (pbtxt.Text.Length<9 || pbtxt.Text.Length>9 || zbtxt.Text.Length<9 || zbtxt.Text.Length>9)
                {
                    MessageBox.Show("Brojevi su preveliki/premali");
                    pbtxt.Focus();
                }
                else
                {
                    printDialog1.ShowDialog();

                    if (pb <= zb)
                        while (pb1 <= zb)
                        {
                            pb = pb1;
                            racun();
                            int z = 0;

                            while (z != bp)
                            {
                                printDocument1.HasMorePages = true;
                                z++;
                            }
                            pb1++;
                        }

                    else
                        while (pb1 >= zb)
                        {
                            pb = pb1;
                            racun();
                            int z = 0;

                            while (z != bp)
                            {
                                printDocument1.HasMorePages = true;
                                z++;
                            }
                            pb1--;
                        }
                    printDocument1.Print();
                }
            }
            catch { };
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dodajnulu = "";
            for (int i = pb1.ToString().Length; i < 9; i++)
            {
                dodajnulu = dodajnulu + "0";
            }
            int vr = Convert.ToInt32(numericUpDown1.Value);
            double x = Convert.ToDouble(xtxt.Text) / 0.264583333;
            double y = Convert.ToDouble(ytxt.Text) / 0.264583333;
            Brush color1 = new SolidBrush(Color.FromName(colorDialog1.Color.Name));
            font1 = new Font(font1.Name, font1.Size, font1.Style, GraphicsUnit.Pixel);

            if (numericUpDown1.Value == 0)
            {
                e.Graphics.RotateTransform(vr);
                e.Graphics.DrawString(dodajnulu + pb1.ToString() + " " + kontrola.ToString(), font1, color1, Convert.ToInt32(x), Convert.ToInt32(y));
                
            }
            else if (numericUpDown1.Value == 90)
            {
                e.Graphics.RotateTransform(vr);
                e.Graphics.DrawString(dodajnulu + pb1.ToString() + " " + kontrola.ToString(), font1, color1, Convert.ToInt32(y), Convert.ToInt32(x) * (-1));
            }
            else if (numericUpDown1.Value == 180)
            {
                e.Graphics.RotateTransform(vr);
                e.Graphics.DrawString(dodajnulu + pb1.ToString() + " " + kontrola.ToString(), font1, color1, Convert.ToInt32(x) * (-1), Convert.ToInt32(y) * (-1));
            }
            else
            {
                e.Graphics.RotateTransform(vr);
                e.Graphics.DrawString(dodajnulu + pb1.ToString() + " " + kontrola.ToString(), font1, color1, Convert.ToInt32(y) * (-1), Convert.ToInt32(x));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                font1 = fontDialog1.Font;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            colorDialog1.SolidColorOnly = true;
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                color1 = colorDialog1.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
            textBox1.Text = "1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Increment = 90;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 360)
                numericUpDown1.Value = 0;
        }

        private void nova_Activated(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void nova_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 nova = new Form2 ();
            nova.Activated += new EventHandler(nova_Activated);
            nova.FormClosed += new FormClosedEventHandler(nova_FormClosed); 
            nova.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Napravili: Amar Mumić, Ivan Pejić \nKontakt: ivan_pejic_98@yahoo.com");
        }
    }
}