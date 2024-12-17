namespace projeto_V1_mercado.Dominio
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long Quantidade { get; set; }
        public double Preco {  get; set; }
        public DateTime Vencimento { get; set; }
        public bool Disponibilidade { get; set; }

    }
}
