using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Infinite.Core.Domain.Entities
{
    public class CarrinhoEntity
    {
        [Key]
        public int CarrinhoID { get; set; }
        public bool StatusCar { get; set; }

        // Chave entrangeira
        public int ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual ICollection<ItemCarrinhoEntity> Produtos { get; set; }
    }
}