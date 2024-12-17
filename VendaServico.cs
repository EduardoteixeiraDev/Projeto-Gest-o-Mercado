using projeto_V1_mercado.Dados;
using projeto_V1_mercado.Dominio;
using System;

namespace projeto_V1_mercado.Servicos
{
    public class VendaServico
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly VendaRepositorio _vendaRepositorio;

        public VendaServico(ProdutoRepositorio produtoRepositorio, VendaRepositorio vendaRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _vendaRepositorio = vendaRepositorio;
        }

        // Método para realizar a venda de um produto
        public bool RealizarVenda(long idProduto, int quantidadeVendida)
        {
            // Obtém o produto pelo ID
            var produto = _produtoRepositorio.ObterPorId(idProduto);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado");
                return false;
            }

            // Verifica se há estoque suficiente
            if (produto.Quantidade < quantidadeVendida)
            {
                Console.WriteLine("Estoque insuficiente para a venda.");
                return false;
            }

            produto.Quantidade -= quantidadeVendida;

            // Calcula o valor total da venda
            double valorTotal = produto.Preco * quantidadeVendida;

            Venda novaVenda = new Venda
            {
                IdProduto = produto.Id,
                QuantidadeVendida = quantidadeVendida,
                ValorTotal = valorTotal,
                DataVenda = DateTime.Now
            };

            _vendaRepositorio.RegistrarVenda(novaVenda);

            return true;
        }
    }
}
