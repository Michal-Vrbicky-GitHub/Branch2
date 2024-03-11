using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zhashenii
{
    public partial class ZmenaHesla : Form
    {
        int ciHeslo;
        bool A;
        public ZmenaHesla(int ciHeslo, bool jeAdmin)
        {
            InitializeComponent();
            this.ciHeslo = ciHeslo;
            A = jeAdmin;
            string jm;
            if (A)
                jm = Program.prihlaseni.administrators[ciHeslo].Jmeno;
            else
                jm = Program.prihlaseni.uzivatels[ciHeslo].Jmeno;
            Text += " uzivatele "+jm;
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            if (Program.prihlaseni.jePrihlasenejAdmin)
            Program.prihlaseni.prihlasenejAdmin.HashHesla = Uzivatel.EncryptSymetricky(textBox1.Text + "AAAAAAAxdxd" + textBox1.Text[0]);
            else
            Program.prihlaseni.prihlasenej     .HashHesla = Uzivatel.EncryptSymetricky(textBox1.Text + "AAAAAAAxdxd" + textBox1.Text[0]);
            */
            if (A)
                Program.prihlaseni.administrators[ciHeslo].HashHesla = Uzivatel.EncryptSymetricky(textBox1.Text + "AAAAAAAxdxd" + textBox1.Text[0]);
            else
                Program.prihlaseni.uzivatels[ciHeslo]     .HashHesla = Uzivatel.EncryptSymetricky(textBox1.Text + "AAAAAAAxdxd" + textBox1.Text[0]);
            textBox1.Text = "Heslo bylo nastaveno";
            this.textBox1.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            Program.prihlaseni.xmlani.DataSavo(Program.prihlaseni.uzivatels/*, Program.prihlaseni.administrators*/);
            textBox1.Refresh();
            Thread.Sleep(1234);
            Close();
        }
    }
}
