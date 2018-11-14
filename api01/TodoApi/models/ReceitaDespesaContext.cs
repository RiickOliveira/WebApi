using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models{

    public class ReceitaDespesaContext : DbContext {

        public ReceitaDespesaContext (DbContextOptions<ReceitaDespesaContext> options)
            : base(options) {   }

            

            public DbSet<Pessoa> Pessoa{get; set;}
            public DbSet<Categoria> Categoria{get; set;}
            public DbSet<ReceitaDespesa> ReceitaDespesa{get; set;}
    }
}