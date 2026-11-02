using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2Razor.Pages.CityManager.Exercicio02;

public class CreateCityModel : PageModel
{
    public string? Message { get; private set; }

    public void OnPost(string cityName)
    {
        Message = $"Cidade recebida pelo handler: {cityName}";
    }
}
