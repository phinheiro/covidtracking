using System;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.ExternalServices.ViewModels;

namespace BoxTI.Challenge.CovidTracking.ExternalServices.Interfaces
{
    public interface ICovidTrackingService
    {
        Task<CovidTrackingApiViewModel> GetByCountry(string country);
    }
}