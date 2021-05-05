using System;
using BoxTI.Challenge.CovidTracking.Core.Entities;

namespace BoxTI.Challenge.CovidTracking.Domain.Entities
{
    public class Cases : Entity
    {
        public Cases(int activeCases, string country, DateTime lastUpdate, string newCases,
                     string newDeaths, int totalCases, int totalDeaths, int totalRecovered)
        {
            ActiveCases = activeCases;
            Country = country;
            LastUpdate = lastUpdate;
            NewCases = newCases;
            NewDeaths = newDeaths;
            TotalCases = totalCases;
            TotalDeaths = totalDeaths;
            TotalRecovered = totalRecovered;
            Active = true;
        }

        protected Cases() { }

        public int ActiveCases { get; private set; }
        public string Country { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public string NewCases { get; private set; }
        public string NewDeaths { get; private set; }
        public int TotalCases { get; private set; }
        public int TotalDeaths { get; private set; }
        public int TotalRecovered { get; private set; }
        public bool Active { get; private set; }

        public bool Deactivate() => Active = false;

        public void UpdateData(Cases newData)
        {
            ActiveCases = newData.ActiveCases;
            LastUpdate = newData.LastUpdate;
            NewCases = newData.NewCases;
            NewDeaths = newData.NewDeaths;
            TotalCases = newData.TotalCases;
            TotalDeaths = newData.TotalDeaths;
            TotalRecovered = newData.TotalRecovered;
        }
    }
}