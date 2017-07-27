using Jra.Core;

namespace Jra.Mapping
{
    /// <summary>
    /// AutoMapper startup task
    /// </summary>
    public class AutoMapperStartupTask : IStartupTask
    {
        public void Execute()
        {
            AutoMapperConfiguration.Init();
        }

        public int Order => 0;
    }
}