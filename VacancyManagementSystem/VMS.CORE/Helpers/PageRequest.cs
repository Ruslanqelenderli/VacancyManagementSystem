using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.CORE.Helpers
{
    public class PageRequest<TFilter>
    {
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }
        public TFilter Value { get; set; }

        public PageRequest()
        {
            CurrentPage = 1;
            PageSize = int.MaxValue;
        }

        public PageRequest(TFilter filter)
        {
            CurrentPage = 1;
            PageSize = int.MaxValue;
        }
    }
}
