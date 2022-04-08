using System.Collections.Generic;
using Task5.Entites;

namespace Task5.Services
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T Get(int id);
        List<T> GetAll();
    } 
}