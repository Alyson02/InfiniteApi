using System.ComponentModel.DataAnnotations;
namespace InfiniteApi.Entities
{
    public class ItemCarrinhoEntity
    {
        [Key]
        public int ItemCarrinhoID { get; set; }
        public double ValorUnidade { get; set; }
        public int Quantidade { get; set; }
        public int Pontos { get; set; }

        // Chave entrangeira
        public int CarrinhoID { get; set; }
        public virtual CarrinhoEntity Cupom { get; set; }
    }
}
