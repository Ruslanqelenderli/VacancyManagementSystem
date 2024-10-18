using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.CORE.Helpers
{
    public class BaseValueResponse<T>
    {
        public BaseValueResponse(string error) : this()
        {
            Errors.Add(error);
        }

        public BaseValueResponse(List<string> error) : this()
        {
            Errors.AddRange(error);
        }

        public BaseValueResponse()
        {
            Errors = new List<string>();
        }

        public BaseValueResponse(T entity) : this()
        {
            Value = entity;
        }

        public T Value { get; set; }

        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }
        public List<string> Errors { get; set; }
        
        
    }
}

