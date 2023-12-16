using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    class Connect
    {
        private NpgsqlConnection nconnect;

        public Connect()
        {
            nconnect = new NpgsqlConnection("Server=localhost;Port = 5432;Database=dbtest; User ID = postgres;password = 060809");
        }
        private void connect()
        {
            if (nconnect.State == System.Data.ConnectionState.Closed) 
                nconnect.Open();
        }
        private void disconnect()
        {
            if (nconnect.State == System.Data.ConnectionState.Closed)
                nconnect.Open();
        }

        public int ExecuteNonQuery(NpgsqlCommand command)
        {
            connect();
            command.Connection = nconnect;
            int res = command.ExecuteNonQuery();
            disconnect();
            return res;
        }

        public NpgsqlDataReader ExecuteReader(NpgsqlCommand command)
        {
            connect();
            command.Connection = nconnect;
            NpgsqlDataReader res = command.ExecuteReader();
            disconnect();
            return res;
        }

        public object ExecuteScalar(NpgsqlCommand command)
        {
            connect();
            command.Connection = nconnect;
            object res = command.ExecuteScalar();
            disconnect();
            return res;
        }


    }
}
