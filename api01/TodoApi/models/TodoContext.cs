using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        //public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Pessoa> Pessoa{get; set;}
        public DbSet<Categoria> Categoria{get; set;}
        public DbSet<ReceitaDespesa> ReceitaDespesa{get; set;}
       
       
    }
}