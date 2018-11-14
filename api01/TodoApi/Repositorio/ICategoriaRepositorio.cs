using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repositorio{
    public interface ICategoriaRepositorio {
        void Add(Categoria categoria);
        IEnumerable<Categoria> GetAll();
        Categoria Find(long id);
        void Remove(long id);
        void Update(Categoria categoria);
    }
}