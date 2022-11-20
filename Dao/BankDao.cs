using ExchangeRatesApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRatesApp.Dao
{
    public class BankDao : IBankDao
    {

        public string Create(Bank entity)
        {
            using (var context = new ExchangeRateContext())
            {
                context.Banks.Add(entity);
                context.SaveChanges();
                return entity.Name;
            }
        }

        public void Delete(string name)
        {
            using (var context = new ExchangeRateContext())
            {
                var bank = new Bank() { Name = name };
                context.Banks.Attach(bank);
                context.Banks.Remove(bank);
                context.SaveChanges();
            }
        }

        public IEnumerable<Bank> GetAll()
        {
            using (var context = new ExchangeRateContext())
            {
                return context.Banks.ToList();
            }
        }

        public Bank Read(string id)
        {
            using (var context = new ExchangeRateContext())
            {
                return context.Banks.FirstOrDefault(x => x.Name == id);
            }
        }

        public void Update(Bank entity)
        {
            throw new NotImplementedException();
        }
    }
}
