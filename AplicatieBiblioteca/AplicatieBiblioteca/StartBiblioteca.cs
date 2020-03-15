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
                MessageBox.Show(sirSP[2]);

                //convert to datetimefailed
                command.Parameters.Add("dimp", SqlDbType.DateTime).Value = DateTime.Parse(sirSP[2]);
                command.Parameters.Add("dres", SqlDbType.DateTime).Value = DateTime.Parse(sirSP[3]);

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();

            }

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
    }
}
