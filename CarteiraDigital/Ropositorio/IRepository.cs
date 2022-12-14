using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarteiraDigital.Ropositorio
{
    public interface IRepository<T>
    {
        Task Add(T item);
        Task Remove(int id);
        Task Update(T item);
        Task<T> FindByID(int id);
        IEnumerable<T> FindAll();
    }

}
