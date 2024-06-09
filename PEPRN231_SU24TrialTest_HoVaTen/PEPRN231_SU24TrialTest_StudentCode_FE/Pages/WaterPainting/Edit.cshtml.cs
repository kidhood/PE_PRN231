using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PEPRN231_SU24TrialTest_StudentCode_FE.Pages.WaterPainting
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public WatercolorsPainting WatercolorsPainting { get; set; } = default!;

        [BindProperty]
        public string Message { get; set; } = string.Empty;


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
            var res = await Common.SendGetRequest($"{Common.BaseURL}/Style");
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var styles = JsonSerializer.Deserialize<List<Style>>(content) ?? new List<Style>();
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

            var url = $"{Common.BaseURL}/WatercolorsPainting/{this.WatercolorsPainting.PaintingId}";
            var response = await Common.SendRequestWithBody<WatercolorsPainting>(this.WatercolorsPainting, url, HttpContext.Session.GetString("accessToken"), "Put");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                this.Message = content;
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
