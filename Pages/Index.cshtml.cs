using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Xml;
using Microsoft.Extensions.Configuration;


namespace ExchangeRatesApp.Pages
{

    public class IndexModel : PageModel
    {
        public Bank[] Banks { get; set; }

        private readonly ILogger<IndexModel> _logger;

        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public enum SelectBy
        {
            None = 0,
            Css = 1,
            XPath = 2,
        }

        public class Bank
        {


            public string? Name { get; set; }
            public string? Url { get; set; }
            public string? Selector { get; set; }
            public bool Reverse { get; set; }
            public int Timeout { get; set; }
            public SelectBy By { get; set; }

            public decimal Rate { get; set; }
        }

        public void OnGet()
        {
            Banks = _configuration.GetSection("Banks").Get<Bank[]>();

            foreach (var bank in Banks)
            {
                bank.Rate = GetRate(bank.Url, bank.Selector, bank.By, bank.Timeout, bank.Reverse);
            }

        }

        private static decimal GetRate(string url, string selector, SelectBy selectBy = SelectBy.Css, int timeout = 1000, bool reverse = false)
        {
            decimal value;
            ChromeOptions opt = new ChromeOptions();
            opt.PageLoadStrategy = PageLoadStrategy.None;
            using (var webDriver = new ChromeDriver(opt))
            {
                webDriver.Url = url;

                var by = selectBy == SelectBy.Css ? By.CssSelector(selector)
                     : selectBy == SelectBy.XPath ? By.XPath(selector)
                     : By.CssSelector(selector);
                IWebElement elem = null;
                string valueStr = null;

                do
                {
                    try
                    {
                        elem = webDriver.FindElement(by);
                        valueStr = elem.GetAttribute("innerText");
                    }
                    catch (Exception ex)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                } while (string.IsNullOrEmpty(valueStr));




                value = Decimal.TryParse(valueStr.Replace('.', ','), out value) ?
                    reverse ? 1 / value : value : 0;

                webDriver.Close();
            }

            return value;
        }
    }
}
