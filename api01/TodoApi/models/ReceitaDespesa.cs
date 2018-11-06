namespace TodoApi.Models
{
    public class ReceitaDespesa
    {
        public long Id { get; set; }
        public int PessoaId { get; set; }
        public int CategoriaId { get; set; }
        public string DataVenc { get; set; }
        public decimal Valor { get; set; }
        public string Historico { get; set; }
        public bool Receita { get; set; }
        public bool Baixado { get; set; }
        public string DataBaixa { get; set; }
    }
}