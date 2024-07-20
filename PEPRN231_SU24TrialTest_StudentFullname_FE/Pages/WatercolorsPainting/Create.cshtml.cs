using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PEPRN231_SU24TrialTest_StudentFullname_FE.Utils;
using System.Text.Json;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages.WatercolorsPainting
{
    public class CreateModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            var res = await HttpRequestUtil.SendGetRequest($"{HttpRequestUtil.BaseURL}/api/Style/all", HttpContext.Session.GetString("accessToken"));
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var styles = JsonConvert.DeserializeObject<List<Models.Style>>(content) ?? new List<Models.Style>();
                ViewData["StyleId"] = new SelectList(styles, "StyleId", "StyleName");
            }
            return Page();
        }

        [BindProperty]
        public Models.WatercolorsPainting Painting { get; set; } = default!;

        public string ErrorMsg = string.Empty;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();
            ModelState.Remove("Message");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting";
            var response = await HttpRequestUtil.SendRequestWithBody<Models.WatercolorsPainting>(this.Painting, url, HttpContext.Session.GetString("accessToken"), "Post");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.ErrorMsg = content;
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
