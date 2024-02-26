using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        public Form3 frm3;
        public Form4 frm4;
        public Form1 frm1;
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm4 = new Form4();
            frm4.frm1 = this;
            this.Hide();
            frm4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            frm3.frm1 = this;
            this.Hide();
            frm3.Show();

        }

        public Form1()
        {
            InitializeComponent();
        }

    }
}
