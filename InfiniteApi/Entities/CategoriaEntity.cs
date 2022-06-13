using System.ComponentModel.DataAnnotations;
namespace InfiniteApi.Entities
{
    public class CategoriaEntity
    {
        [Key]
        public int CategoriaId { get; set; }

        [MaxLength(50)]
        public string Categoria { get; set; }

    }
}