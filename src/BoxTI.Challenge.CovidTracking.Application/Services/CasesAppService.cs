using AutoMapper;
using BoxTI.Challenge.CovidTracking.Application.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Services.Base;
using BoxTI.Challenge.CovidTracking.Application.ViewModels;
using BoxTI.Challenge.CovidTracking.Domain.Entities;
using BoxTI.Challenge.CovidTracking.Domain.Interfaces;
using BoxTI.Challenge.CovidTracking.ExternalServices.Interfaces;
using BoxTI.Challenge.CovidTracking.ExternalServices.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Application.Services
{
    public class CasesAppService : BaseAppService, ICasesAppService
    {
        private readonly ICasesRepository _casesRepository;
        private readonly ICovidTrackingService _covidTrackingService;
        private readonly IMapper _mapper;
        public CasesAppService(ICasesRepository casesRepository, 
                               INotifier notifier, 
                               IMapper mapper, 
                               ICovidTrackingService covidTrackingService) : base(notifier)
        {
            _casesRepository = casesRepository;
            _covidTrackingService = covidTrackingService;
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

        public async Task<bool> CreateAsync()
        {
            var casesList = new List<CovidTrackingApiViewModel>();
            string[] countries = { "Brazil", "Japan", "Netherlands", "Nigeria", "Australia", "World" };
            foreach (var country in countries)
            {
                if (!await _casesRepository.ExistData(country))
                {
                    var cases = await _covidTrackingService.GetByCountryAsync(country);
                    FormatValues(cases);
                    casesList.Add(cases);
                }
            }
            if(casesList.Count == 0)
            {
                Notify("Os registros já existem na base");
                return false;
            }
            var models = _mapper.Map<List<Cases>>(casesList);
            _casesRepository.Add(models);

            return await _casesRepository.UnitOfWork.Commit();
        }

        public async Task<bool> UpdateAsync(string country)
        {
            if (!await _casesRepository.ExistData(country))
            {
                Notify("Registro inexistente");
                return false;
            }

            var viewmodel = await _covidTrackingService.GetByCountryAsync(country);
            FormatValues(viewmodel);
            var model = _mapper.Map<Cases>(viewmodel);
            var dbModel = await _casesRepository.GetByCountryAsync(country);
            dbModel.UpdateData(model);

            _casesRepository.Update(dbModel);

            return await _casesRepository.UnitOfWork.Commit();
        }

        public async Task<bool> InactivateCountryAsync(string country)
        {
            var model = await _casesRepository.GetByCountryAsync(country);
            model.Deactivate();

            _casesRepository.Update(model);

            return await _casesRepository.UnitOfWork.Commit();
        }

        private static string RemoveMask(string maskedValue) =>
            maskedValue.Replace(",", "");

        private void FormatValues(CovidTrackingApiViewModel viewmodel)
        {
            viewmodel.ActiveCases = RemoveMask(viewmodel.ActiveCases);
            viewmodel.TotalCases = RemoveMask(viewmodel.TotalCases);
            viewmodel.TotalDeaths = RemoveMask(viewmodel.TotalDeaths);
            viewmodel.TotalRecovered = RemoveMask(viewmodel.TotalRecovered);
        }

        public void Dispose()
        {
            _casesRepository?.Dispose();
        }
    }
}
