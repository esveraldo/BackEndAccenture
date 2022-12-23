using Log.Accenture.Domain.Entities;
using Log.Accenture.Domain.Interfaces.Repositories;
using Log.Accenture.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Accenture.Infra.Data.Repositories
{
    public class LogSystemRepository : BaseRepository<LogSystem, Guid>, ILogSystemRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public LogSystemRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
    }
}
