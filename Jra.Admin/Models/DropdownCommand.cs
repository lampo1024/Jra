namespace Jra.Admin.Models
{
    public class DropdownCommand
    {
        /// <summary>
        /// 是否返回对象,如果否,则返回数组 
        /// </summary>
        public bool Obj { get; set; }
        /// <summary>
        /// 是否返回[请选择的选项]
        /// </summary>
        public bool All { get; set; }
    }
}