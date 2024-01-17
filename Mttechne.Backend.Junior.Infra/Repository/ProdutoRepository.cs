using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Domain.Interfaces;
using Mttechne.Backend.Junior.Infra.Context;

namespace Mttechne.Backend.Junior.Infra.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MttechneDbContext context) : base(context) { }

        public void AddProduto(Produto produto) => Adicionar(produto);
        public List<Produto> GetListaProdutos() => ObterTodos().Result.ToList();

        public List<Produto> GetListaProdutosPorFaixaPreco(int valor1, int valor2)
        {
            var produtos = ObterTodos().Result.Where(p => p.Ativo && p.Valor >= valor1 && p.Valor <= valor2).OrderBy(p => p.Valor).ToList();
            return produtos;
        }

        public List<Produto> GetListaProdutosPorNome(string nome)
        {
            nome = nome.Trim();

            return ObterTodos().Result
                .Where(p => p.Nome.StartsWith(nome, StringComparison.CurrentCultureIgnoreCase) ||
                            p.Nome.IndexOf(nome, StringComparison.CurrentCultureIgnoreCase) != -1)
                .ToList();
        }            

        public List<Produto> GetListaProdutosPorValorMax(int valor)
        {
            var produtos = ObterTodos().Result
            .Where(p => p.Ativo && p.Valor >= valor)
            .OrderBy(p => p.Valor).DistinctBy(p => p.Nome).ToList();

            return produtos;
        }

        public List<Produto> GetListaProdutosPorValorMin(int valor)
        {
            var produtos = ObterTodos().Result
            .Where(p => p.Ativo && p.Valor <= valor)
            .OrderBy(p => p.Valor).DistinctBy(p => p.Nome).ToList();

            return produtos;
        }

        public List<Produto> GetListaProdutosPorValorOrderByAsc(int valor) => ObterTodos().Result.Where(p => p.Valor == valor).OrderBy(p => p.Valor).ToList();

        public List<Produto> GetListaProdutosPorValorOrderByDesc(int valor) => ObterTodos().Result.Where(p => p.Valor == valor).OrderByDescending(p => p.Valor).ToList();
    }
}
