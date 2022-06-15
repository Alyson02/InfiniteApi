using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinite.Core.Domain.Entities
{
    public class CupomEntity
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CupomId { get; set; }
        [MaxLength(20)]
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}