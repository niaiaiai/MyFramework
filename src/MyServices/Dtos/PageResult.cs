using System.Collections.Generic;
using System.Linq;

namespace MyServices.Dtos
{
    public class PageResult<T> : IPageResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }

        public PageResult() { }

        public PageResult(IEnumerable<T> list, int pageIndex, int pageSize)
        {
            Total = list.Count();
            Data = list.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}
