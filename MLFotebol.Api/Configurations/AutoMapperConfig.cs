using AutoMapper;
using MlFutebol.Bussiness.Entities;
using MLFutebol.Api.ViewsModels;

namespace MLFutebol.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<JogadorViewModel, Jogador>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Posicao, opt => opt.Ignore())
            .ForMember(dest => dest.Time, opt => opt.Ignore())
            .ForMember(dest => dest.Inventario, opt => opt.MapFrom(src => src.Inventario))
            .AfterMap((src, dest) =>
             {
                 // Mapeie o Id do jogadorViewModel para o ItemId do ItemInventarioJogador
                 var itemId = dest.Id;
                 foreach (var item in dest.Inventario)
                 {
                     item.JogadorId = itemId;
                 }
             });

            CreateMap<JogadorTrocaItensInventarioViewModel, Jogador>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Inventario, opt => opt.MapFrom(src => src.Inventario))
            .AfterMap((src, dest) =>
            {
                var itemId = dest.Id;
                foreach (var item in dest.Inventario)
                {
                    item.JogadorId = itemId;
                }
            });

            CreateMap<Jogador, JogadorTrocaItensInventarioViewModel>();

            CreateMap<ItemInventarioJogadorViewModel, ItemInventarioJogador>();

            CreateMap<List<ItemInventarioJogadorViewModel>, List<ItemInventarioJogador>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var itemInventarioJogadorList = new List<ItemInventarioJogador>();
                    foreach (var itemViewModel in src)
                    {
                        var itemInventarioJogador = context.Mapper.Map<ItemInventarioJogador>(itemViewModel);
                        itemInventarioJogadorList.Add(itemInventarioJogador);
                    }
                    return itemInventarioJogadorList;
                });


            CreateMap<ItemInventarioJogador, ItemInventarioJogadorViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Item.Nome));

            CreateMap<List<ItemInventarioJogador>, List<ItemInventarioJogadorViewModel>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var itemInventarioJogadorList = new List<ItemInventarioJogadorViewModel>();
                    foreach (var itemViewModel in src)
                    {
                        var itemInventarioJogador = context.Mapper.Map<ItemInventarioJogadorViewModel>(itemViewModel);
                        itemInventarioJogadorList.Add(itemInventarioJogador);
                    }
                    return itemInventarioJogadorList;
                });

            CreateMap<List<ItemInventarioJogador>, List<ItemInventarioJogadorViewModel>>()
               .ConvertUsing((src, dest, context) =>
               {
                   var itemInventarioJogadorList = new List<ItemInventarioJogadorViewModel>();
                   foreach (var itemViewModel in src)
                   {
                       var itemInventarioJogador = context.Mapper.Map<ItemInventarioJogadorViewModel>(itemViewModel);
                       itemInventarioJogadorList.Add(itemInventarioJogador);
                   }
                   return itemInventarioJogadorList;
               });

            CreateMap<Jogador, JogadorViewModel>()
                .ForMember(dest => dest.PosicaoNome, opt => opt.MapFrom(src => src.Posicao.Nome))
                .ForMember(dest => dest.TimeNome, opt => opt.MapFrom(src => src.Time.Nome))
                .ForMember(dest => dest.Inventario, opt => opt.MapFrom(src => src.Inventario));


        }


    }
}
