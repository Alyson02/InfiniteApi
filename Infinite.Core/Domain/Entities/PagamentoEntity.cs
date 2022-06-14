using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class PagamentoEntity
    {
        [Key]
        public int PagamentoId { get; set; }
        [MaxLength(100)]

        public string Dados { get; set; }

        //Chaves estrangeiras
        public int FrmID { get; set; }
        public virtual FormaPagEntity FormaPag { get; set; }
    }
}
