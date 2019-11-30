using System;
using System.Linq.Expressions;

namespace GAP.Transversal.Models
{
    public class QueryParameters<T>
    {
        public QueryParameters(int page, int top)
        {
            Page = page;
            Top = top;
            Where = null;
            OrderBy = null;
            OrderByDescending = "Desc";
        }

        public int Page { get; set; }
        public int Top { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
        public string OrderBy { get; set; }
        public string OrderByDescending { get; set; }
    }
}
