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

namespace zhashenii
{
    public partial class Prihlaseni : Form
    {
        static string EEEEDirectory = /*Path.GetDirectoryName(*/Path.GetDirectoryName(Directory.GetCurrentDirectory())/*)*/;

        string heslo;
        public List<Uzivatel> uzivatels = new List<Uzivatel>();
        public List<Administrator> administrators = new List<Administrator>();
        public Uzivatel prihlasenej;
        public Administrator prihlasenejAdmin;
        public bool jePrihlasenejAdmin;
        public int ix;
        public XMLovani xmlani = new XMLovani(EEEEDirectory+"\\majesqůel.sql");// public static XMLovani xmlani = new XMLovani();
        bool tedNe = false;

        public Prihlaseni()
        {
            InitializeComponent();
            label3.Hide();
            heslo = "";
            uzivatels      = (List<Uzivatel>)     xmlani.DataLoader(/*"userse"*/);
            //administrators = (List<Administrator>)xmlani.DataLoader("admins");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!tedNe) { 
                tedNe = true;
                string puntiky = "";
                heslo += textBox2.Text[0];
                for (int i = 0; i < heslo.Length; i++)
                    puntiky += '●';
                textBox2.Text = puntiky;
                tedNe = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool prihlasit = false;
            ix = -1;
            foreach (var ucet in administrators)
            {
                if (ucet.Jmeno == textBox1.Text  &&  ucet.HashHesla == Uzivatel.EncryptSymetricky(heslo + "AAAAAAAxdxd" + heslo[0])){
                    prihlasenejAdmin = ucet;
                    prihlasit = true;
                jePrihlasenejAdmin = true;}
                ix++;
            }
            if (!prihlasit)
            {
                ix=-1;
                foreach (var ucet in uzivatels)
                {
                    if (ucet.Jmeno == textBox1.Text && ucet.HashHesla == Uzivatel.EncryptSymetricky(heslo + "AAAAAAAxdxd" + heslo[0]))
                    {
                        prihlasit = true;
                        jePrihlasenejAdmin = false;
                        prihlasenej = ucet;
                    }
                    ix++;
                }
            }
            if (prihlasit)
            {
                this.Visible/* = prihlasit */= false;
                Prihlaseno home = new Prihlaseno();
                home.Show();
            }
            else
            {
                /**/
            }
            tedNe = true;
            textBox2.Text = heslo = "";
            label3.Visible = true;
            tedNe = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 registrace = new Form1();
            registrace.Show();
            this.Visible = false;
        }
        /*
bool ProjedTo(object ucty)
{
   foreach (var ucet in ucty)
   {

   }
   return false;
}*/

        public void Odhlasit()
        {
            Visible = tedNe = true;
            textBox2.Text = heslo = textBox1.Text = "";
            label3.Visible = false;
            tedNe = false;
        }
    }
}
