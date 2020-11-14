using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quiz2.Model;

namespace quiz2.Pages.CarList
{
    [Authorize]
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Car Car { get; set; }
        public async Task OnGetAsync(int id)
        {
            Car = await _db.Car.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var CarFromDb = await _db.Car.FindAsync(Car.Id);
                CarFromDb.Name = Car.Name;
                CarFromDb.Owner = Car.Owner;
                CarFromDb.RegisNum = Car.RegisNum;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
