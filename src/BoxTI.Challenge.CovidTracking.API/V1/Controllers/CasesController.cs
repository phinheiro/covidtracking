using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.API.Controllers.Base;
using BoxTI.Challenge.CovidTracking.API.Extensions;
using BoxTI.Challenge.CovidTracking.Application.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using BoxTI.Challenge.CovidTracking.ExternalServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoxTI.Challenge.CovidTracking.API.V1.Controllers
{
    [ApiKey]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CasesController : MainController
    {
        private readonly ICasesAppService _casesAppService;
        private readonly ICovidTrackingService _covidTrackingService;
        public CasesController(ICasesAppService casesAppService, INotifier notifier, ICovidTrackingService covidTrackingService) : base(notifier)
        {
            _casesAppService = casesAppService;
            _covidTrackingService = covidTrackingService;
        }

        /// <summary>
        /// Retorna todos os os resultados existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCases()
        {
            var casesList = await _casesAppService.GetAllCasesAsync();
            return CustomResponse(casesList);
        }

        /// <summary>
        /// Retorna a lista ordenada decrescentemente pelo numero de casos ativos
        /// </summary>
        /// <returns></returns>
        [HttpGet("ordered-list")]
        public async Task<IActionResult> GetOrderedList()
        {
            var cases = await _casesAppService.GetOrderedCasesByTotalCases();
            return CustomResponse(cases);
        }

        /// <summary>
        /// Salva os registro na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("save")]
        public async Task<IActionResult> SaveCases()
        {
            var success = await _casesAppService.CreateAsync();
            if (success)
                return CustomResponse(new { message = "Registros salvos com sucesso." });

            return CustomResponse();
        }

        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("update/{country}")]
        public async Task<IActionResult> UpdateCases(string country)
        {
            var success = await _casesAppService.UpdateAsync(country);
            if (success)
                return CustomResponse(new { message = "Registro atualizado com sucesso." });

            return CustomResponse();
        }

        /// <summary>
        /// Inativa o registro de um país
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("inactivate/{country}")]
        public async Task<IActionResult> InactivateCountry(string country)
        {
            var success = await _casesAppService.InactivateCountryAsync(country);
            if (success)
                return CustomResponse(new { message = "Registro excluído com sucesso." });

            return CustomResponse();
        }

        /// <summary>
        /// Busca por país
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("{country}")]
        public async Task<IActionResult> GetByCountry(string country)
        {
            var content = await _covidTrackingService.GetByCountryAsync(country);
            return CustomResponse(content);
        }
    }
}