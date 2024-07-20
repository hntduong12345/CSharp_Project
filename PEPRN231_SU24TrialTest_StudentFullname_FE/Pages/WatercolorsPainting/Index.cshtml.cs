using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PEPRN231_SU24TrialTest_StudentFullname_FE.Utils;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages.WatercolorsPainting
{
    public class IndexModel : PageModel
    {
        public IList<Models.WatercolorsPainting> Painting { get; set; } = default!;

        //Search
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public async Task OnGetAsync()
        {
            var url = $"{HttpRequestUtil.BaseURL}/odata/WatercolorsPainting?$expand=Style";
            var response = await HttpRequestUtil.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.Painting = JsonConvert.DeserializeObject<List<Models.WatercolorsPainting>>(content) ?? new List<Models.WatercolorsPainting>();
            }
        }

        public async Task OnPostAsync()
        {
            var url = $"{HttpRequestUtil.BaseURL}/WatercolorsPainting/search?searchValue={SearchValue}";
            var response = await HttpRequestUtil.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.Painting = JsonConvert.DeserializeObject<List<Models.WatercolorsPainting>>(content) ?? new List<Models.WatercolorsPainting>();
            }
        }
    }
}
