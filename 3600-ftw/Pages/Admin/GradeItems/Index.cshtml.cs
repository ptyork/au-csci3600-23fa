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
    public class IndexModel : PageModel
    {
        private readonly CSCI3600.Data.MyDataContext _context;

        public IndexModel(CSCI3600.Data.MyDataContext context)
        {
            _context = context;
        }

        public IList<GradeItem> GradeItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.GradeItems != null)
            {
                GradeItem = await _context.GradeItems
                .Include(g => g.GradeCategory).ToListAsync();
            }
        }
    }
}
