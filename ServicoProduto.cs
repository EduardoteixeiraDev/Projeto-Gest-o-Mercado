using projeto_V1_mercado.Dados;
using projeto_V1_mercado.Dominio;
using System.Data;

namespace projeto_V1_mercado.Servicos
{
    public class ProdutoServico
    {
        public readonly ProdutoRepositorio _repositorio;
        private long _ultimoId = 0;

        public ProdutoServico(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Produto> ObterTodosProdutos()
        {
            return _repositorio.ObterTodos();
        }
        public void AdicionarProduto(string nome, long quantidade, double preco, DateTime vencimento, bool dispinibilidade) 
        {
            long novoId = ++_ultimoId;

            Produto novoProduto = new Produto
            {
                Id = novoId,
                Nome = nome,
                Quantidade = quantidade,
                Preco = preco,
                Vencimento = vencimento,
                Disponibilidade = dispinibilidade

            };

            _repositorio.Adicionar(novoProduto);

            Console.WriteLine($"Produto cadastrado com sucesso: {novoProduto.Nome}, ID: {novoProduto.Id}");

        }
        public Produto? ObterProdutoPorId(long id)
        {
            var produto = _repositorio.ObterPorId(id);
            return produto;
        }
        public bool RemoverPorId(long? id)
        {
            Produto produto;

            if (id == null)
            {
                var produtos = _repositorio.ObterTodos();
                if (produtos.Count > 0)
                {
                    produto = produtos[0];
                }
                else
                {
                    return false; 
                }
            }
            else
            {
                produto = _repositorio.ObterPorId((long)id);
                if (produto == null)
                {
                    return false; 
                }
            }

            _repositorio.RemoverPorId(produto.Id);
            return true; 
        }

        public void ListarProdutos()
        {
            var produtos = _repositorio.ObterTodos();

            if (produtos.Count > 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
            else
            {
                Console.WriteLine("Lista de Produtos:");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}" +
                        $", Vencimento: {produto.Vencimento.ToShortDateString()}, Disponibilidade: {(produto.Disponibilidade ? "Sim" : "Não")}");

                }
            }
        }

        public void ListarProdutosVencidos()
        {
            var listaProdutosVencidos = _repositorio.ObterProdutosVencidos();

            if (listaProdutosVencidos.Count == 0)
            {
                Console.WriteLine("Nenhum produto vencido.");
            }
            else
            {
                Console.WriteLine("Lista de Produtos vencidos:");

                foreach (var produto in listaProdutosVencidos)
                {
                    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}" +
                        $", Vencimento: {produto.Vencimento.ToShortDateString()}, Disponibilidade: {(produto.Disponibilidade ? "Sim" : "Não")}");
                }
            }
        }


        public void ListarProdutosDisponiveis()
        {
            var listaProdutosDisponiveis = _repositorio.ObterProdutosDisponiveis();

            if (listaProdutosDisponiveis.Count == 0)
            {
                Console.WriteLine("Nenhum produto disponível.");
            }
            else
            {
                Console.WriteLine("Lista de Produtos disponíveis:");

                foreach (var produto in listaProdutosDisponiveis)
                {
                    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}" +
                        $", Vencimento: {produto.Vencimento.ToShortDateString()}, Disponibilidade: {(produto.Disponibilidade ? "Sim" : "Não")}");
                }
            }
        }

    }
}