using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.CORE.Helpers
{
    public class BaseListResponse<T>
    {
        public BaseListResponse()
        {
            Errors = new List<string>();
        }

        public BaseListResponse(List<T> List) : this() 
        {
            this.List = List;
        }

        public List<T> List { get; set; }

        public int TotalCount { get; set; }
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }
        public List<string> Errors { get; set; }
        public int CurrentCount
        {
            get
            {
                if (List == null)
                {
                    return 0;
                }

                return List.Count;
            }
        }
    }
}
