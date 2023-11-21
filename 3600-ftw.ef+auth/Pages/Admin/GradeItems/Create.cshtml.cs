using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSCI3600.Data;

namespace CSCI3600.Pages_Admin_GradeItems
{
    public class CreateModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public CreateModel(CSCI3600.Data.MyDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GradeCategoryId"] = new SelectList(_context.GradeCategories, "CategoryId", "Name");
            return Page();
        }

        [BindProperty]
        public GradeItem GradeItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.GradeItems == null || GradeItem == null)
            {
                return Page();
            }

            _context.GradeItems.Add(GradeItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
