using System.Collections.Generic;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoApi.Repositorio {
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ReceitaDespesaContext _contexto;
        public CategoriaRepositorio(ReceitaDespesaContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(Categoria categoria)
        {
            _contexto.Categoria.Add(categoria);
            _contexto.SaveChanges();
        }

        public Categoria Find(long id)
        {
            return _contexto.Categoria.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _contexto.Categoria.ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.Categoria.First(u=> u.Id == id);
            _contexto.Categoria.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Categoria categoria)     
        {
            _contexto.Categoria.Update(categoria);
            _contexto.SaveChanges();
        }
    }
}