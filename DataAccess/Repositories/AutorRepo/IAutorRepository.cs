using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.AutorRepo
{
  public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAll();

        Task<Autor> GetById(int id);

        Task Add(Autor autor);
        Task Update(Autor autor);
        Task Delete(int id);
        Task Delete(Autor autor);

    }
}
