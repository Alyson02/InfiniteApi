using System.ComponentModel.DataAnnotations;

namespace InfiniteApi.Entities
{
    public class CartaoEntity
    {
        [Key]
        public int CardId { get; set; }
        [MaxLength(16)]
        public string NumCard { get; set; }
        [MaxLength(3)]
        public string CodigoSeg { get; set; }
        [MaxLength (50)]
        public string Badeira { get; set; }
        [MaxLength (50)]
        public string ApelidoCard { get; set; }

        // Chave entrangeira
        public int ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
    }
}
