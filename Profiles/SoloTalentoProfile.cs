using AutoMapper;
using NetSoloTalento.Dtos.TiendaDtos;
using NetSoloTalento.Dtos.ArticuloDtos;
using NetSoloTalento.Models;

namespace NetKubernetes.Profiles;

public class SoloTalentoProfile : Profile {

    public SoloTalentoProfile()
    {
        CreateMap<Tienda,  TiendaResponseDto>();
        CreateMap<TiendaRequestDto, Tienda>();
        CreateMap<Articulo,  ArticuloResponseDto>();
        CreateMap<ArticuloResponseDto, Articulo>();                
    }
    
}