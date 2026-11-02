using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2Razor.Pages.Notes.Exercicio11;

public class ReadNotesModel : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<ReadNotesModel> _logger;

    public ReadNotesModel(IWebHostEnvironment environment, ILogger<ReadNotesModel> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public List<string> FileNames { get; private set; } = new();
    public string? SelectedFileName { get; private set; }
    public string? NoteContent { get; private set; }

    public async Task<IActionResult> OnGetAsync(string? fileName)
    {
        try
        {
            var directory = Path.Combine(_environment.WebRootPath, "files");
            Directory.CreateDirectory(directory);

            FileNames = new DirectoryInfo(directory).GetFiles("*.txt")
                .Where(file => !file.Attributes.HasFlag(FileAttributes.ReparsePoint))
                .Select(file => file.Name)
                .OrderByDescending(name => name)
                .ToList();

            if (fileName == null)
                return Page();

            // Só permite ler nomes presentes na pasta, impedindo caminhos como ../.
            if (!FileNames.Contains(fileName))
                return NotFound();

            NoteContent = await System.IO.File.ReadAllTextAsync(Path.Combine(directory, fileName));
            SelectedFileName = fileName;
        }
        catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
        {
            _logger.LogError(exception, "Erro ao ler notas.");
            ModelState.AddModelError(string.Empty, "Não foi possível ler as notas. Tente novamente.");
        }

        return Page();
    }
}
