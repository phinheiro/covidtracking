using AutoMapper;
using BoxTI.Challenge.CovidTracking.Domain.Entities;
using BoxTI.Challenge.CovidTracking.ExternalServices.ViewModels;

namespace BoxTI.Challenge.CovidTracking.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<CovidTrackingApiViewModel, Cases>().ConstructUsing(c =>
                new Cases(int.Parse(c.ActiveCases), c.Country, c.LastUpdate, c.NewCases,
                c.NewDeaths, int.Parse(c.TotalCases), int.Parse(c.TotalDeaths), int.Parse(c.TotalRecovered)));
        }
    }
}
