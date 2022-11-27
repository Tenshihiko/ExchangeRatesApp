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
    public class DetailsModel : PageModel
    {
        private readonly IBankDao _bankDao;

        public DetailsModel(IBankDao bankDao)
        {
            _bankDao = bankDao;
        }

        public Bank Bank { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var bank = _bankDao.Read(id);
            if (bank == null)
            {
                return NotFound();
            }
            else 
            {
                Bank = bank;
            }
            return Page();
        }
    }
}
