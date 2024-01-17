using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Interfaces;

public interface IProdutoService : IDisposable
{
    List<ProdutoDto> GetListaProdutos();
    List<ProdutoDto> GetListaProdutosPorNome(string nome);
    List<ProdutoDto> GetListaProdutosPorValorOrderByDesc(int valor);
    List<ProdutoDto> GetListaProdutosPorValorOrderByAsc(int valor);
    List<ProdutoDto> GetListaProdutosPorFaixaPreco(int valor1, int valor2);
    List<ProdutoDto> GetListaProdutosPorValorMax(int valor);
    List<ProdutoDto> GetListaProdutosPorValorMin(int valor);
    void AddProduto(ProdutoDto produtoDto);
}