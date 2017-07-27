using System;
using System.Collections.Generic;

namespace Jra.Admin.InstanceFactory.ServiceFactory
{
    public static class AllServicesFactory
    {

        private static readonly Dictionary<Type, object> InstanceDict = new Dictionary<Type, object>();

        public static T CreateServiceInstance<T>()
        {
            var type = typeof(T);
            if (InstanceDict.ContainsKey(type))
            {
                return (T)InstanceDict[type];
            }
            var instance = Activator.CreateInstance<T>();
            InstanceDict.Add(type, instance);
            return instance;
        }
    }
}