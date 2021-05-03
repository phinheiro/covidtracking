using System;
using System.ComponentModel.DataAnnotations;

namespace BoxTI.Challenge.CovidTracking.Application.ViewModels
{
    public class CasesViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ActiveCases { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O valor do campo {0} não pode ser maior que {1}")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime LastUpdate { get; set; }

        [StringLength(20, ErrorMessage = "O valor do campo {0} não pode ser maior que {1}")]
        public string NewCases { get; set; }

        [StringLength(20, ErrorMessage = "O valor do campo {0} não pode ser maior que {1}")]
        public string NewDeaths { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TotalCases { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TotalDeaths { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(1, ErrorMessage = "O valor do campo {0} não pode ser menor que {1}")]
        public int TotalRecovered { get; set; }
    }
}