using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Eyeglass_ThaiDuong.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IStoreAccountRepo _storeAccountRepo;
        public LoginModel(IStoreAccountRepo storeAccountRepo)
        {
            _storeAccountRepo = storeAccountRepo;
        }

        [BindProperty]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required!")]
        public string Pass { get; set; }

        public string errorMsg = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StoreAccount acc = _storeAccountRepo.Login(Email, Pass);
            if (acc != null)
            {
                errorMsg = string.Empty;

                if(acc.Role == 1 || acc.Role == 2)
                {
                    //Save to session
                    HttpContext.Session.SetInt32("Role", acc.Role.Value);
                    return RedirectToPage("/EyeGlasses/Index");
                }
            }
            else
            {
                errorMsg = "You do not have permission to do this function!";
            }
            return Page();
        }
    }
}
