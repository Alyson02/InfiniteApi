using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class ProdutoEntity
    {
        [Key]
        public int ProdutoID { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public double Preco { get; set; }
        public int Pontos { get; set; }

        // Chave entrangeira
        public int CategoriaId { get; set; }
        public virtual CategoriaEntity Cupom { get; set; }

    }
}
