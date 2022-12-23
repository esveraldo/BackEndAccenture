using AutoMapper;
using Log.Accenture.Application.ViewModels.Log;
using Log.Accenture.Domain.Entities;

namespace Log.Accenture.Application.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<LogSystem, LogSystemViewModel>();
        }
    }
}
