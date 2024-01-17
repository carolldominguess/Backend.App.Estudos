using AutoMapper;
using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Interface.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
