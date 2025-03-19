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
        private readonly IDatabaseConnection _dbConnection;

        public CaseRepository(IDatabaseConnection connection)
        {
            _dbConnection = connection;
        }

        //private readonly List<Case> _cases = new();
        public async Task<bool> CreateAsync(Case caseItem, CancellationToken token = default)
        {
            caseItem.GenerateSlug();
            using var connection = await _dbConnection.CreateConnectionAsync(token);
            using var transaction = connection.BeginTransaction();
            var result = await connection.ExecuteAsync(new CommandDefinition("""
                insert into cases (id, case_name, created_date, updated_date, slug, client_name,
                case_type, case_state, assigned_attorney, court_date, case_description, documents, notes)
                values (@id, @case_name, @created_date, @updated_date, @slug, @client_name,
                @case_type, @case_state, @assigned_attorney, @court_date, @case_description, @documents, @notes)
                """, caseItem, cancellationToken: token));
            transaction.Commit();
            return result > 0;
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token);
            using var transaction = connection.BeginTransaction();

            var result = await connection.ExecuteAsync(new CommandDefinition("""
                delete from cases where id = @id
                """, new { id }, cancellationToken: token));
            transaction.Commit();
            return result > 0;
        }

        public async Task<IEnumerable<Case>> GetAllAsync(CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token);
            var cases = await connection.QueryAsync(new CommandDefinition("""
                select * from cases
                """, cancellationToken: token));
            return cases.Select(x => new Case
            {
                id = (Guid)x.id,
                case_name = (string)x.case_name,
                created_date = (DateTime)x.created_date,
                updated_date = (DateTime?)x.updated_date,
                slug = (string)x.slug,
                client_name = (string)x.client_name,
                case_type = (string)x.case_type,
                case_state = (string)x.case_state,
                assigned_attorney = (string?)x.assigned_attorney,
                court_date = (DateTime?)x.court_date,
                case_description = (string)x.case_description,
                documents = (string?)x.documents,
                notes = (string?)x.notes

            });
        }

        public async Task<Case?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token);
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
            using var connection = await _dbConnection.CreateConnectionAsync(token);
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
            using var connection = await _dbConnection.CreateConnectionAsync(token);
            using var transaction = connection.BeginTransaction();
            var result = await connection.ExecuteAsync(new CommandDefinition("""
                update cases set case_name = @case_name, updated_date = @updated_date, slug = @slug, client_name = @client_name,
                case_type = @case_type, case_state = @case_state, assigned_attorney = @assigned_attorney, 
                court_date = @court_date, case_description = @case_description, documents = @documents, 
                notes = @notes where id = @id
                """, caseItem, cancellationToken: token));
            transaction.Commit();
            return result > 0;
        }

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
        {
            using var connection = await _dbConnection.CreateConnectionAsync(token);
            return await connection.ExecuteScalarAsync<bool>(new CommandDefinition("""
                select count(1) from cases where id = @id
                """, new { id }, cancellationToken: token));
        }
    }
};
