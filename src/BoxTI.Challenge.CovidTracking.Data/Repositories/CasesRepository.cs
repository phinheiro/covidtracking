using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.Core.Data;
using BoxTI.Challenge.CovidTracking.Domain.Entities;
using BoxTI.Challenge.CovidTracking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.Challenge.CovidTracking.Data.Repositories
{
    public class CasesRepository : ICasesRepository
    {
        private readonly CTContext _context;
        public CasesRepository(CTContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;
        
        public async Task<IEnumerable<Cases>> GetAllAsync() =>
            await _context.Cases.AsNoTracking().ToListAsync();

        public async Task<Cases> GetByCountryAsync(string country) =>
            await _context.Cases.FirstOrDefaultAsync(e => e.Country == country);

        public async Task<IEnumerable<Cases>> OrderByTotalCasesAsync() =>
            await _context.Cases.AsNoTracking().OrderByDescending(e => e.TotalCases).ToListAsync();

        public void Add(Cases caseData) => _context.Add(caseData);

        public void Update(Cases caseData) => _context.Update(caseData);

        public void Dispose() => _context?.Dispose();
    }
}