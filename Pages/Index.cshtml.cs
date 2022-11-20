using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Xml;
using Microsoft.Extensions.Configuration;
using ExchangeRatesApp.Entites;
using ExchangeRatesApp.Dao;

namespace ExchangeRatesApp.Pages
{

    public class IndexModel : PageModel
    {
        public IEnumerable<Bank> Banks { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IBankDao _bankDao;

        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IBankDao bankDao)
        {
            _logger = logger;
            _configuration = configuration;
            _bankDao = bankDao;
        }
        

       

        public void OnGet()
        {            
            Banks = _bankDao.GetAll();

            foreach (var bank in Banks)
            {
                bank.Rate = BankSiteDao.GetRate(bank.Url, bank.Selector, bank.By, bank.Timeout, bank.Reverse);
            }

        }
    }
}
