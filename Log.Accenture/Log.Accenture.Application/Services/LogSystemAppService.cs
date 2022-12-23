using AutoMapper;
using Log.Accenture.Application.Interfaces;
using Log.Accenture.Application.ViewModels.Log;
using Log.Accenture.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace Log.Accenture.Application.Services
{
    public class LogSystemAppService : ILogSystemAppService
    {
        private readonly ILogSystemDomainService _logSystemDomainService;
        private readonly IMapper _mapper;

        public LogSystemAppService(ILogSystemDomainService logSystemDomainService, IMapper mapper)
        {
            _logSystemDomainService = logSystemDomainService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LogSystemViewModel>> LerTodosLogs()
        {
            return _mapper.Map<IEnumerable<LogSystemViewModel>>(await _logSystemDomainService.LerLogs());
        }

        public async Task<IEnumerable<LogSystemViewModel>> LerTodosLogsFiltro(string query)
        {
            return _mapper.Map<IEnumerable<LogSystemViewModel>>(await _logSystemDomainService.LerLogsFiltro(query));
        }

        public void GravarLogs()
        {
            _logSystemDomainService.GravarLogs();
        }

        public void Dispose()
        {
            _logSystemDomainService.Dispose();
        }
    }
}
