using System.ComponentModel.DataAnnotations;

namespace ExchangeRatesApp.Entites
{
    public class Bank
    {
        [Key]
        public string Name { get; set; }
        public string Url { get; set; }
        public string Selector { get; set; }
        public bool Reverse { get; set; } = false;
        public int? Timeout { get; set; }
        public SelectBy? By { get; set; }

        public decimal? Rate { get; set; }
    }
}
