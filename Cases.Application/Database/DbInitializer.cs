using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Database
{
    public class DbInitializer
    {
        private readonly IDatabaseConnection _databaseConnection;

        public DbInitializer(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _databaseConnection.CreateConnectionAsync();

            await connection.ExecuteAsync("""
                create table if not exists cases (
                id UUID primary key,
                case_name TEXT not null,
                created_date TIMESTAMP WITH TIME ZONE not null,
                updated_date TIMESTAMP WITH TIME ZONE,
                slug TEXT not null,
                client_name TEXT not null,
                case_type TEXT not null,
                case_state TEXT not null,
                assigned_attorney TEXT,
                court_date TIMESTAMP WITH TIME ZONE,
                case_description TEXT not null,
                documents TEXT,
                notes TEXT);
                """);

            await connection.ExecuteAsync("""
                create unique index concurrently if not exists cases_slug_idx
                on cases
                using btree(slug);
                """);
        }
    }
}


