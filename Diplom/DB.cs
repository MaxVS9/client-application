using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Diplom
{
    class DB
    {

       // MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=authdb");
        MySqlConnection connection = new MySqlConnection("server=remotemysql.com; port=3306; username=afVSL1JMb2; password=GxVjaF6ix6; database=afVSL1JMb2");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}
