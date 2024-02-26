using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace game
{
    public partial class Form4 : Form
    {
        public Form1 frm1;
        public Form4 frm4;
        public Form4()
        {
            InitializeComponent();
        }

        private void on_closing(object sender, FormClosingEventArgs e)
        {
            frm1 = new Form1();
            frm1.frm4 = this;
            this.Hide();
            frm1.Show();
        }
    }
}
