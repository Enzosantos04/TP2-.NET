using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TP2Razor.Models;

namespace TP2Razor.Pages.CountryManager.Exercicio06;

public class CreateCountryModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public Country? CreatedCountry { get; private set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Informe o nome do país.")]
        public string CountryName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o código do país.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "Use duas letras no código do país.")]
        public string CountryCode { get; set; } = string.Empty;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        CreatedCountry = new Country
        {
            CountryName = Input.CountryName,
            CountryCode = Input.CountryCode
        };

        return Page();
    }
}
