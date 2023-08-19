using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    class DBConnection
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Naing Min Khant\Documents\Gym.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection connection;

        private SqlCommand command;


        public DBConnection(string query)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public DataTable GetDataTable()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }



    }
}
