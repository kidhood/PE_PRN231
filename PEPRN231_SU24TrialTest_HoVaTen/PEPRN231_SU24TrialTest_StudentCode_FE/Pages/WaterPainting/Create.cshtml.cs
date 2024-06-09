using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult OnGet()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "3") return Forbid();
            //ViewData["StyleId"] = new SelectList(_context.Styles, "StyleId", "StyleId");
            //    return Page();
            //}


            //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
            //public async Task<IActionResult> OnPostAsync()
            //{
            //  if (!ModelState.IsValid || _context.WatercolorsPaintings == null || WatercolorsPainting == null)
            //    {
            //        return Page();
            //    }

            //    _context.WatercolorsPaintings.Add(WatercolorsPainting);
            //    await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
