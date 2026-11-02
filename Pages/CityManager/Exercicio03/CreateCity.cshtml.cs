using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TP2Razor.Pages.CityManager.Exercicio03;

public class CreateCityModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string? Message { get; private set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Informe o nome da cidade.")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter pelo menos 3 caracteres.")]
        public string CityName { get; set; } = string.Empty;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        Message = $"Cidade recebida: {Input.CityName}";
        return Page();
    }
}
