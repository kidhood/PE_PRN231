using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PEPRN231_SU24TrialTest_StudentCode_FE.Pages.WaterPainting
{
    public class CreateModel : PageModel
    { 

        [BindProperty]
        public WatercolorsPainting WatercolorsPainting { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();

            var res = await Common.SendGetRequest($"{Common.BaseURL}/Style");
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var styles = JsonSerializer.Deserialize<List<Style>>(content) ?? new List<Style>();
                ViewData["StyleId"] = new SelectList(styles, "StyleId", "StyleName");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();
            ModelState.Remove("Message");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var url = $"{Common.BaseURL}/WatercolorsPainting";
            var response = await Common.SendRequestWithBody<WatercolorsPainting>(this.WatercolorsPainting, url, HttpContext.Session.GetString("accessToken"), "Post");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
