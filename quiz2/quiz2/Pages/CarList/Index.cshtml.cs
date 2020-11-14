using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quiz2.Model;

namespace quiz2.Pages.CarList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Car> Cars { get; set; }
        public async Task OnGet()
        {
            Cars = await _db.Car.ToListAsync();
        }

        [Authorize]
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var car = await _db.Car.FindAsync(id);
            if(car == null)
            {
                return NotFound();
            }
            _db.Car.Remove(car);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
