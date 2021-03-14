using System;
using System.Collections.Generic;

namespace MyRepositories
{
    [Obsolete("请使用MyServices中的IPageResult")]
    public interface IPageResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// 获取或设置 总记录数
        /// </summary>
        public int Total { get; set; }
    }
}