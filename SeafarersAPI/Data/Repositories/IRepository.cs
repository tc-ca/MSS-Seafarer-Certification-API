namespace SeafarersAPI.Data.Repositories
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> GetList(int startIndex, int amountToGet);
        int Save(T Entity);
        int Delete(T Entity);

    }
}
