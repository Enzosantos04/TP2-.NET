using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2Razor.Pages.CityManager.Exercicio01;

public class CreateCityModel : PageModel
{
    [BindProperty]
    public string CityName { get; set; } = string.Empty;

    public bool Submitted { get; private set; }

    public void OnPost()
    {
        Submitted = true;
    }
}
