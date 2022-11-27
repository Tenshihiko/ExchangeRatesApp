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
    public class IndexModel : PageModel
    {
        private readonly IBankDao _bankDao;

        public IndexModel(IBankDao bankDao)
        {
            _bankDao = bankDao;
        }

        public IList<Bank> Bank { get;set; } = default!;

        public void OnGet()
        {
            Bank = _bankDao.GetAll().ToList();
        }
    }
}
