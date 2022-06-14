using System;
using System.ComponentModel.DataAnnotations;

namespace Infinite.Core.Domain.Entities
{
    public class AgendamentoEntity
    {

        [Key]
        public int AgendamentoId { get; set; }
        public DateTime Horario { get; set; }
        public int Pontos { get; set; }

        // Chave entrangeira
        public int ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }

        public int JogoId { get; set; }
        public virtual JogoEntity Jogo { get; set; }

        public int MaquinaId { get; set; }
        public virtual MaquinaEntity Maquina { get; set; }
    }
}
