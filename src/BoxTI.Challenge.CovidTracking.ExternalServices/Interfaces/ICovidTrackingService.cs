using System.Collections.Generic;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.ExternalServices.ViewModels;

namespace BoxTI.Challenge.CovidTracking.ExternalServices.Interfaces
{
    public interface ICovidTrackingService
    {
        Task<CovidTrackingApiViewModel> GetByCountryAsync(string country);
        Task<IEnumerable<CovidTrackingApiViewModel>> GetAllAsync();
    }
}