using Log.Accenture.Application.ViewModels.Log;
using Log.Accenture.Domain.Entities;

namespace Log.Accenture.Application.Interfaces
{
    public interface ILogSystemAppService : IDisposable
    {
        Task<IEnumerable<LogSystemViewModel>> LerTodosLogs();
        Task<IEnumerable<LogSystemViewModel>> LerTodosLogsFiltro(string query);
        void GravarLogs();
    }
}
