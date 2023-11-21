using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSCI3600.Data;

namespace CSCI3600.Pages_Admin_GradeCategories
{
    public class DeleteModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public DeleteModel(CSCI3600.Data.MyDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GradeCategory GradeCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.GradeCategories == null)
            {
                return NotFound();
            }

            var gradecategory = await _context.GradeCategories.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (gradecategory == null)
            {
                return NotFound();
            }
            else 
            {
                GradeCategory = gradecategory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.GradeCategories == null)
            {
                return NotFound();
            }
            var gradecategory = await _context.GradeCategories.FindAsync(id);

            if (gradecategory != null)
            {
                GradeCategory = gradecategory;
                _context.GradeCategories.Remove(GradeCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
