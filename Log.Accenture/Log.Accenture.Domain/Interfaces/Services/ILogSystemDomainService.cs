using Log.Accenture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Accenture.Domain.Interfaces.Services
{
    public interface ILogSystemDomainService : IDisposable
    {
        Task<List<LogSystem>> LerLogs();
        Task<List<LogSystem>> LerLogsFiltro(string query);
        string GravarLogs();
    }
}
