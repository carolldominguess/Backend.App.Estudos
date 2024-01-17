namespace Mttechne.Backend.Junior.Services.Model;

public class ProdutoDto
{
    public string Nome { get; set; } = null!;
    public int Valor { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
}