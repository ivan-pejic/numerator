using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {

        //DEKLARACIJA
        double pomjeranje;
        int i, o;
        int[] konstanta = new int[9] { 9, 8, 7, 6, 9, 8, 7, 6, 9 };
        int[] mnozenje = new int[9];
        int[] niz = new int[9];
        int kontrola, kontrola3, kontrola2;
        int pb, zb, pb1, pb2, pb3, p2, z2, z3, p3;
        Font font1;
        Color color1;
        int bp = 1;
        string dodajnulu, dodajnulu2, dodajnulu3;

        public Form2()
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

        void racun2()
        {
            int brojac = 8;
            int kontrola1;
            //RAZBIJANJE U NIZ
            if (pb2 < 100000000)
                while (brojac != -1)
                {
                    niz[brojac] = (p2 % 10);
                    p2 = p2 / 10;
                    brojac--;
                }
            else
                while (p2 != 0)
                {
                    niz[brojac] = (p2 % 10);
                    p2 = p2 / 10;
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
            kontrola2 = zbir - kontrola1;
            if (kontrola2 == 10)
                kontrola2 = 0;
        }

        void racun3()
        {
            int brojac = 8;
            int kontrola1;
            //RAZBIJANJE U NIZ
            if (pb3 < 100000000)
                while (brojac != -1)
                {
                    niz[brojac] = (p3 % 10);
                    p3 = p3 / 10;
                    brojac--;
                }
            else
                while (p3 != 0)
                {
                    niz[brojac] = (p3 % 10);
                    p3 = p3 / 10;
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
            kontrola3 = zbir - kontrola1;
            if (kontrola3 == 10)
                kontrola3 = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pomjeranje = Int32.Parse(textBox2.Text) / 0.264583333;
        }

        private void fontana_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                font1 = fontDialog1.Font;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.SolidColorOnly = true;
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                color1 = colorDialog1.Color;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                bp = Int32.Parse(textBox1.Text);
                pb = Int32.Parse(pbtxt.Text);
                pb1 = pb;
                zb = Int32.Parse(zbtxt.Text);

                p2 = Int32.Parse(p2txt.Text);
                pb2 = p2;
                z2 = Int32.Parse(z2txt.Text);

                p3 = Int32.Parse(p3txt.Text);
                pb3 = p3;
                z3 = Int32.Parse(z3txt.Text);

                if (pbtxt.Text.Length < 9 || pbtxt.Text.Length > 9 || zbtxt.Text.Length < 9 || zbtxt.Text.Length > 9 || p2txt.Text.Length < 9 || p2txt.Text.Length > 9 || z2txt.Text.Length < 9 || z2txt.Text.Length > 9 || p3txt.Text.Length < 9 || p3txt.Text.Length > 9 || z3txt.Text.Length < 9 || z3txt.Text.Length > 9)
                    MessageBox.Show("Brojevi neispravno upisani");
                else
                {
                    printDialog1.ShowDialog();

                    if (pb <= zb)
                        while (pb1 <= zb && pb2 <= z2 && pb3 <= z3)
                        {
                            pb = pb1;
                            p2 = pb2;
                            p3 = pb3;
                            racun();
                            racun2();
                            racun3();
                            int z = 0;
                            while (z != bp)
                            {
                                printDocument1.Print();
                                z++;
                            }
                            pb1++;
                            pb2++;
                            pb3++;
                        }

                    else
                        while (pb1 >= zb && pb2 >= z2 && pb3 >= z3)
                        {
                            pb = pb1;
                            p2 = pb2;
                            p3 = pb3;
                            racun();
                            racun2();
                            racun3();
                            int z = 0;
                            while (z != bp)
                            {
                                printDocument1.Print();
                                z++;
                            }
                            pb1--;
                            pb2--;
                            pb3--;
                        }
                }
            }
            catch { };
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dodajnulu = "";
            for (int i = pb1.ToString().Length; i < 9; i++)
            {
                dodajnulu = dodajnulu + "0";
            }

            dodajnulu2 = "";
            for (int i = pb2.ToString().Length; i < 9; i++)
            {
                dodajnulu2 = dodajnulu2 + "0";
            }

            dodajnulu3 = "";
            for (int i = pb3.ToString().Length; i < 9; i++)
            {
                dodajnulu3 = dodajnulu3 + "0";
            }

            double x = Convert.ToDouble(xtxt.Text) / 0.264583333;
            double y = Convert.ToDouble(ytxt.Text) / 0.264583333;
            Brush color1 = new SolidBrush(Color.FromName(colorDialog1.Color.Name));
            font1 = new Font(font1.Name, font1.Size, font1.Style, GraphicsUnit.Pixel);
            e.Graphics.DrawString(dodajnulu + pb1.ToString() + " " + kontrola.ToString(), font1, color1, Convert.ToInt32(x), Convert.ToInt32(y));
            e.Graphics.DrawString(dodajnulu2 + pb2.ToString() + " " + kontrola2.ToString(), font1, color1, Convert.ToInt32(x), Convert.ToInt32(y + pomjeranje));
            e.Graphics.DrawString(dodajnulu3 + pb3.ToString() + " " + kontrola3.ToString(), font1, color1, Convert.ToInt32(x), Convert.ToInt32(y + (pomjeranje * 2)));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pomjeranje = 100 / 0.264583333;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            pomjeranje = Int32.Parse(textBox2.Text) / 0.264583333;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
            textBox1.Text = "1";
        }
    }
}