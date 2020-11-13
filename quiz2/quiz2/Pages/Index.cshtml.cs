using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using quiz2.Model;
using quiz2.Areas.Identity.Data;


namespace quiz2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;
        public IEnumerable<UserApplication> MyUser { get; private set; }

        public IndexModel(ApplicationDbContext db, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {

        }
    }
}
