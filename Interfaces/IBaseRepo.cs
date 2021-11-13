using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Server_App.Interfaces
{
    public interface IBaseRepo<T> where T: class
    {
        Task<T> Get(string url, int id);
        Task<IList<T>> GetAll(string url);

        Task<bool> Create(string url, T tmp);

        Task<bool> Update(string url, T tmp, int id);
        Task<bool> Delete(string url, int id);


    }
}
