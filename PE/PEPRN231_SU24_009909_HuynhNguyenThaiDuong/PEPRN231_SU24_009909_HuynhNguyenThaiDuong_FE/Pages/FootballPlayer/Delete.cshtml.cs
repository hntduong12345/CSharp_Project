//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Newtonsoft.Json;
//using PEPRN231_SU24TrialTest_StudentFullname_FE.Utils;
//using System.Text.Json;

//namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages.WatercolorsPainting
//{
//    public class DeleteModel : PageModel
//    {
//        [BindProperty]
//        public Models.WatercolorsPainting Painting { get; set; } = default!;

//        [BindProperty]
//        public string Message { get; set; } = string.Empty;

//        public async Task<IActionResult> OnGetAsync(string? id)
//        {
//            var role = HttpContext.Session.GetString("Role");
//            if (role != "3") return Forbid();

//            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting/{id}?$expand=Style";
//            var response = await HttpRequestUtil.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
//            if (response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                Models.WatercolorsPainting data
//                    = JsonConvert.DeserializeObject<Models.WatercolorsPainting>(content) ??
//                                                new Models.WatercolorsPainting();
//                this.Painting = data;
//            }
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync(string? id)
//        {
//            var role = HttpContext.Session.GetString("Role");
//            if (role != "3") return Forbid();

//            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting/{this.Painting.PaintingId}";
//            var response = await HttpRequestUtil.SendRequestWithBody<Models.WatercolorsPainting>(this.Painting, url, HttpContext.Session.GetString("accessToken"), "Delete");
//            if (!response.IsSuccessStatusCode)
//            {
//                var content = await response.Content.ReadAsStringAsync();
//                this.Message = content;
//                return Page();
//            }
//            return RedirectToPage("./Index");
//        }
//    }
//}
