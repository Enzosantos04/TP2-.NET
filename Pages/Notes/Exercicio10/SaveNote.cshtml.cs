using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TP2Razor.Pages.Notes.Exercicio10;

public class SaveNoteModel : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<SaveNoteModel> _logger;

    public SaveNoteModel(IWebHostEnvironment environment, ILogger<SaveNoteModel> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string? FileName { get; private set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Escreva o texto da nota.")]
        [StringLength(10000, ErrorMessage = "A nota deve ter no máximo 10000 caracteres.")]
        public string Content { get; set; } = string.Empty;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            var directory = Path.Combine(_environment.WebRootPath, "files");
            Directory.CreateDirectory(directory);
            var fileName = $"note-{DateTime.UtcNow:yyyyMMddHHmmssfffffff}.txt";
            var path = Path.Combine(directory, fileName);

            // CreateNew evita sobrescrever uma nota existente.
            await using (var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            await using (var writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(Input.Content);
            }

            FileName = fileName;
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
        {
            _logger.LogError(exception, "Erro ao salvar nota.");
            ModelState.AddModelError(string.Empty, "Não foi possível salvar a nota. Tente novamente.");
        }

        return Page();
    }
}
