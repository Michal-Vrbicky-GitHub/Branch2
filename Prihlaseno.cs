using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zhashenii
{
    public partial class Prihlaseno : Form
    {
        public Prihlaseno()
        {
            InitializeComponent();
            if (Program.prihlaseni.jePrihlasenejAdmin)
            {
                label1.Text = Program.prihlaseni.prihlasenejAdmin.Jmeno;
                button3.Visible = true;
            }
            else
                label1.Text = Program.prihlaseni.prihlasenej     .Jmeno;
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            Program.prihlaseni.prihlasenejAdmin.Jmeno = null;
            Program.prihlaseni.prihlasenej     .Jmeno = null;
            Program.prihlaseni.prihlasenejAdmin.Jmeno = new Administrator()*/
            Program.prihlaseni.Odhlasit();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZmenaHesla zh = new ZmenaHesla(Program.prihlaseni.ix, Program.prihlaseni.jePrihlasenejAdmin);
            zh.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seznam s = new Seznam();
            s.Visible = true;
        }
    }
}
