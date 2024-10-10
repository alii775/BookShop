using DataAccess.Models;
using DataAccess.Repositories.AutorRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutorService
{
    public class AutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        public async Task<IEnumerable<Autor>> GetAutors()
        {
            return await _autorRepository.GetAll();
        } 
        public async Task<Autor> GetAutorById(int id)
        {
            return await _autorRepository.GetById(id);
        }
        public async Task CreateAutor(Autor autor) 
        {
              await _autorRepository.Add(autor);
      
        }
        public async Task UpdateAutor(Autor autor)
        {
            await _autorRepository.Update(autor);

        }
        public async Task DeleteAutor(Autor autor)
        {
            await _autorRepository.Delete(autor);

        }
    }
}
