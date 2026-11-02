using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2Razor.Pages.CityManager.Exercicio08;

public class CityDetailsModel : PageModel
{
    public string CityName { get; private set; } = string.Empty;

    public void OnGet(string cityName)
    {
        CityName = cityName;
    }
}
