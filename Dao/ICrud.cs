namespace ExchangeRatesApp.Dao
{
    public interface ICrud<T, I>
    {
        IEnumerable<T> GetAll();
        I Create(T entity);
        T Read(I id);
        void Update(T entity);
        void Delete(I id);
    }
}
