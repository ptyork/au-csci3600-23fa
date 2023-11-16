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
    public class IndexModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public IndexModel(CSCI3600.Data.MyDataContext context)
        {
            _context = context;
        }

        public IList<GradeCategory> GradeCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GradeCategories != null)
            {
                GradeCategory = await _context.GradeCategories.ToListAsync();
            }
        }
    }
}
