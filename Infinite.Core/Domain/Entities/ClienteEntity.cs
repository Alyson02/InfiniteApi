﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinite.Core.Domain.Entities
{
    public class ClienteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        [MaxLength(100)]

        public string Nome { get; set; }
        [MaxLength(14)]

        public string Tell { get; set; }
        [MaxLength(15)]

        public string Senha { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int Pontos {get; set; }

        public ICollection<CartaoClienteEntity> Cartoes { get; set; }
        public ICollection<EnderecoClienteEntity> Enderecos { get; set; }

    }
}