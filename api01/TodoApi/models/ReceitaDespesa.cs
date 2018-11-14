using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models

{
    [Table("ReceitaDespesa")]
    public class ReceitaDespesa
    {
        [Key]
        public int Id { get; set; }
        /* define "pessoaID" como um chave estrangeira que se refencia na propriedade
        //"pessoa" da classe Pessoa */
        [ForeignKey("pessoa")]
        public int PessoaId { get; set; }        
        public virtual Pessoa pessoa {get; set;}        
        
        [ForeignKey("categoria")]
        public int CategoriaId { get; set; } 
        public virtual Categoria categoria {get; set;}       
        
        public DateTime DataVenc { get; set; }
        public double Valor { get; set; }
        public string Historico { get; set; }
        public byte Receita { get; set; }
        public byte Baixado { get; set; }
        public DateTime DataBaixa { get; set; }
    }
}