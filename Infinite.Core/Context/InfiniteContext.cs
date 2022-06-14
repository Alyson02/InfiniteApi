using Infinite.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infinite.Core.Context
{
    public class InfiniteContext : DbContext
    {
        public InfiniteContext(DbContextOptions<InfiniteContext> opt) : base(opt)
        {
            ChangeTracker.LazyLoadingEnabled = false;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemCarrinhoEntity>()
                .HasKey(e => new {e.CarrinhoID, e.ProdutoID});
            modelBuilder.Entity<ItemCarrinhoEntity>()
                .HasOne<CarrinhoEntity>()
                .WithMany(g => g.Produtos)
                .HasForeignKey(s => s.CarrinhoID);
        }

        //DataSets

        public DbSet<FuncionarioEntity> Funcionario { get; set; }
        public DbSet<CupomEntity> Cupom { get; set; }
        public DbSet<FormaPagEntity> FormaPag { get; set; }
        public DbSet<PagamentoEntity> Pagamento { get; set; }
        public DbSet<CompraEntity> Compra { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<CartaoEntity> Cartao { get; set; }
        public DbSet<EnderecoEntity> Endereco { get; set; }
        public DbSet<JogoEntity> Jogo { get; set; }
        public DbSet<MaquinaEntity> Maquina { get; set; }
        public DbSet<AgendamentoEntity> Agendamento { get; set; }
        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<ProdutoEntity> Produto{ get; set; }
        public DbSet<ItemCarrinhoEntity> ItemCarrinho{ get; set; }
        public DbSet<CarrinhoEntity> Carrinho{ get; set; }


    }
}
