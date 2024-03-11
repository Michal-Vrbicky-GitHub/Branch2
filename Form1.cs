﻿using System;
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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == ""  ||  textBox1.Text == null  ||  textBox2.Text == null  ||  textBox2.Text == "")
            {
                MessageBox.Show("To nepude");
                return;
            }
            foreach (var ucet in Program.prihlaseni.administrators)
            {
                if (ucet.Jmeno == textBox1.Text)
                {
                    MessageBox.Show("Ten už tu je");
                    return;
                }
            }

            if (!checkBox1.Checked)
                Program.prihlaseni.uzivatels.Add(new Uzivatel(textBox1.Text, textBox2.Text, true));
            else
                Program.prihlaseni.administrators.Add(new Administrator(textBox1.Text, textBox2.Text, true));
            Program.prihlaseni.xmlani.DataSavo(Program.prihlaseni.uzivatels/*, Program.prihlaseni.administrators*/); //Prihlasenixmlani.DataSavo(Prihlaseni.uzivatels, Prihlaseni.administrators);

            this.Close();
            //Prihlaseni.ActiveForm.Visible = true;
            Program.prihlaseni.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}


    }
}