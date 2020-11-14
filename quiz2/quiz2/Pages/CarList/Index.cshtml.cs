using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using quiz2.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quiz2.Model;

namespace quiz2.Pages.CarList
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db, SignInManager<UserApplication> signInManager, UserManager<UserApplication> userManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IEnumerable<Car> Cars { get; set; }
        public async Task OnGet()
        {
            Cars = await _db.Car.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var car = await _db.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            if(car.Creator == _userManager.GetUserName(User))
            {
                _db.Car.Remove(car);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
