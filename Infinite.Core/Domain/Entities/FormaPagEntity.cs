using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class FormaPagEntity
    {
        [Key]
        public int FrmId { get; set; }
        [MaxLength(10)]
        public string Frm { get; set; }
    }
}
