using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quiz2.Model;
using Microsoft.AspNetCore.Identity;
using quiz2.Areas.Identity.Data;

namespace quiz2.Pages.CarList
{
    public class EditModel : PageModel
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db, SignInManager<UserApplication> signInManager, UserManager<UserApplication> userManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
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
                if (_userManager.GetUserName(User) == CarFromDb.Creator)
                {
                    CarFromDb.Name = Car.Name;
                    CarFromDb.Owner = Car.Owner;
                    CarFromDb.RegisNum = Car.RegisNum;
                }
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
