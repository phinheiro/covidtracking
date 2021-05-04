using AutoMapper;
using BoxTI.Challenge.CovidTracking.Application.ViewModels;
using BoxTI.Challenge.CovidTracking.Domain.Entities;

namespace BoxTI.Challenge.CovidTracking.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<CasesViewModel, Cases>().ConstructUsing(c =>
                new Cases(c.ActiveCases, c.Country, c.LastUpdate, c.NewCases,
                c.NewDeaths, c.TotalCases, c.TotalDeaths, c.TotalRecovered));
        }
    }
}
