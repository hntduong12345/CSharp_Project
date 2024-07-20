using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PEPRN231_SU24TrialTest_StudentFullname_FE.Utils;
using System.Text.Json;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages.WatercolorsPainting
{
    public class DeleteModel : PageModel
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();

            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting/{this.Painting.PaintingId}";
            var response = await HttpRequestUtil.SendRequestWithBody<Models.WatercolorsPainting>(this.Painting, url, HttpContext.Session.GetString("accessToken"), "Delete");
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
