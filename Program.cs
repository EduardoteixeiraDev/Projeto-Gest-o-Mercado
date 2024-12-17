using projeto_V1_mercado.Interface;
using projeto_V1_mercado.Dados;
using projeto_V1_mercado.Servicos;

namespace projeto_V1_mercado
{
    class Program
    {
        static void Main(string[] args)
        {

            VendaRepositorio vendaRepositorio = new VendaRepositorio();
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();

            RelatorioServico relatorioServico = new RelatorioServico(vendaRepositorio);
            ProdutoServico produtoServico = new ProdutoServico(produtoRepositorio);
            VendaServico vendaServico = new VendaServico(produtoRepositorio, vendaRepositorio);
            Menu menu = new Menu(produtoServico, relatorioServico, vendaServico);
            menu.ExibirMenu();

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
