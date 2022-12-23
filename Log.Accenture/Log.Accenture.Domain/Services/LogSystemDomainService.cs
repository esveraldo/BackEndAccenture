using Log.Accenture.Domain.Entities;
using Log.Accenture.Domain.Interfaces.Persistence;
using Log.Accenture.Domain.Interfaces.Repositories;
using Log.Accenture.Domain.Interfaces.Services;
using System.ComponentModel;
using System.Linq;

namespace Log.Accenture.Domain.Services
{
    public class LogSystemDomainService : ILogSystemDomainService
    {
        private readonly ILogSystemRepository _logSystemRepository;
        private readonly ILogSystemPersistence _logSystemPersistence;

        public LogSystemDomainService(ILogSystemRepository logSystemRepository, ILogSystemPersistence logSystemPersistence)
        {
            _logSystemRepository = logSystemRepository;
            _logSystemPersistence = logSystemPersistence;
        }

        public async Task<List<LogSystem>> LerLogs()
        {
            return _logSystemRepository.GetAll().ToList();
        }

        public async Task<List<LogSystem>> LerLogsFiltro(string query)
        {
            return _logSystemRepository.GetAll().Where(x => x.Description.Contains(query)).ToList();
        }

        public string GravarLogs()
        {
            foreach (var item in _logSystemPersistence.ReadFile())
            {
                var novoLog = new LogSystem
                {
                    Id = Guid.NewGuid(),
                    Description = item
                };

                _logSystemRepository.Create(novoLog);
            }

            return "Atualizado com sucesso.";
        }

        public void Dispose()
        {
            _logSystemRepository.Dispose();
        }
    }
}
