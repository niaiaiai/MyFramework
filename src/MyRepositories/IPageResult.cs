using System.Collections.Generic;

namespace MyRepositories
{
    public interface IPageResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// 获取或设置 总记录数
        /// </summary>
        public int Total { get; set; }
    }
}