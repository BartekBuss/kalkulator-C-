using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Numery(object sender, EventArgs e)
        {
            var button = sender as Button;

            okno.Text += button.Text;
        }

        
        private void Wynik(object sender, EventArgs e)
        {
            var dzialania = okno.Text;

            if(dzialania.Contains('+'))
            {
                var slowo = dzialania.Split('+');

                var wynik = double.Parse(slowo[0]) + double.Parse(slowo[1]);

                okno.Text = wynik.ToString();
            }

            if (dzialania.Contains('-'))
            {
                var slowo = dzialania.Split('-');

                var wynik = double.Parse(slowo[0]) - double.Parse(slowo[1]);

                okno.Text = wynik.ToString();
            }

            if (dzialania.Contains('/'))
            {
                var slowo = dzialania.Split('/');
                
                var wynik = double.Parse(slowo[0]) / double.Parse(slowo[1]);
                
                if (slowo[1] == "0")
                {
                    okno.Text = "Nie dziel przez 0";
                }else
                okno.Text = wynik.ToString();
            }
            
            if (dzialania.Contains('*'))
            {
                var slowo = dzialania.Split('*');

                var wynik = double.Parse(slowo[0]) * double.Parse(slowo[1]);

                okno.Text = wynik.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            okno.Text += "/";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            okno.Text += "*";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            okno.Text += "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            okno.Text += "+";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            okno.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            chart1.Series["sin(x)"].Points.Clear();
            chart1.Series["cos(x)"].Points.Clear();
            chart1.Series["fKwadratowa"].Points.Clear();

            if (okno.Text == "")
            {
                okno.Text = "Podaj kat";
            }
            else
            {
                var dzialania = okno.Text;
                double a = double.Parse(dzialania);
                var wynik = Math.Round(Math.Sin(a), 2);
                okno.Text = wynik.ToString();

                for (int i = 0; i < a + 1; i++)
                {
                    chart1.Series["sin(x)"].Points.AddXY(i, Math.Sin(i));
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            chart1.Series["cos(x)"].Points.Clear();
            chart1.Series["sin(x)"].Points.Clear();
            chart1.Series["fKwadratowa"].Points.Clear();

            if (okno.Text == "")
            {
                okno.Text = "Podaj kat";
            }
            else
            {
                var dzialania = okno.Text;
                double a = double.Parse(dzialania);
                var wynik = Math.Round(Math.Cos(a), 2);
                okno.Text = wynik.ToString();

                for (int i = 0; i < a + 1; i++)
                {
                    chart1.Series["cos(x)"].Points.AddXY(i, Math.Cos(i));
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (okno.Text == "")
            {
                okno.Text = "Wpisz wartosc";
            }
            else
            {
                var dzialania = okno.Text;
                double a = double.Parse(dzialania);
                var wynik = Math.Round(Math.Sqrt(a), 2);
                okno.Text = wynik.ToString();
            }
        }

        public void button21_Click(object sender, EventArgs e)
        {
            if (okno.Text == "")
            {
                okno.Text = "Podaj wsp a,b,c oddzielone spacja";
            }
            else
            {
                chart1.Series["cos(x)"].Points.Clear();
                chart1.Series["sin(x)"].Points.Clear();
                chart1.Series["fKwadratowa"].Points.Clear();

                var dzialania = okno.Text;
                var slowo = dzialania.Split(' ');
                var delta = (float.Parse(slowo[1]) * float.Parse(slowo[1])) - 4 * float.Parse(slowo[0]) * float.Parse(slowo[2]);
                double d = Math.Sqrt(delta);
                if (delta < 0)
                {
                    okno.Text = "Brak rozwiazan";
                }
                else if(delta == 0)
                {
                    var x0 = Math.Round((-1 * float.Parse(slowo[1])) / (2 * float.Parse(slowo[0])), 2);
                    okno.Text = "x0:" + x0;

                    double xWierzcholek = -1 * double.Parse(slowo[1]) / 2 * double.Parse(slowo[0]);

                    for (int i = int.Parse((xWierzcholek - 15).ToString()); i < float.Parse((xWierzcholek + 15).ToString()); i++)
                    {
                        chart1.Series["fKwadratowa"].Points.AddXY(i, (float.Parse(slowo[0]) * i * i) + (float.Parse(slowo[1]) * i) + float.Parse(slowo[2]));
                    }
                }
                else
                {
                    var x1 = Math.Round((-1 * float.Parse(slowo[1]) + d) / (2 * float.Parse(slowo[0])), 2);
                    var x2 = Math.Round((-1 * float.Parse(slowo[1]) - d) / (2 * float.Parse(slowo[0])), 2);
                    okno.Text = "x1:" + x1 + " " + "x2:" + x2;

                    double xWierzcholek = -1 * double.Parse(slowo[1]) / 2 * double.Parse(slowo[0]);

                    for (int i = int.Parse((xWierzcholek - 15).ToString()); i < float.Parse((xWierzcholek + 15).ToString()); i++)
                    {
                        chart1.Series["fKwadratowa"].Points.AddXY(i, (float.Parse(slowo[0]) * i * i) + (float.Parse(slowo[1]) * i) + float.Parse(slowo[2]));
                    }
                }
            }
        }
    }
}