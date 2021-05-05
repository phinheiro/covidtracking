using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.ExternalServices.Interfaces;
using BoxTI.Challenge.CovidTracking.ExternalServices.ViewModels;
using Newtonsoft.Json;

namespace BoxTI.Challenge.CovidTracking.ExternalServices.Services
{
    public class CovidTrackingService : ICovidTrackingService
    {
        private readonly string _baseUrl = " https://covid-19-tracking.p.rapidapi.com";

        public async Task<CovidTrackingApiViewModel> GetByCountryAsync(string country)
        {
            var action = $"{_baseUrl}/v1/{country}";

            var response = await ExecuteRequest(action);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CovidTrackingApiViewModel>(responseBody);
        }

        public async Task<IEnumerable<CovidTrackingApiViewModel>> GetAllAsync()
        {
            var action = $"{_baseUrl}/v1";

            var response = await ExecuteRequest(action);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<CovidTrackingApiViewModel>>(responseBody);
        }

        private async Task<HttpResponseMessage> ExecuteRequest(string action)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", CovidTrackingApiSettings.CTApiKey);
                httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", CovidTrackingApiSettings.CTApiHost);

                return await httpClient.GetAsync(action);
            }
        }
    }
}