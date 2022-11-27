using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExchangeRatesApp.Dao;
using ExchangeRatesApp.Entites;

namespace ExchangeRatesApp.Pages.Banks
{
    public class CreateModel : PageModel
    {
        private readonly IBankDao _bankDao;

        public CreateModel(IBankDao bankDao)
        {
            _bankDao = bankDao;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bank Bank { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _bankDao.Create(Bank);

            return RedirectToPage("./Index");
        }
    }
}
