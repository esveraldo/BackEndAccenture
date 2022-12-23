using AutoMapper;
using Log.Accenture.Application.ViewModels.Log;
using Log.Accenture.Domain.Entities;

namespace Log.Accenture.Application.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<LogSystemViewModel, LogSystem>();
        }
    }
}
