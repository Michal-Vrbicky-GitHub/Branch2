using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zhashenii
{
    public partial class Seznam : Form
    {
        public Seznam()
        {
            InitializeComponent();
            Nalisteni();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int ind = listBox1.SelectedIndex;
            bool adm = true;
            if (ind >= Program.prihlaseni.administrators.Count) { 
                ind -= Program.prihlaseni.administrators.Count;
                adm = false;
            }
            ZmenaHesla zmenaHesla = new ZmenaHesla(ind, adm);
            zmenaHesla.Visible = true;
        }

        void Nalisteni()
        {
            foreach (Administrator a in Program.prihlaseni.administrators)
                listBox1.Items.Add(a.Jmeno);
            foreach (Uzivatel u in Program.prihlaseni.uzivatels)
                listBox1.Items.Add(u.Jmeno);
        }
    }
}
