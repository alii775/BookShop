using DataAccess.Models;
using DataAccess.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.AutorRepo
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BookDbContext _context;

        public  AutorRepository(BookDbContext context) 
        {
            _context = context;
        
        
        }

        public async Task Add(Autor autor)
        {
           _context.Autor.Add(autor);
            await _context.SaveChangesAsync();
        }

      

        public async Task Delete(Autor autor)
        {
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Autor>> GetAll()
        {
           var data= await _context.Autor.ToListAsync();
         
            return data;
        }
        
        public async Task<Autor> GetById(int id)
        {
           return await _context.Autor.FindAsync(id);
           

        }
        public async Task Delete(int id)
        {
            var Data = await GetById(id);
            _context.Autor.Remove(Data);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Autor autor)
        {
           _context.Autor.Update(autor);
           var data= await _context.SaveChangesAsync();
            
        }
    }
}
