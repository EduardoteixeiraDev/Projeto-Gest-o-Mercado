using projeto_V1_mercado.Dados;
using projeto_V1_mercado.Servicos;

namespace projeto_V1_mercado.Interface
{
    public class Menu
    {
        private readonly ProdutoServico _produtoServico;
        private readonly RelatorioServico _relatorioServico;
        private readonly VendaServico _vendaServico;

        public Menu(ProdutoServico produtoServico, RelatorioServico relatorioServico, VendaServico vendaServico)
        {
            _produtoServico = produtoServico;
            _relatorioServico = relatorioServico;
            _vendaServico = vendaServico;
        }

        public void ExibirMenu()
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("==== Sistema de Mercado ====");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Remover Produto");
                Console.WriteLine("3. Atualizar Produto");
                Console.WriteLine("4. Listar Produtos");
                Console.WriteLine("5. Realizar venda");
                Console.WriteLine("6. Gerar Relatório de Vendas");
                Console.WriteLine("7. Sair");
                Console.WriteLine("============================");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        //RemoverProduto();
                        break;
                    case "3":
                        AtualizarProduto();
                        break;
                    case "4":
                        ExibirMenuListaProdutos();
                        break;
                    case "5":
                        RealizarVendaProduto();
                        break;
                    case "6":
                        _relatorioServico.GerarRelatorioVendas();
                        break;
                    case "7":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }
        private void AtualizarProduto()
        {
            Console.Write("Informe o ID do produto: ");
            if (long.TryParse(Console.ReadLine(), out long id))
            {
                var produto = _produtoServico.ObterProdutoPorId(id);
                if (produto != null)
                {
                    Console.Write("Novo preço: ");
                    produto.Preco = double.Parse(Console.ReadLine());

                    Console.Write("Nova quantidade: ");
                    produto.Quantidade = long.Parse(Console.ReadLine());

                    Console.WriteLine("Produto atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
        }
                public void RealizarVendaProduto()
        {
            Console.Write("Informe o ID do produto: ");
            if (!long.TryParse(Console.ReadLine(), out long idProduto))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                return;
            }

            Console.Write("Informe a quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidadeVendida))
            {
                Console.WriteLine("Quantidade inválida. Tente novamente.");
                return;
            }

            bool vendaRealizada = _vendaServico.RealizarVenda(idProduto, quantidadeVendida);
            if (vendaRealizada)
            {
                Console.WriteLine("Venda realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha na venda. Verifique o estoque ou o ID.");
            }
        }


        private void AdicionarProduto()
        {
            string nome;
            do
            {
                Console.Write("Informe o nome do produto: ");
                nome = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome não pode ser vazio. Tente novamente.");
                }
            } while (string.IsNullOrWhiteSpace(nome));

            double preco;
            while (true)
            {
                Console.Write("Informe o preço do produto: ");
                if (double.TryParse(Console.ReadLine(), out preco) && preco > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Preço inválido. Insira um valor numérico maior que zero.");
                }
            }

            long quantidade;
            while (true)
            {
                Console.Write("Informe a quantidade: ");
                if (long.TryParse(Console.ReadLine(), out quantidade) && quantidade > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Quantidade inválida. Insira um número inteiro maior que zero.");
                }
            }

            DateTime vencimento;
            while (true)
            {
                Console.Write("Informe a data de vencimento (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out vencimento))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.");
                }
            }

            bool disponibilidade;
            while (true)
            {
                Console.Write("O produto está disponível? (s/n): ");
                string input = Console.ReadLine().ToLower();
                if (input == "s")
                {
                    disponibilidade = true;
                    break;
                }
                else if (input == "n")
                {
                    disponibilidade = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Responda com 's' para sim ou 'n' para não.");
                }
            }

            _produtoServico.AdicionarProduto(
                nome: nome,
                preco: preco,
                quantidade: quantidade,
                vencimento: vencimento,
                dispinibilidade: disponibilidade);
        }

        private void ExibirMenuListaProdutos()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("1. Produtos disponiveis");
                Console.WriteLine("2. Produtos indisponíveis");
                Console.WriteLine("3. Produtos à vencer");
                Console.WriteLine("4. Produtos vencidos");
                Console.WriteLine("5. Todos os produtos");
                Console.WriteLine("6. Voltar");


                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ProdutosDisponiveis();
                        break;
                    case "2":
                        ProdutosIndisponiveis();
                        break;
                    case "3":
                        ProdutosAVencer();
                        break;
                    case "4":
                        ProdutosVencidos();
                        break;
                    case "5":
                        ListarTodosProdutos();
                        break;
                    case "6":
                        sair = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

                ListarTodosProdutos();
            }
        }

        private void ProdutosVencidos()
        {
            _produtoServico.ListarProdutosVencidos();
        }

        private void ProdutosAVencer()
        {
            throw new NotImplementedException();
        }

        private void ProdutosIndisponiveis()
        {
            throw new NotImplementedException();
        }

        private void ProdutosDisponiveis()
        {
            _produtoServico.ListarProdutosDisponiveis();
        }

        private void ListarTodosProdutos()
        {
            Console.WriteLine("=== Lista de Produtos ===");
            var produtos = _produtoServico.ObterTodosProdutos();
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
            else
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id}");
                    Console.WriteLine($"Nome: {produto.Nome}");
                    Console.WriteLine($"Quantidade em Estoque: {produto.Quantidade}");
                    Console.WriteLine($"Preço: {produto.Preco:C}");
                    Console.WriteLine($"Vencimento: {produto.Vencimento:dd/MM/yyyy}");
                    Console.WriteLine($"Disponível: {(produto.Disponibilidade ? "Sim" : "Não")}");
                    Console.WriteLine("----------------------------");

                }
            }
        }
    }
}
