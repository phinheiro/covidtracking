using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.API.Controllers.Base;
using BoxTI.Challenge.CovidTracking.API.Extensions;
using BoxTI.Challenge.CovidTracking.Application.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BoxTI.Challenge.CovidTracking.API.V1.Controllers
{
    [ApiKey]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CasesController : MainController
    {
        private readonly ICasesAppService _casesAppService;
        public CasesController(ICasesAppService casesAppService, INotifier notifier) : base(notifier)
        {
            _casesAppService = casesAppService;
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
        /// Salva um registro na base de dados
        /// </summary>
        /// <param name="viewmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveCases(CasesViewModel viewmodel)
        {
            var success = await _casesAppService.CreateAsync(viewmodel);
            if (success)
                return CustomResponse(new { message = "Registro salvo com sucesso." });

            return CustomResponse();
        }

        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="viewmodel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCases(CasesViewModel viewmodel)
        {
            var success = await _casesAppService.UpdateAsync(viewmodel);
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
    }
}