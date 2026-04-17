using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Nome { get; set; }

    public void OnPost()
    {
        
    }


}