using Microsoft.EntityFrameworkCore;
using VendasOnline.Dominio.Entidades;

namespace VendasOnline.Infraestrutura.Contexto
{
    /// <summary>
    /// Contexto do banco de dados VendasOnline, herda de DbContext.
    /// Esta classe é responsável por configurar o banco de dados e mapear as entidades.
    /// </summary>
    public class VendasOnlineDbContext(DbContextOptions<VendasOnlineDbContext> options)
        : DbContext(options)
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de mapeamento de entidades

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Preco).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CPF).IsRequired().HasMaxLength(14);
                entity.HasIndex(e => e.CPF).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ValorTotal).HasColumnType("decimal(18,2)");
                entity.HasOne(d => d.Cliente)
                      .WithMany(p => p.Pedidos)
                      .HasForeignKey(d => d.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ItemPedido>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PrecoUnitario).HasColumnType("decimal(18,2)");
                entity.HasOne(d => d.Pedido)
                      .WithMany(p => p.Itens)
                      .HasForeignKey(d => d.PedidoId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.Produto)
                      .WithMany()
                      .HasForeignKey(d => d.ProdutoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
