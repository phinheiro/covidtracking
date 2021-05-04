using AutoMapper;
using BoxTI.Challenge.CovidTracking.Application.ViewModels;
using BoxTI.Challenge.CovidTracking.Domain.Entities;

namespace BoxTI.Challenge.CovidTracking.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Cases, CasesViewModel>();
        }
    }
}
