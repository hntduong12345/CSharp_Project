using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Newtonsoft.Json;
using PEPRN231_SU24_009909_HuynhNguyenThaiDuong_FE;
using PEPRN231_SU24TrialTest_StudentFullname_FE.Models;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Pages.WatercolorsPainting
{
    public class IndexModel : PageModel
    {
        public IList<FootballPlayer> Player { get; set; } = default!;

        //Search
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue2 { get; set; }

        public async Task OnGetAsync()
        {
            var url = $"{HttpRequestUtil.BaseURL}/odata/FootballPlayer?$expand=FootballClub";
            var response = await HttpRequestUtil.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                OdataResponse<List<FootballPlayer>> data = JsonConvert.DeserializeObject<OdataResponse<List<FootballPlayer>>>(content) ??
                                                                                 new OdataResponse<List<FootballPlayer>>();

                this.Player = data.Value;
            }
        }

        public async Task OnPostAsync()
        {
            SearchDTO value = new SearchDTO { Achivement = SearchValue, Nomination = SearchValue2 };
            var url = $"{HttpRequestUtil.BaseURL}/FootballPlayer/search?searchValue={SearchValue}";
            var response = await HttpRequestUtil.SendRequestWithBody(value, url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.Player = JsonConvert.DeserializeObject<List<FootballPlayer>>(content) ?? new List<FootballPlayer>();
            }
        }
    }
}
