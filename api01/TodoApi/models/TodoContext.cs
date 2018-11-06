using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Pessoa> Pessoas{get; set;}
        public DbSet<Categoria> Categorias{get; set;}
        public DbSet<ReceitaDespesa> ReceitasDespesas{get; set;}
       
       
    }
}