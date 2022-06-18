using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Domain.Entities
{
    public class FotoProdutoEntity
    {
        [key]
        public int ProdutoId { get; set; }
        [key]
        public int ArquivoId { get; set; }
        public ArquivoEntity Arquivo { get; set; }
    }
}
