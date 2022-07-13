//using API_Back.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WEB_Front.Pages.Contact
{
    public class IndexModel : PageModel
    {
       
        public async Task<IActionResult> OnGetAsync()
        {
            
            return Page();
        }



        
        public async Task<IActionResult> OnPost()
        {
            
            return Page();
        }
    }
}
