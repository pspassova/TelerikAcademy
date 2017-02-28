using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Services.Contracts
{
    public interface IGenericService<T> where T : class
    {
        NorthwindEntities Context { get; }

        IEnumerable<T> GetAll();
    }
}
