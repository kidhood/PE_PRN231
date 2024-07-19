using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace PEPRN231_SU24TrialTest_StudentCode_FE.Pages.WaterPainting
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
      public WatercolorsPainting WatercolorsPainting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();

            var url = $"{Common.BaseURL}/WatercolorsPainting?$expand=Style&$filter=PaintingId Eq '{id}'";
            var response = await Common.SendGetRequest(url, HttpContext.Session.GetString("accessToken"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var WatercolorsPaintings = JsonSerializer.Deserialize<List<WatercolorsPainting>>(content) ?? new List<WatercolorsPainting>();
                this.WatercolorsPainting = WatercolorsPaintings.FirstOrDefault();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();

            var url = $"{Common.BaseURL}/WatercolorsPainting/{this.WatercolorsPainting.PaintingId}";
            var response = await Common.SendRequestWithBody<WatercolorsPainting>(null, url, HttpContext.Session.GetString("accessToken"), "Delete");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
