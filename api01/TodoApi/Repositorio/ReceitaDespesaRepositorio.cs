using System.Collections.Generic;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoApi.Repositorio {
    public class ReceitaDespesaRepositorio : IRecDesRepositorio
    {
        private readonly ReceitaDespesaContext _contexto;
        public ReceitaDespesaRepositorio(ReceitaDespesaContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(ReceitaDespesa recDes)
        {
            _contexto.ReceitaDespesa.Add(recDes);
            _contexto.SaveChanges();
        }

        public ReceitaDespesa Find(long id)
        {
            return _contexto.ReceitaDespesa.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ReceitaDespesa> GetAll()
        {
            return _contexto.ReceitaDespesa
                   .Include(receita => receita.pessoa)
                   .Include(receita => receita.categoria)
                   .ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.ReceitaDespesa.First(u=> u.Id == id);
            _contexto.ReceitaDespesa.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(ReceitaDespesa recDes)     
        {
            _contexto.ReceitaDespesa.Update(recDes);
            _contexto.SaveChanges();
        }
    }
}