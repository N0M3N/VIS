using Models;
using System.Collections.Generic;

namespace Databse
{
    internal interface ICRUD<T> where T : BaseModel
    {
        IEnumerable<T> Select();
        T Select(int id);
        T Insert(T t);
        T Update(T t);
        bool Delete(int id);
    }
}
