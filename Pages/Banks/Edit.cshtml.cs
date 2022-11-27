using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExchangeRatesApp.Dao;
using ExchangeRatesApp.Entites;

namespace ExchangeRatesApp.Pages.Banks
{
    public class EditModel : PageModel
    {
        private readonly IBankDao _bankDao;

        public EditModel(IBankDao bankDao)
        {
            _bankDao = bankDao;
        }
        [BindProperty]
        public Bank Bank { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank =  _bankDao.Read(id);
            if (bank == null)
            {
                return NotFound();
            }
            Bank = bank;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }            

            try
            {
                _bankDao.Update(Bank);  
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(Bank.Name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BankExists(string id)
        {
            return _bankDao.Read(id) != null;
        }
    }
}
