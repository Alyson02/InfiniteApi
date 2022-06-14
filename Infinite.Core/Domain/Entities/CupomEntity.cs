using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class CupomEntity
    {
        [Key()]
        public int CupomId { get; set; }
        [MaxLength(20)]
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}