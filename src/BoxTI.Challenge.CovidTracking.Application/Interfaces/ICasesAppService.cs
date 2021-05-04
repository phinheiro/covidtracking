﻿using BoxTI.Challenge.CovidTracking.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Application.Interfaces
{
    public interface ICasesAppService : IDisposable
    {
        Task<IEnumerable<CasesViewModel>> GetAllCasesAsync();
        Task<CasesViewModel> GetCasesByCountryAsync(string country);
        Task<IEnumerable<CasesViewModel>> GetOrderedCasesByTotalCases();
        Task<bool> CreateAsync(CasesViewModel viewmodel);
        Task<bool> UpdateAsync(CasesViewModel viewmodel);
        Task<bool> InactivateCountryAsync(string country);

    }
}
