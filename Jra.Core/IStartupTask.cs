namespace Jra.Core
{
   public interface IStartupTask
   {
        /// <summary>
        /// 执行一个任务
        /// </summary>
       void Execute();
        /// <summary>
        /// 执行顺序
        /// </summary>
        int Order { get; }
   }
}
