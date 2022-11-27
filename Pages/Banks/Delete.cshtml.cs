using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExchangeRatesApp.Dao;
using ExchangeRatesApp.Entites;

namespace ExchangeRatesApp.Pages.Banks
{
    public class DeleteModel : PageModel
    {
        private readonly IBankDao _bankDao;

        public DeleteModel(IBankDao bankDao)
        {
            _bankDao = bankDao;
        }

        [BindProperty]
      public Bank Bank { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _bankDao.Delete(id);    
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _bankDao.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
