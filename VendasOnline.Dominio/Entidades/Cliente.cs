namespace VendasOnline.Dominio.Entidades
{
    public record Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string CPF { get; set; }
        public required string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
