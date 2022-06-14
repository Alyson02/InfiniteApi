using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class FuncionarioEntity
    {
        [Key]
        public int FuncionarioId { get; set; }
        [MaxLength(150)]
        public string Nome { get; set; }
        [MaxLength(14)]
        public string Telefone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Senha { get; set; }
        //chaves estrangeiras
        public int CupomId { get; set; }
        public virtual CupomEntity Cupom { get; set; }

    }
}
