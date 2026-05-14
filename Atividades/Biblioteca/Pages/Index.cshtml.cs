using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Biblioteca.Pages;

public class IndexModel : PageModel
{
    // Mantemos o logger que o .NET criou e adicionamos o nosso contexto do banco
    private readonly ILogger<IndexModel> _logger;
    private readonly AppDbContext _context;

    // Ajustamos o construtor para receber AMBOS: o logger e o banco de dados
    public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Propriedade que vai receber os dados do formulário HTML via Model Binding
    [BindProperty]
    public Obra NovaObra { get; set; }

    public List<Obra> ListaDeObras { get; set; }

    public void OnGet()
    {
        ListaDeObras = _context.Obras.ToList();
    }

    // Método que lida com o envio do formulário (Botão Salvar)
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Tentativa de cadastro com dados inválidos.");
            return Page(); 
        }

        // Salva no SQLite
        _context.Obras.Add(NovaObra);
        _context.SaveChanges();

        _logger.LogInformation($"Novo anime/série salvo com sucesso: {NovaObra.Titulo}");

        return RedirectToPage();
    }

    public IActionResult OnPostDeletar(int id)
    {
        // 1. Busca a obra no banco pelo ID
        var obra = _context.Obras.Find(id);

        if (obra != null)
        {
            // 2. Remove a obra do rastreador do EF
            _context.Obras.Remove(obra);
            
            // 3. Salva a alteração definitivamente no SQLite
            _context.SaveChanges();
        }

        return RedirectToPage();
    }

    public IActionResult OnPostAtualizar(int id, int novaTemporada, int novoEpisodio)
    {
        var obra = _context.Obras.Find(id);
        if (obra != null)
        {
            obra.Temporada = novaTemporada;
            obra.UltimoEpisodio = novoEpisodio;

            _context.SaveChanges();
        }
        return RedirectToPage();
    }
}
