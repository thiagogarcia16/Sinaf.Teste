using AutoMapper;
using Sinaf.Teste.Domain.Entities;
using Sinaf.Teste.WebAPI.DTOs;
using Sinaf.Teste.WebAPI.Extensions;
using System.Linq;

namespace Sinaf.Teste.WebAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApoliceRequestDTO, Apolice>()
                 .ForPath(dest => dest.Corretor.Nome, opt => opt.MapFrom(src => src.Corretor))
                 .ForMember(dest => dest.Dependentes, opt => opt.MapFrom(src => src.Dependentes.Select(e => new Dependente(e))));

            CreateMap<Apolice, ApoliceInsertResponseDTO>();                

            CreateMap<ClienteRequestDTO, Cliente>()
                 .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => new Endereco(e))))
                 .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones.Select(t => new Telefone(t))))
                 .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.RemoverMascara()));

            CreateMap<CoberturaRequestDTO, Cobertura>();

            CreateMap<Apolice, ApoliceResponseDTO>()
                .ForMember(dest => dest.Dependentes, opt => opt.MapFrom(src => src.Dependentes.Select(e => e.Nome))); 

            CreateMap<Cliente, ClienteResponseDTO>()
                 .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos.Select(e => e.Descricao)))
                 .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones.Select(e => e.Numero.RemoverMascara())));

            CreateMap<Corretor, CorretorResponseDTO>();

            CreateMap<Cobertura, CoberturaResponseDTO>();
        }
    }
}
