using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL
{
    // Class to manage SQL Server database connection
    internal class DbConnectionManager
    {
        private SqlConnection _connection;
        private string _connectionString;
        
        // Constructor
        public DbConnectionManager()
        {
            // Initialize the connection string
            _connectionString = @"Data Source=(localdb)\.;Initial Catalog=Lab1SQL;Integrated Security=True;Pooling=False";

            // Create a new SqlConnection object using the connection string
            _connection = new SqlConnection(_connectionString);
        }

        // Method to get the database connection if it's closed
        public SqlConnection GetConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            // Return the SqlConnection object (either existing or newly opened)
            return _connection;
        }
    }
}

