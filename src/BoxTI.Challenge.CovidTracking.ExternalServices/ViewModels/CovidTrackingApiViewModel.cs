using System;
using Newtonsoft.Json;

namespace BoxTI.Challenge.CovidTracking.ExternalServices.ViewModels
{
    public class CovidTrackingApiViewModel
    {
        [JsonProperty("Active Cases_text")]
        public string ActiveCases { get; set; }

        [JsonProperty("Country_text")]
        public string Country { get; set; }

        [JsonProperty("Last Update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("New Cases_text")]
        public string NewCases { get; set; }

        [JsonProperty("New Deaths_text")]
        public string NewDeaths { get; set; }

        [JsonProperty("Total Cases_text")]
        public string TotalCases { get; set; }

        [JsonProperty("Total Deaths_text")]
        public string TotalDeaths { get; set; }

        [JsonProperty("Total Recovered_text")]
        public string TotalRecovered { get; set; }
    }
}