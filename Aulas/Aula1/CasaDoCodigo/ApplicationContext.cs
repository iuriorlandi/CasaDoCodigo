using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base( options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(i => i.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(c => c.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(i => i.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(i => i.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(i => i.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
            modelBuilder.Entity<Cadastro>().HasOne(c => c.Pedido);

            base.OnModelCreating(modelBuilder);
        }
    }
}
