using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSCI3600.Data;

namespace CSCI3600.Pages_Admin_GradeItems
{
    public class DetailsModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public DetailsModel(CSCI3600.Data.MyDataContext context)
        {
            _context = context;
        }

      public GradeItem GradeItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.GradeItems == null)
            {
                return NotFound();
            }

            var gradeitem = await _context.GradeItems.FirstOrDefaultAsync(m => m.ItemId == id);
            if (gradeitem == null)
            {
                return NotFound();
            }
            else 
            {
                GradeItem = gradeitem;
            }
            return Page();
        }
    }
}
