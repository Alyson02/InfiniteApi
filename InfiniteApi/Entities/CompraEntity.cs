using System.ComponentModel.DataAnnotations;

namespace InfiniteApi.Entities
{
    public class CompraEntity
    {

        // Falta criar a tabela de cliente para adicionar o endereço e o codigo do funcionario
        
        public int CompraId { get; set; }
        public double Total { get; set; }
        public double Desconto { get; set; }
        public double Pontos { get; set; }

        //chaves estrangeiras
        public int CupomId { get; set; }
        public virtual CupomEntity Cupom { get; set; }
        public int PagamentoId { get; set; }
        public virtual PagamentoEntity Pagamento { get; set; }
        public int EndId { get; set; }
        public virtual EnderecoEntity Endereco { get; set; }
        public int CardId { get; set; }
        public virtual CartaoEntity Cartao { get; set; }

    }
}
