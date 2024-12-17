using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_V1_mercado.Dados
{
    public class RelatorioServico
    {
        private readonly VendaRepositorio _vendaRepositorio;

        public RelatorioServico(VendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        public void GerarRelatorioVendas()
        {
            var vendas = _vendaRepositorio.ObterTodasVendas();

            if (vendas.Count  == 0)
            {
                Console.WriteLine("Nenhuma venda resgistrada");
                return;
            }
            Console.WriteLine("=== Relatorio de Vendas ===");
            foreach (var venda in vendas)
            {
                Console.WriteLine($"Data da Venda: {venda.DataVenda:dd/MM/yyyy}");
                Console.WriteLine($"Produto: {venda.IdProduto}");
                Console.WriteLine($"Quantidade Vendida: {venda.QuantidadeVendida}");
                Console.WriteLine($"Valor Total: {venda.ValorTotal:C}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
