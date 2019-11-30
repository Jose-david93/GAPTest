using System;
using System.Linq.Expressions;

namespace GAP.Transversal.Models
{
    public class QueryParameters
    {
        public QueryParameters(int page, int top)
        {
            Page = page;
            Top = top;
        }
        public int Page { get; set; }
        public int Top { get; set; }
    }
}
