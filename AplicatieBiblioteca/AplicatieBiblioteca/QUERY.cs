using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AplicatieBiblioteca
{
    class QUERY
    {
        CONNECT conn = new CONNECT();
        public void reseedDB()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "DBCC CHECKIDENT(Carti,RESEED,0)";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "DBCC CHECKIDENT(Imprumuturi,RESEED,0)";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "DBCC CHECKIDENT(Rezervari,RESEED,0)";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "DBCC CHECKIDENT(Utilizatori,RESEED,0)";
            command.Connection = conn.GetConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();
        }
    }
}
