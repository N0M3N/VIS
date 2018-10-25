using Models;
using System.Collections.Generic;

namespace Databse
{
    internal interface ICRUD<T> where T : BaseModel
    {
        IEnumerable<T> Select();
        T Select(int id);
        int Insert(T t);
        int Update(T t);
        int Delete(int id);
    }
}
