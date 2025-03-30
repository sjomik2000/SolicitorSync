using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Cases.Application.Database;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Cases.Application.Database
{
    public class DatabaseConnection : IDatabaseConnection //Inheriting IDatabaseConnection interface class
    {
        // Instantiating _connectionString object
        private readonly string _connectionString;
        // Using DatabaseConnection() constructor to inject information about _connectionString
        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        // Defining CreateConnectionAsync method which uses Npgsql package to connect to the PostgreSQL
        public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default)
        {
            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync(token);
            return connection;
        }
    }
}
