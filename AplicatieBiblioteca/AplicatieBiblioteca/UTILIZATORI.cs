using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AplicatieBiblioteca
{
    class UTILIZATORI
    {
        CONNECT conn = new CONNECT();
        public bool userExist(string em, string pas)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Utilizatori WHERE Email=@em AND Parola=@pas";
            command.Connection = conn.GetConnection();

            command.Parameters.Add("em", SqlDbType.VarChar).Value = em;
            command.Parameters.Add("pas", SqlDbType.VarChar).Value = pas;

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
