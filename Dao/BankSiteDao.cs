using ExchangeRatesApp.Entites;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExchangeRatesApp.Dao
{
    internal class BankSiteDao
    {

        public static decimal GetRate(string url, string selector, SelectBy selectBy = SelectBy.Css, int timeout = 1000, bool reverse = false)
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
                    catch (Exception)
                    {
                        Thread.Sleep(1000);
                    }
                } while (string.IsNullOrEmpty(valueStr));

                value = decimal.TryParse(valueStr.Replace('.', ','), out value) ?
                    reverse ? 1 / value : value : 0;

                webDriver.Close();
            }

            return value;
        }
    }
}