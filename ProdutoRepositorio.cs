using projeto_V1_mercado.Dominio;

namespace projeto_V1_mercado.Dados
{
    public class ProdutoRepositorio
    {
        private readonly List<Produto> _produtos = new List<Produto>();

        public void Adicionar(Produto produto)
        {
            _produtos.Add(produto);
        }

        public List<Produto> ObterTodos()
        {
            return _produtos;
        }

        public Produto ObterPorId(long id)
        {
            return _produtos.Find(p => p.Id == id);
        }

        public List<Produto> ObterProdutosDisponiveis() 
        {
            return _produtos.FindAll(p => p.Disponibilidade);
        }

        public List<Produto> ObterProdutosVencidos()
        {
            return _produtos.FindAll(p => p.Vencimento < DateTime.Now);
        }

        public bool RemoverPorId(long id)
        {
            var produto = ObterPorId(id);

            if (produto != null)
            {
                _produtos.Remove(produto);
                return true;
            }

            return false;
        }

        public bool AtualizarProduto(Produto produtoAtualizado)
        {
            var produto = ObterPorId(produtoAtualizado.Id);

            if (produto != null)
            {
                produto.Nome = produtoAtualizado.Nome;
                produto.Preco = produtoAtualizado.Preco;
                produto.Disponibilidade = produtoAtualizado.Disponibilidade;

                return true;
            }

            return false;
        }
    }
}
