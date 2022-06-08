using System.ComponentModel.DataAnnotations;

namespace InfiniteApi.Entities
{
    public class CupomEntity
    {
        [Key()]
        public int CupomId { get; set; }
        public char Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}
