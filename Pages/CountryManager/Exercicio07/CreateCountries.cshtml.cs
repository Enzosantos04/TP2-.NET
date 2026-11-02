using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TP2Razor.Models;

namespace TP2Razor.Pages.CountryManager.Exercicio07;

public class CreateCountriesModel : PageModel
{
    [BindProperty]
    public List<InputModel> Inputs { get; set; } = new();

    public List<Country> Countries { get; private set; } = new();

    public class InputModel
    {
        [Required(ErrorMessage = "Informe o nome do país.")]
        public string CountryName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o código do país.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O código deve ter exatamente 2 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "Use duas letras no código do país.")]
        public string CountryCode { get; set; } = string.Empty;
    }

    public void OnGet()
    {
        for (int i = 0; i < 5; i++)
            Inputs.Add(new InputModel());
    }

    public IActionResult OnPost()
    {
        if (Inputs.Count != 5)
        {
            ModelState.AddModelError(string.Empty, "Envie exatamente cinco países.");
            Inputs = Inputs.Take(5).ToList();
            while (Inputs.Count < 5)
                Inputs.Add(new InputModel());
        }

        if (!ModelState.IsValid)
            return Page();

        foreach (var input in Inputs)
        {
            Countries.Add(new Country
            {
                CountryName = input.CountryName,
                CountryCode = input.CountryCode
            });
        }

        return Page();
    }
}
