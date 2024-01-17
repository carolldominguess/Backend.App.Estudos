using Mttechne.Backend.Junior.Services.Notificacoes;

namespace Mttechne.Backend.Junior.Services.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}