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
        Task<IEnumerable<Cases>> OrderByTotalCasesAsync();
        void Add(Cases caseData);
        void Update(Cases caseData);
    }
}