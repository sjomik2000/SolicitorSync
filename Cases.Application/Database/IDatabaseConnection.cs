using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Database
{
    //Interface for Database connection layer to define all database connection actions.
    public interface IDatabaseConnection
    {
        Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
    }
}
