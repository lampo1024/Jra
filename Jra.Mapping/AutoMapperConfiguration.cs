using AutoMapper;
using Jra.Domain;
using Jra.ViewModel;

namespace Jra.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                #region OnlineUser
                cfg.CreateMap<OnlineUser, OnlineUserViewModel>();
                cfg.CreateMap<OnlineUserViewModel, OnlineUser>();
                #endregion
            });

            Mapper = MapperConfiguration.CreateMapper();
        }

        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}