using projeto_V1_mercado.Dominio;
using System.Collections.Generic;
using System.Threading.Channels;

namespace projeto_V1_mercado.Dados
{
    public class VendaRepositorio
    {
        private List<Venda> _vendas = new List<Venda>();

        public void RegistrarVenda(Venda venda)
        {
            if (venda != null)
            {
                _vendas.Add(venda);
                Console.WriteLine("Venda registrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Venda invalida. Não foi possivel registrar.");
            }
        }

        public List<Venda> ObterTodasVendas()
        {
            return _vendas;
        }
    }
}
