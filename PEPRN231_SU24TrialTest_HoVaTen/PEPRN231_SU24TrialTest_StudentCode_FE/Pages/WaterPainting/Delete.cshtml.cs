using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            //if (id == null || _context.WatercolorsPaintings == null)
            //{
            //    return NotFound();
            //}

            //var watercolorspainting = await _context.WatercolorsPaintings.FirstOrDefaultAsync(m => m.PaintingId == id);

            //if (watercolorspainting == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    WatercolorsPainting = watercolorspainting;
            //}
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            //if (id == null || _context.WatercolorsPaintings == null)
            //{
            //    return NotFound();
            //}
            //var watercolorspainting = await _context.WatercolorsPaintings.FindAsync(id);

            //if (watercolorspainting != null)
            //{
            //    WatercolorsPainting = watercolorspainting;
            //    _context.WatercolorsPaintings.Remove(WatercolorsPainting);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}
