using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingDataAccess.Repository
{
    public interface IRepository<T>
    {
        bool Insert(T T);
        bool Delete(long Id);
        bool Update(T T);
        List<T> GetAll();
        T GetItem(long Id);
    }
}
