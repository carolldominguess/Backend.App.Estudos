using Mttechne.Backend.Junior.Domain.Entidades;

namespace Mttechne.Backend.Junior.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        List<Produto> GetListaProdutos();
        List<Produto> GetListaProdutosPorNome(string nome);
        List<Produto> GetListaProdutosPorValorOrderByDesc(int valor);
        List<Produto> GetListaProdutosPorValorOrderByAsc(int valor);
        List<Produto> GetListaProdutosPorFaixaPreco(int valor1, int valor2);
        List<Produto> GetListaProdutosPorValorMax(int valor);
        List<Produto> GetListaProdutosPorValorMin(int valor);
        void AddProduto(Produto produto);
    }
}