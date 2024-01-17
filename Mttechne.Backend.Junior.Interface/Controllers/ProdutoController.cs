using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Interfaces;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;
    private readonly INotificador _notificador;

    public ProdutoController(IProdutoService service, INotificador notificador)
    {
        _service = service;
        _notificador = notificador;
    }

    [HttpPost("cadastrar-produto")]
    public async Task<IActionResult> Post([FromBody] ProdutoDto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest(_notificador.ObterNotificacoes());

        _service.AddProduto(produto);

        if (_notificador.TemNotificacao())
            return BadRequest(_notificador.ObterNotificacoes());

        return Ok(produto);
    }

    [HttpGet("lista-produtos")]
    public async Task<IActionResult> GetListaProdutos()
    {
        var produtos = _service.GetListaProdutos();
        if (!produtos.Any())
            return BadRequest(_notificador.ObterNotificacoes());

        return Ok(_service.GetListaProdutos());
    }

    [HttpGet("produtos-nome/{nome}")]
    public async Task<IActionResult> GetListaProdutosPorNome([FromRoute] string nome)
    {
        var produtos = _service.GetListaProdutosPorNome(nome);
        if (!produtos.Any())
            return BadRequest(_notificador.ObterNotificacoes());

        return Ok(produtos);
    }

    [HttpPost("produtos-faixa-preco")]
    public async Task<IActionResult> GetListaProdutosPorFaixaPreco([FromBody] int[] valores)
    {
        var produtos = _service.GetListaProdutosPorFaixaPreco(valores.ElementAtOrDefault(0), valores.ElementAtOrDefault(1));
        return produtos.Any() ? Ok(produtos) : BadRequest(_notificador.ObterNotificacoes());
    }

    [HttpPost("produtos-max-valor")]
    public async Task<IActionResult> GetListaProdutosPorValorMax([FromBody] int valor)
    {
        var produtos = _service.GetListaProdutosPorValorMax(valor);
        return produtos.Any() ? Ok(produtos) : BadRequest(_notificador.ObterNotificacoes());
    }

    [HttpPost("produtos-min-valor")]
    public async Task<IActionResult> GetListaProdutosPorValorMin([FromBody] int valor)
    {
        var produtos = _service.GetListaProdutosPorValorMin(valor);
        return produtos.Any() ? Ok(produtos) : BadRequest(_notificador.ObterNotificacoes());
    }

    [HttpPost("produtos-asc-valor")]
    public async Task<IActionResult> GetListaProdutosPorValorOrderByAsc([FromBody] int valor)
    {
        var produtos = _service.GetListaProdutosPorValorOrderByAsc(valor);
        return produtos.Any() ? Ok(produtos) : BadRequest(_notificador.ObterNotificacoes());
    }

    [HttpPost("produtos-desc-valor")]
    public async Task<IActionResult> GetListaProdutosPorValorOrderByDesc([FromBody] int valor)
    {
        var produtos = _service.GetListaProdutosPorValorOrderByDesc(valor);
        return produtos.Any() ? Ok(produtos) : BadRequest(_notificador.ObterNotificacoes());
    }
}