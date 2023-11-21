using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSCI3600.Data;

namespace CSCI3600.Pages_Admin_GradeItems
{
    public class EditModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public EditModel(CSCI3600.Data.MyDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GradeItem GradeItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.GradeItems == null)
            {
                return NotFound();
            }

            var gradeitem =  await _context.GradeItems.FirstOrDefaultAsync(m => m.ItemId == id);
            if (gradeitem == null)
            {
                return NotFound();
            }
            GradeItem = gradeitem;
           ViewData["GradeCategoryId"] = new SelectList(_context.GradeCategories, "CategoryId", "Name");
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

            _context.Attach(GradeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeItemExists(GradeItem.ItemId))
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

        private bool GradeItemExists(Guid id)
        {
          return (_context.GradeItems?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
