using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
    }
}