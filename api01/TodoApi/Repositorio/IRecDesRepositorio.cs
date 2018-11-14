using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repositorio{
    public interface IRecDesRepositorio {
        void Add(ReceitaDespesa recDes);
        IEnumerable<ReceitaDespesa> GetAll();
        ReceitaDespesa Find(long id);
        void Remove(long id);
        void Update(ReceitaDespesa recDes);
    }
}