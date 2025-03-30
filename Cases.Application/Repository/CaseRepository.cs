using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cases.Application.Database;
using Cases.Application.Models;
using Dapper;

namespace Cases.Application.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        //Instantianting _dbConnection 
        private readonly IDatabaseConnection _dbConnection;

        //Using CaseRepository constructor to inject information about _dbConnection
        public CaseRepository(IDatabaseConnection connection)
        {
            _dbConnection = connection;
        }

        public async Task<bool> CreateAsync(Case caseItem, CancellationToken token = default)
        { 
            caseItem.GenerateSlug(); //Generate the slug and add it to the Case model
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            //Dapper SQL logic to add caseItem into the Cases Database, as changes are imported into database
            //transaction is used to execute changes.
            using var transaction = connection.BeginTransaction(); 
            var result = await connection.ExecuteAsync(new CommandDefinition("""
                insert into cases (id, case_name, created_date, updated_date, slug, client_name,
                case_type, case_state, assigned_attorney, court_date, case_description, documents, notes)
                values (@id, @case_name, @created_date, @updated_date, @slug, @client_name,
                @case_type, @case_state, @assigned_attorney, @court_date, @case_description, @documents, @notes)
                """, caseItem, cancellationToken: token));
            transaction.Commit();
            return result > 0; //If changes are made true is returned 
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            using var transaction = connection.BeginTransaction(); //Dapper SQL logic to delete caseItem from the database using specified ID
            var result = await connection.ExecuteAsync(new CommandDefinition("""
                delete from cases where id = @id
                """, new { id }, cancellationToken: token));
            transaction.Commit();
            return result > 0; //If changes are made true is returned 
        }

        public async Task<IEnumerable<Case>> GetAllAsync(CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            //Dapper SQL logic to retrieve all cases from database
            var cases = await connection.QueryAsync<Case>(new CommandDefinition("""
                select * from cases
                """, cancellationToken: token));
            return (IEnumerable<Case>)cases; 
        }

        public async Task<Case?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            //Dapper SQL logic to retrieve single case based on provided id
            var caseItem = await connection.QuerySingleOrDefaultAsync<Case>(
                new CommandDefinition("""
                    select * from cases where id = @id
                    """, new {id}, cancellationToken: token));
            if (caseItem is null)
            {
                return null;
            }
            return caseItem;
        }

        public async Task<Case?> GetBySlugAsync(string slug, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            //Dapper SQL logic to retrieve single case based on provided slug
            var caseItem = await connection.QuerySingleOrDefaultAsync<Case>(
                new CommandDefinition("""
                    select * from Cases where slug = @slug
                    """, new { slug }, cancellationToken: token));
            if (caseItem is null)
            {
                return null;
            }
            return caseItem;
        }

        public async Task<bool> UpdateAsync(Case caseItem, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            //Dapper SQL logic to update caseItem into the Cases Database, as changes are imported into database
            //transaction is used to execute changes.
            using var transaction = connection.BeginTransaction();
            var result = await connection.ExecuteAsync(new CommandDefinition("""
                update cases set case_name = @case_name, updated_date = @updated_date, slug = @slug, client_name = @client_name,
                case_type = @case_type, case_state = @case_state, assigned_attorney = @assigned_attorney, 
                court_date = @court_date, case_description = @case_description, documents = @documents, 
                notes = @notes where id = @id
                """, caseItem, cancellationToken: token));
            transaction.Commit();
            return result > 0; //If changes are made true is returned 
        }

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token); // Establishing DB connection
            // Returns true if case is found using given id
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition("""
                select count(1) from cases where id = @id
                """, new { id }, cancellationToken: token));
        }
    }
};
