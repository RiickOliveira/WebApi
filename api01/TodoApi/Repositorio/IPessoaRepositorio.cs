using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repositorio{
    public interface IPessoaRepositorio {
        void Add(Pessoa pessoa);
        IEnumerable<Pessoa> GetAll();
        Pessoa Find(long id);
        void Remove(long id);
        void Update(Pessoa pessoa);
    }
}