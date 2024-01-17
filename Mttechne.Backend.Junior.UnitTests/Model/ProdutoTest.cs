using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Services.Model;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
        Assert.Equal(default(DateTime), teclado.DataCadastro);
        Assert.False(teclado.Ativo);
    }

    [Fact]
    public void ShouldSetNomeSuccessfully()
    {
        var mouse = new Produto() { Nome = "Mouse", Valor = 50 };

        mouse.Nome = "Novo Mouse";

        Assert.Equal("Novo Mouse", mouse.Nome);
    }

    [Fact]
    public void ShouldSetValorSuccessfully()
    {
        var monitor = new Produto() { Nome = "Monitor", Valor = 200 };

        monitor.Valor = 250;

        Assert.Equal(250, monitor.Valor);
    }

    [Fact]
    public void ShouldSetDataCadastroSuccessfully()
    {
        var celular = new Produto() { Nome = "Celular", Valor = 800 };
        var dataCadastro = DateTime.Now;

        celular.DataCadastro = dataCadastro;

        Assert.Equal(dataCadastro, celular.DataCadastro);
    }

    [Fact]
    public void ShouldSetActiveProductSuccessfully()
    {
        var tablet = new Produto() { Nome = "Tablet", Valor = 300 };

        tablet.Ativo = true;

        Assert.True(tablet.Ativo);
    }
}