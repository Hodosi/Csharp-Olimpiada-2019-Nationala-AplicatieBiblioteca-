using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AplicatieBiblioteca
{
    public partial class LogareBiblioteca : Form
    {
        public LogareBiblioteca()
        {
            InitializeComponent();
        }

        UTILIZATORI util = new UTILIZATORI();
        private void LogareBiblioteca_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string em = this.textBox_email.Text;
            string pas = this.textBox_parola.Text;
            pas = criptare(pas);
            if (util.userExist(em, pas))
            {
                this.Hide();
                BibliotecarBiblioteca bib = new BibliotecarBiblioteca();
                bib.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email si/ sau parola invalida");
            }
        }
        
        public string criptare(string s)
        {
            int l = s.Length;
            char letter;
            char nextxhar;
            //MessageBox.Show(s);
            for (int i = 0; i < l; i++)
            {
                letter = s[i];
                if (char.IsDigit(letter))
                {
                    int x = (int)letter;
                    string nextch = (57 - x).ToString();
                    s = s.Substring(0, l - (l - i)) + nextch + s.Substring(i + 1);
                }
                else if (char.IsLower(letter))
                {
                    if (letter == 'z')
                    {
                        s = s.Substring(0, l - (l - i)) + "a" + s.Substring(i + 1);
                    }
                    else
                    {
                        nextxhar = (char)(((int)letter) + 1);
                        s = s.Substring(0, l - (l - i)) + nextxhar.ToString() + s.Substring(i + 1);
                    }
                }
                else if (char.IsUpper(letter))
                {
                    if (letter == 'A')
                    {
                        s = s.Substring(0, l - (l - i)) + "Z" + s.Substring(i + 1);
                    }
                    else
                    {
                        nextxhar = (char)(((int)letter) - 1);
                        s = s.Substring(0, l - (l - i)) + nextxhar.ToString() + s.Substring(i + 1);
                    }
                }
            }
            //MessageBox.Show(s);
            return s;
        }
    }
}
