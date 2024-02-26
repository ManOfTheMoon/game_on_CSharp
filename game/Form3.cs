using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace game
{

    public partial class Form3 : Form
    {
        public int score = 0;
        public Form1 frm1;
        public Form3 frm3;
        Image Picture;
        Pen pen = new Pen(Color.Black, 1);
        const int n = 8;
        int h = 50, w = 50, x = 250, y = 100, i0, j0, click = 1;
        int maximum_i = 0, minimum_i = 0, maximum_j = 0, minimum_j = 0;
        int min_i = 0, max_i = 0, min_j = 0, max_j = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            frm1 = new Form1();
            frm1.frm3 = this;
            this.Hide();
            frm1.Show();
        }

        PictureBox[,] pb = new PictureBox[n, n];


        string[] animals = { @"..\..\..\zebra.png",
                             @"..\..\..\aligator.png",
                             @"..\..\..\bik.png",
                             @"..\..\..\cat.png",
                             @"..\..\..\mikrochel.png"};
        int[,] array = new int[n, n];
        Random rnd = new Random();

        public Form3()
        {
            InitializeComponent();
        }

        private void on_closing(object sender, FormClosingEventArgs e)
        {
            frm1 = new Form1();
            frm1.frm3 = this;
            this.Hide();
            frm1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Счёт:" + score;
            int len, tmp;
            string s;
            len = animals.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    pb[i, j] = new PictureBox();
                    
                    tmp = rnd.Next(0, len);
                    array[i, j] = tmp + 1;
                    s = animals[tmp];
                    Picture = new Bitmap(s);
                    pb[i, j].Image = Picture;
                    pb[i, j].Left = x + j * h;
                    pb[i, j].Top = y + i * h;
                    pb[i, j].Width = h;
                    pb[i, j].Height = h;
                    pb[i, j].BorderStyle = BorderStyle.Fixed3D;
                    pb[i, j].Click += pb_Click;
                    this.Controls.Add(pb[i, j]);
                }
            }
            CheckPos();
        }
        public void CheckPos()
        {
            int len, tmp;
            len = animals.Length;
            string s;
            int counter_pics = 0;
            bool checking = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmp = rnd.Next(0, len);
                    array[i, j] = tmp + 1;
                    if (j > 1)
                    {
                        counter_pics = 0;
                        checking = false;
                        while (!checking)
                        {
                            if (array[i, j - 1] == array[i, j])
                                counter_pics++;
                            if (array[i, j - 2] == array[i, j])
                                counter_pics++;
                            if (counter_pics == 2)
                            {
                                tmp = rnd.Next(0, len);
                                array[i, j] = tmp + 1;
                                counter_pics = 0;
                            }
                            else
                                checking = true;
                        }

                    }
                    if (i > 1)
                    {
                        counter_pics = 0;
                        checking = false;
                        while (!checking)
                        {
                            if (array[i - 1, j] == array[i, j])
                                counter_pics++;
                            if (array[i - 2, j] == array[i, j])
                                counter_pics++;
                            if (counter_pics == 2)
                            {
                                tmp = rnd.Next(0, len);
                                array[i, j] = tmp + 1;
                                counter_pics = 0;
                            }
                            else
                                checking = true;
                        }
                    }
                    s = animals[tmp];
                    Picture = new Bitmap(s);
                    pb[i, j].Image = Picture;
                }
            }
        }

        public bool FoundMatches(int m, int k)
        {
            int counter1 = -1;
            int counter2 = -1;
            int i = m;
            int j = k;
            min_j = max_j = j;
            for (j = k; (j < n) && (j >= 0); j++)
            {
                if (array[i, j] == array[m, k])
                {
                    counter1++;
                    max_j = j;
                }
                else
                    break;
            }

            for (j = k; (j < n) && (j >= 0); j--)
            {
                if (array[i, j] == array[m, k])
                {
                    counter1++;
                    min_j = j;
                }
                else
                    break;
            }

            if (counter1 >= 3)
            {
                maximum_i = m;
                minimum_i = m;
                maximum_j = max_j;
                minimum_j = min_j;
                return true;

            }

            j = k;
            min_i = max_i = m;

            for (i = m; (i < n) && (i >= 0); i++)
            {
                if (array[i, j] == array[m, k])
                {
                    counter2++;
                    max_i = i;
                }
                else
                    break;
            }

            for (i = m; (i < n) && (i >= 0); i--)
            {
                if (array[i, j] == array[m, k])
                {
                    counter2++;
                    min_i = i;
                }
                else
                    break;
            }

            if (counter2 >= 3)
            {
                maximum_i = max_i;
                minimum_i = min_i;
                maximum_j = k;
                minimum_j = k;
                return true;
            }

                return false;
        }

        public void RemoveAndFall()
        {
            int len, tmp;
            string s;
            len = animals.Length;
            for (int i = minimum_i; i <= maximum_i; i++)
            { 
                for (int j = minimum_j; j <= maximum_j; j++)
                {
                    for (int x = i; x >= 1; x--)
                    {
                        array[x, j] = array[x - 1, j];
                        pb[x, j].Image = pb[x - 1, j].Image;
                    }
                    tmp = rnd.Next(0, len);
                    s = animals[tmp];
                    Picture = new Bitmap(s);
                    pb[0, j].Image = Picture;
                    array[0, j] = tmp + 1;
                }
            }
            score++;
            label1.Text = "Счёт:" + score;
        }   
        public void pb_Click(object sender, EventArgs e)
        {
            int k, m, tmp;
            PictureBox PB = sender as PictureBox;
            k = (PB.Left - x) / w;
            m = (PB.Top - y) / h;
            if (click == 1)
            {
                j0 = (PB.Left - x) / w;
                i0 = (PB.Top - y) / h;
                pictureBox1.Image = PB.Image;
                click = 2;
            }
            else if (((Math.Abs(j0 - k) == 1) && (i0 == m)) || ((Math.Abs(i0 - m) == 1) && (j0 == k)))
            {
                tmp = array[i0, j0];
                array[i0, j0] = array[m, k];
                array[m, k] = tmp;
                pb[i0, j0].Image = PB.Image;
                PB.Image = pictureBox1.Image;
                i0 = m;
                j0 = k;
                click = 1;
                if (FoundMatches(m, k))
                {
                    RemoveAndFall();
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (FoundMatches(i, j))
                            {
                                RemoveAndFall();
                            }
                        }
                    }
;               }
            }
        }
    }
}
    

