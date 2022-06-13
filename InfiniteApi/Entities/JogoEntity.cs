using System.ComponentModel.DataAnnotations;

namespace InfiniteApi.Entities
{
    public class JogoEntity
    {
        [Key]
        public int JogoId { get; set; }

        public bool Status { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public int PontoPreco { get; set; }

    }
}