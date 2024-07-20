using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PEPRN231_SU24TrialTest_StudentFullname_FE.Utils;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required!")]
        public string UserEmail { get; set; }

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

            var response = await HttpRequestUtil.SendRequestWithBody(
                new
                {
                    Email = UserEmail,
                    Password = Pass
                }, "/api/UserAccount/login");

            if (response.IsSuccessStatusCode)
            {
                var accessToken = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("accessToken", accessToken.ToString());

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(accessToken.ToString());
                var tokenS = jsonToken as JwtSecurityToken;
                var role = tokenS.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                if (role != null)
                {
                    if(role.Equals("1") || role.Equals("4"))
                    {
                        errorMsg = "You are not allowed to access this function!";
                        return Page();
                    }

                    HttpContext.Session.SetString("Role", role);
                    return RedirectToPage("/WatercolorsPainting/Index");
                }
            }

            errorMsg = "Incorrect Email or Password";
            return Page();
        }
    }
}
