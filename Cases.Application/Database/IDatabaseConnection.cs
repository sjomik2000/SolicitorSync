using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Database
{
    public interface IDatabaseConnection
    {
        Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
    }
}
