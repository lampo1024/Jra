using Jra.Domain;
using Jra.ViewModel;

namespace Jra.Mapping
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region OnlineUser
        public static OnlineUserViewModel ToViewModel(this OnlineUser entity)
        {
            return entity.MapTo<OnlineUser, OnlineUserViewModel>();
        }

        public static OnlineUser ToEntity(this OnlineUserViewModel entity)
        {
            return entity.MapTo<OnlineUserViewModel, OnlineUser>();
        }

        #endregion
    }
} 