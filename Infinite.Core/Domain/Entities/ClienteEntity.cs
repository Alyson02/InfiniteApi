using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class ClienteEntity
    {
        [Key]
        public int ClienteId { get; set; }
        [MaxLength(100)]

        public string Nome { get; set; }
        [MaxLength(14)]

        public string Tell { get; set; }
        [MaxLength(15)]

        public string Senha { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int Pontos {get; set; }

        // Chave entrangeira
        public int CardId { get; set; }
        public virtual CartaoEntity Cartao { get; set; }

    }
}
