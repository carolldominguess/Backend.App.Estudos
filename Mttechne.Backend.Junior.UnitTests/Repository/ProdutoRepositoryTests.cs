using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Infra.Context;
using Mttechne.Backend.Junior.Infra.Repository;

namespace Mttechne.Backend.Junior.UnitTests.Repository
{
    public class ProdutoRepositoryTests
    {
        [Fact]
        public async Task ShouldAddProductToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MttechneDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MttechneDbContext(options))
            {
                var produtoRepository = new ProdutoRepository(context);

                var produto = new Produto
                {
                    Nome = "NovoProduto",
                    Valor = 200,
                    Ativo = true,
                };

                // Act
                produtoRepository.AddProduto(produto);

                // Assert
                var result = context.Produtos.FirstOrDefault(p => p.Nome == "NovoProduto");
                Assert.NotNull(result);
                Assert.Equal(200, result.Valor);
                Assert.True(result.Ativo);
            }
        }

        [Fact]
        public async Task ShouldReturnProductsInPriceRange()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MttechneDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MttechneDbContext(options))
            {
                var produtos = new List<Produto>
        {
            new() { Nome = "Produto1", Valor = 50, Ativo = true },
            new() { Nome = "Produto2", Valor = 100, Ativo = true },
            new() { Nome = "Produto3", Valor = 150, Ativo = true },
            new() { Nome = "Produto4", Valor = 200, Ativo = true },
        };

                context.Produtos.AddRange(produtos);
                context.SaveChanges();
            }

            using (var context = new MttechneDbContext(options))
            {
                var produtoRepository = new ProdutoRepository(context);

                // Act
                var result = produtoRepository.GetListaProdutosPorFaixaPreco(100, 175);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, p => p.Nome == "Produto2");
                Assert.Contains(result, p => p.Nome == "Produto3");
            }
        }

        [Fact]
        public async Task ShouldReturnProductsByName()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MttechneDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MttechneDbContext(options))
            {
                var produtos = new List<Produto>
            {
                new() { Nome = "Produto1", Valor = 50, Ativo = true },
                new() { Nome = "Produto2", Valor = 100, Ativo = true },
                new() { Nome = "Produto3", Valor = 150, Ativo = true },
            };

                context.Produtos.AddRange(produtos);
                context.SaveChanges();
            }

            using (var context = new MttechneDbContext(options))
            {
                var produtoRepository = new ProdutoRepository(context);

                // Act
                var result = produtoRepository.GetListaProdutosPorNome("proD");

                // Assert
                Assert.Equal(3, result.Count);
                Assert.Contains(result, p => p.Nome == "Produto1");
                Assert.Contains(result, p => p.Nome == "Produto2");
                Assert.Contains(result, p => p.Nome == "Produto3");
            }
        }

        [Fact]
        public async Task ShouldReturnProductsWithMaxValue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MttechneDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MttechneDbContext(options))
            {
                var produtos = new List<Produto>
            {
                new() { Nome = "Produto1", Valor = 50, Ativo = true },
                new() { Nome = "Produto2", Valor = 100, Ativo = true },
                new() { Nome = "Produto3", Valor = 150, Ativo = true },
            };

                context.Produtos.AddRange(produtos);
                context.SaveChanges();
            }

            using (var context = new MttechneDbContext(options))
            {
                var produtoRepository = new ProdutoRepository(context);

                // Act
                var result = produtoRepository.GetListaProdutosPorValorMax(100);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, p => p.Nome == "Produto2");
                Assert.Contains(result, p => p.Nome == "Produto3");
            }
        }

        [Fact]
        public async Task ShouldReturnProductsWithMinValue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MttechneDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MttechneDbContext(options))
            {
                var produtos = new List<Produto>
            {
                new() { Nome = "Produto1", Valor = 50, Ativo = true },
                new() { Nome = "Produto2", Valor = 100, Ativo = true },
                new() { Nome = "Produto3", Valor = 150, Ativo = true },
            };

                context.Produtos.AddRange(produtos);
                context.SaveChanges();
            }

            using (var context = new MttechneDbContext(options))
            {
                var produtoRepository = new ProdutoRepository(context);

                // Act
                var result = produtoRepository.GetListaProdutosPorValorMin(100);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, p => p.Nome == "Produto1");
                Assert.Contains(result, p => p.Nome == "Produto2");
            }
        }

        [Fact]
        public async Task ShouldReturnProductsOrderedByAscendingValue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MttechneDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MttechneDbContext(options))
            {
                var produtos = new List<Produto>
            {
                new() { Nome = "Produto1", Valor = 50, Ativo = true },
                new() { Nome = "Produto2", Valor = 100, Ativo = true },
                new() { Nome = "Produto3", Valor = 150, Ativo = true },
            };

                context.Produtos.AddRange(produtos);
                context.SaveChanges();
            }

            using (var context = new MttechneDbContext(options))
            {
                var produtoRepository = new ProdutoRepository(context);

                // Act
                var result = produtoRepository.GetListaProdutosPorValorOrderByAsc(150);

                // Assert
                Assert.Equal(1, result.Count);
                Assert.Equal("Produto3", result[0].Nome);
            }
        }

        [Fact]
    public async Task ShouldReturnProductsOrderedByDescendingValue()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MttechneDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using (var context = new MttechneDbContext(options))
        {
            var produtos = new List<Produto>
            {
                new() { Nome = "Produto1", Valor = 100, Ativo = true },
                new() { Nome = "Produto2", Valor = 100, Ativo = true },
                new() { Nome = "Produto3", Valor = 50, Ativo = true },
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }

        using (var context = new MttechneDbContext(options))
        {
            var produtoRepository = new ProdutoRepository(context);

            // Act
            var result = produtoRepository.GetListaProdutosPorValorOrderByDesc(100);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Produto1", result[0].Nome);
            Assert.Equal("Produto2", result[1].Nome);
        }
    }

    }
}