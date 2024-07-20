using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PEPRN231_SU24TrialTest_StudentFullname_FE.Utils;
using System.Reflection;
using System.Text.Json;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages.WatercolorsPainting
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Models.WatercolorsPainting Painting { get; set; } = default!;

        [BindProperty]
        public string Message { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();

            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting/{id}?$expand=Style";
            var response = await HttpRequestUtil.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var WatercolorsPaintings = JsonSerializer.Deserialize<List<Models.WatercolorsPainting>>(content) ?? new List<Models.WatercolorsPainting>();
                this.Painting = WatercolorsPaintings.FirstOrDefault();
            }
            var res = await HttpRequestUtil.SendGetRequest($"{HttpRequestUtil.BaseURL}/api/Style/all");
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var styles = JsonSerializer.Deserialize<List<Models.Style>>(content) ?? new List<Models.Style>();
                ViewData["StyleId"] = new SelectList(styles, "StyleId", "StyleName");
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();
            ModelState.Remove("Message");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting/{this.Painting.PaintingId}";
            var response = await HttpRequestUtil.SendRequestWithBody<Models.WatercolorsPainting>(this.Painting, url, HttpContext.Session.GetString("accessToken"), "Put");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.Message = content;
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
