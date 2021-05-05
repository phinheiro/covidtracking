using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.Core.Data;
using BoxTI.Challenge.CovidTracking.Domain.Entities;

namespace BoxTI.Challenge.CovidTracking.Domain.Interfaces
{
    public interface ICasesRepository : IRepository<Cases>
    {
        Task<IEnumerable<Cases>> GetAllAsync();
        Task<Cases> GetByCountryAsync(string country);
        Task<bool> ExistData(string country);
        Task<IEnumerable<Cases>> OrderByTotalCasesAsync();
        void Add(List<Cases> caseData);
        void Update(Cases caseData);
    }
}