using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace PEPRN231_SU24TrialTest_StudentCode_FE.Pages.WaterPainting
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string SearchByName { get; set; }

        [BindProperty]
        public int? SearchByNum { get; set; }

        [BindProperty]
        public int SearchMode { get; set; }
        public IList<WatercolorsPainting> WatercolorsPainting { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "2" && role != "3") return Forbid();
            await Init();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "2" && role != "3") return Forbid();
            await this.Init();
            return Page();
        }

        private string GetQuery()
        {

            if(this.SearchMode == 1)
            {

                if (!string.IsNullOrWhiteSpace(SearchByName)){
                    return string.Concat("&$filter=", "contains(PaintingAuthor,'", SearchByName,"')");
                }
            }

            if(this.SearchMode == 2)
            {
                if (SearchByNum.HasValue)
                {

                    return string.Concat("&$filter=", $"PublishYear Eq {SearchByNum}");
                }
            }

            return string.Empty;

        }

        private async Task Init()
        {
            var url = $"{Common.BaseURL}/WatercolorsPainting?$expand=Style{GetQuery()}";
            var response = await Common.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.WatercolorsPainting = JsonConvert.DeserializeObject<List<WatercolorsPainting>>(content) ?? new List<WatercolorsPainting>();
            }
        }
    }
}
