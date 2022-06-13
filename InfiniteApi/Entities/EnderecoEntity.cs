using System.ComponentModel.DataAnnotations;

namespace InfiniteApi.Entities
{
    public class EnderecoEntity
    {
        [Key]
        public int EndId { get; set; }
        [MaxLength(9)]
        public string CEP { get; set; }
        [MaxLength(10)]
        public string NumCasa { get; set; }
        [MaxLength(50)]
        public string Apedido { get; set; }
        [MaxLength(20)]
        public string statusEnd { get; set; }
        // Chave entrangeira
        public int ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
    }
}