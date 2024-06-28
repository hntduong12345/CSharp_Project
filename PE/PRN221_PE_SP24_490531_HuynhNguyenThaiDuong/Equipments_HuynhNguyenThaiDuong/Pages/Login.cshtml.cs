using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Repo;
using System.ComponentModel.DataAnnotations;

namespace Equipments_HuynhNguyenThaiDuong.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;
        public LoginModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [BindProperty]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [BindProperty]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Password is Required.")]
        public string Pass { get; set; }

        public string ErrorMsg = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Account acc = _accountRepo.Login(Email, Pass);
            if (acc == null)
            {
                ErrorMsg = "You do not have permission to do this fucntion!";
                return Page();
            }
            else
            {
                if(acc.RoleId == 1 || acc.RoleId == 2)
                {
                    HttpContext.Session.SetInt32("Role", acc.RoleId.Value);

                    return RedirectToPage("/Equipments/Index");
                }
            }

            //Role manager and student
            return Page();
        }
    }
}


