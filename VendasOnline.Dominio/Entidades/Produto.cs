namespace VendasOnline.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
