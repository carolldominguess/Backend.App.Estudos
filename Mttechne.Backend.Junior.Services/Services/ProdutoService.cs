using AutoMapper;
using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Domain.Interfaces;
using Mttechne.Backend.Junior.Services.Interfaces;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Model.Validations;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : BaseService, IProdutoService
{
    private readonly IMapper _mapper;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
    {
        _mapper = mapper;
        _produtoRepository = produtoRepository;
    }

    public void AddProduto(ProdutoDto produtoDto)
    {
        var produto = _mapper.Map<ProdutoDto, Produto>(produtoDto);

        if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

        if (_produtoRepository.Buscar(f => f.Nome == produtoDto.Nome).Result.Any())
        {
            Notificar("Já existe um produto com este nome infomado.");
            return;
        }

        _produtoRepository.AddProduto(produto);
    }


    public List<ProdutoDto> GetListaProdutos()
    {
        //ProdutoDto produto1 = new ProdutoDto() { Nome = "Placa de Vídeo", Valor = 1000 };
        //ProdutoDto produto2 = new ProdutoDto() { Nome = "Placa de Vídeo", Valor = 1500 };
        //ProdutoDto produto3 = new ProdutoDto() { Nome = "Placa de Vídeo", Valor = 1350 };
        //ProdutoDto produto4 = new ProdutoDto() { Nome = "Processador", Valor = 2000 };
        //ProdutoDto produto5 = new ProdutoDto() { Nome = "Processador", Valor = 2100 };
        //ProdutoDto produto6 = new ProdutoDto() { Nome = "Memória", Valor = 300 };
        //ProdutoDto produto7 = new ProdutoDto() { Nome = "Memória", Valor = 350 };
        //ProdutoDto produto8 = new ProdutoDto() { Nome = "Placa mãe", Valor = 1100 };

        //List<ProdutoDto> produtosCadastrados = new List<ProdutoDto>()
        //{
        //    produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
        //};

        //return produtosCadastrados;
        var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutos());
        if (!produtos.Any())
            Notificar("A busca não retornou uma lista de produtos.");

        return produtos;
    }

    public List<ProdutoDto> GetListaProdutosPorFaixaPreco(int valor1, int valor2)
    {
        var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutosPorFaixaPreco(valor1, valor2));
        if (!produtos.Any())
            Notificar("A busca não retornou uma lista de produtos.");

        return produtos;
    }

    public List<ProdutoDto>? GetListaProdutosPorNome(string nome)
    {
        var prodNome = new Produto { Nome = nome };
        var produtos = new List<ProdutoDto>();

        if (ExecutarValidacao(new ProdutoBuscaValidation(), prodNome))
             produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutosPorNome(nome));        

        return produtos;
    }

    public List<ProdutoDto> GetListaProdutosPorValorMax(int valor)
    {
        var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutosPorValorMax(valor));

        if (!produtos.Any())
            Notificar("A busca não retornou uma lista de produtos.");

        return produtos;
    }

    public List<ProdutoDto> GetListaProdutosPorValorMin(int valor)
    {
        var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutosPorValorMin(valor));

        if (!produtos.Any())
            Notificar("A busca não retornou uma lista de produtos.");

        return produtos;
    }

    public List<ProdutoDto> GetListaProdutosPorValorOrderByAsc(int valor)
    {
        var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutosPorValorOrderByAsc(valor));

        if (!produtos.Any())
            Notificar("A busca não retornou uma lista de produtos.");

        return produtos;
    }

    public List<ProdutoDto> GetListaProdutosPorValorOrderByDesc(int valor)
    {
        var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetListaProdutosPorValorOrderByDesc(valor));

        if (!produtos.Any())
            Notificar("A busca não retornou uma lista de produtos.");

        return produtos;
    }
    public void Dispose()
    {
        _produtoRepository?.Dispose();
    }
}