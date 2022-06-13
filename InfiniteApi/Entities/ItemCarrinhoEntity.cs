using System.ComponentModel.DataAnnotations;
namespace InfiniteApi.Entities
{
    public class ItemCarrinhoEntity
    {
        [Key]
        public int ProdutoID { get; set; }
        public virtual ProdutoEntity Produto { get; set; }

        [Key]
        public int CarrinhoID { get; set; }
        
        public double ValorUnidade { get; set; }
        public int Quantidade { get; set; }
        public int Pontos { get; set; }

        // Chave entrangeira

    }
}
