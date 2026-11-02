using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2Razor.Pages.CityManager.Exercicio09;

public class CitiesModel : PageModel
{
    public List<string> Cities { get; } = ["Rio", "São Paulo", "Brasília"];
}
