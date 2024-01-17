namespace Mttechne.Backend.Junior.Domain.Entidades
{
    public class Produto : Entity
    {
        public string Nome { get; set; } = null!;
        public int Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set;}         
    }
}
