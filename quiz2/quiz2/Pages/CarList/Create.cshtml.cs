using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quiz2.Areas.Identity.Data;
using quiz2.Model;

namespace quiz2.Pages.CarList
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;
        private readonly ApplicationDbContext _db;


        public CreateModel(ApplicationDbContext db, SignInManager<UserApplication> signInManager, UserManager<UserApplication> userManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [BindProperty]
        public Car Car { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Car.Creator = _userManager.GetUserName(User);
                await _db.Car.AddAsync(Car);
                await _db.SaveChangesAsync();
                
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
