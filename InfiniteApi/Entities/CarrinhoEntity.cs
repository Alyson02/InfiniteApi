using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace InfiniteApi.Entities
{
    public class CarrinhoEntity
    {
        [Key]
        public int CarrinhoID { get; set; }
        public bool StatusCar { get; set; }

        // Chave entrangeira
        public int ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual List<ProdutoEntity> Produtos { get; set; }
    }
}