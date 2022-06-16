using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Domain.Models
{
    public class ListEnderecoModel
    {
        public int EndId { get; set; }
        public string CEP { get; set; }
        public string NumCasa { get; set; }
        public string Apedido { get; set; }
        public string NomeRua { get; set; }
    }
}
