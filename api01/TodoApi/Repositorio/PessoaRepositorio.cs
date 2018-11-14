using System.Collections.Generic;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoApi.Repositorio {
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly ReceitaDespesaContext _contexto;
        public PessoaRepositorio(ReceitaDespesaContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(Pessoa pessoa)
        {
            _contexto.Pessoa.Add(pessoa);
            _contexto.SaveChanges();
        }

        public Pessoa Find(long id)
        {
            return _contexto.Pessoa.FirstOrDefault(u => u.id == id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _contexto.Pessoa.ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.Pessoa.First(u=> u.id == id);
            _contexto.Pessoa.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Pessoa pessoa)     
        {
            _contexto.Pessoa.Update(pessoa);
            _contexto.SaveChanges();
        }
    }
}