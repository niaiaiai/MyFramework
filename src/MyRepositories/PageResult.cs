using System.Collections.Generic;

namespace MyRepositories
{
    public class PageResult<T> : IPageResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }
    }
}
