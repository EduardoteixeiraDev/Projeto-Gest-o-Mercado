
namespace projeto_V1_mercado.Dominio
{
    public class Venda
    {
        public long IdProduto { get; set; }
        public int QuantidadeVendida {  get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
