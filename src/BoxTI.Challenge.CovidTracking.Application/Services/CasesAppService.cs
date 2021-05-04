using AutoMapper;
using BoxTI.Challenge.CovidTracking.Application.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Services.Base;
using BoxTI.Challenge.CovidTracking.Application.ViewModels;
using BoxTI.Challenge.CovidTracking.Domain.Entities;
using BoxTI.Challenge.CovidTracking.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Application.Services
{
    public class CasesAppService : BaseAppService, ICasesAppService
    {
        private readonly ICasesRepository _casesRepository;
        private readonly IMapper _mapper;
        public CasesAppService(ICasesRepository casesRepository, INotifier notifier, IMapper mapper) : base(notifier)
        {
            _casesRepository = casesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CasesViewModel>> GetAllCasesAsync()
        {
            var casesList = await _casesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CasesViewModel>>(casesList);
        }

        public async Task<CasesViewModel> GetCasesByCountryAsync(string country)
        {
            var cases = await _casesRepository.GetByCountryAsync(country);
            return _mapper.Map<CasesViewModel>(cases);
        }

        public async Task<IEnumerable<CasesViewModel>> GetOrderedCasesByTotalCases()
        {
            var casesList = await _casesRepository.OrderByTotalCasesAsync();
            return _mapper.Map<IEnumerable<CasesViewModel>>(casesList);
        }

        public async Task<bool> CreateAsync(CasesViewModel viewmodel)
        {
            var model = _mapper.Map<Cases>(viewmodel);
            _casesRepository.Add(model);

            return await _casesRepository.UnitOfWork.Commit();
        }

        public async Task<bool> UpdateAsync(CasesViewModel viewmodel)
        {
            var model = _mapper.Map<Cases>(viewmodel);
            _casesRepository.Add(model);

            return await _casesRepository.UnitOfWork.Commit();
        }

        public async Task<bool> InactivateCountryAsync(string country)
        {
            var model = await _casesRepository.GetByCountryAsync(country);
            model.Deactivate();

            _casesRepository.Update(model);

            return await _casesRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _casesRepository?.Dispose();
        }
    }
}
