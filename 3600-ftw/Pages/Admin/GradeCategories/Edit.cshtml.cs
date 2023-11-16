using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSCI3600.Data;

namespace CSCI3600.Pages_Admin_GradeCategories
{
    public class EditModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public EditModel(CSCI3600.Data.MyDataContext context)
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

            var gradecategory =  await _context.GradeCategories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (gradecategory == null)
            {
                return NotFound();
            }
            GradeCategory = gradecategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GradeCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeCategoryExists(GradeCategory.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GradeCategoryExists(Guid id)
        {
          return (_context.GradeCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
