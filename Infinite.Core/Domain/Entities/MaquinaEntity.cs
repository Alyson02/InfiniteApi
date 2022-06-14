using System;
using System.ComponentModel.DataAnnotations;
namespace Infinite.Core.Domain.Entities
{
    public class MaquinaEntity
    {
        [Key]
        public int MaquinaId { get; set; }
        public bool Status { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }


    }
}