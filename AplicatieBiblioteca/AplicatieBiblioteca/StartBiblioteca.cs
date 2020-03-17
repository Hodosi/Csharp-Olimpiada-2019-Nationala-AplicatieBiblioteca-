using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace AplicatieBiblioteca
{
    public partial class StartBiblioteca : Form
    {
        public StartBiblioteca()
        {
            InitializeComponent();
        }

        CONNECT conn = new CONNECT();
        QUERY que = new QUERY();
        private void StartBiblioteca_Load(object sender, EventArgs e)
        {
            string fn = Application.StartupPath + @"\Resurse\Imagini\altele\biblioteca1.jpg";
            this.pictureBox1.Image = Image.FromFile(fn);
            que.reseedDB();
            sterge();
            initializare();
        }

        public void initializare()
        {
            SqlCommand command = new SqlCommand();
            StreamReader reader;
            string fn, sir;
            string[] sirSP;
            char split = ';';
            fn = Application.StartupPath + @"\Resurse\carti.txt";
            reader = new StreamReader(fn);

            while ((sir = reader.ReadLine()) != null)
            {
                sirSP = sir.Split(split);

                command = new SqlCommand();
                command.CommandText = "INSERT INTO Carti(Titlu,Autor,Nrpag) VALUES(@tit,@aut,@nr)";
                command.Connection = conn.GetConnection();

                //@tit,@aut,@nr
                command.Parameters.Add("tit", SqlDbType.VarChar).Value = sirSP[0];
                command.Parameters.Add("aut", SqlDbType.VarChar).Value = sirSP[1];
                command.Parameters.Add("nr", SqlDbType.Int).Value = int.Parse(sirSP[2]);

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();

            }

            fn = Application.StartupPath + @"\Resurse\imprumuturi.txt";
            reader = new StreamReader(fn);

            while ((sir = reader.ReadLine()) != null)
            {
                sirSP = sir.Split(split);

                command = new SqlCommand();
                command.CommandText = "INSERT INTO Imprumuturi(IdCititor,IdCarte,DataImprumut,DataRestituire) VALUES(@idcit,@idcart,@dimp,@dres)";
                command.Connection = conn.GetConnection();

                //@idcit,@idcart,@dimp,@dres
                command.Parameters.Add("idcit", SqlDbType.Int).Value = int.Parse(sirSP[0]);
                command.Parameters.Add("idcart", SqlDbType.Int).Value = int.Parse(sirSP[1]);
                //MessageBox.Show(sirSP[2]);
                // DateTime time=DateTime.ParseExact(sirSP[2], "mm / dd / yyyy hh / mm / ss AM / PM", CultureInfo.InvariantCulture);
                //MessageBox.Show(time.ToString());
                //convert to datetimefailed
                command.Parameters.Add("dimp", SqlDbType.VarChar).Value = sirSP[2];
                command.Parameters.Add("dres", SqlDbType.VarChar).Value = sirSP[3];

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();
            }

            fn = Application.StartupPath + @"\Resurse\rezervari.txt";
            reader = new StreamReader(fn);

            while ((sir = reader.ReadLine()) != null)
            {
                sirSP = sir.Split(split);

                command = new SqlCommand();
                command.CommandText = "INSERT INTO Rezervari(IdCititor,IdCarte,DataRezervare,StatusRezervare) VALUES(@idcit,@idcart,@dat,@stat)";
                command.Connection = conn.GetConnection();

                //@idcit,@idcart,@dat,@stat
                command.Parameters.Add("idcit", SqlDbType.Int).Value = int.Parse(sirSP[0]);
                command.Parameters.Add("idcart", SqlDbType.Int).Value = int.Parse(sirSP[1]);
                command.Parameters.Add("dat", SqlDbType.VarChar).Value = sirSP[2];
                command.Parameters.Add("stat", SqlDbType.VarChar).Value = int.Parse(sirSP[3]);

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();
            }

            fn = Application.StartupPath + @"\Resurse\utilizatori.txt";
            reader = new StreamReader(fn);

            while ((sir = reader.ReadLine()) != null)
            {
                sirSP = sir.Split(split);

                command = new SqlCommand();
                command.CommandText = "INSERT INTO Utilizatori(TipUtilizator,NumePrenume,Email,Parola) VALUES(@tip,@nm,@em,@pas)";
                command.Connection = conn.GetConnection();

                //@tip,@nm,@em,@pas
                command.Parameters.Add("tip", SqlDbType.Int).Value = int.Parse(sirSP[0]);
                command.Parameters.Add("nm", SqlDbType.VarChar).Value = sirSP[1];
                command.Parameters.Add("em", SqlDbType.VarChar).Value = sirSP[2];
                string parola = criptare(sirSP[3]);
                command.Parameters.Add("pas", SqlDbType.VarChar).Value = parola;

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();
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
        public void sterge()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM Carti";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "DELETE FROM Imprumuturi";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "DELETE FROM Rezervari";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "DELETE FROM Utilizatori";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogareBiblioteca log = new LogareBiblioteca();
            log.ShowDialog();
            this.Close();
        }
    }
}
