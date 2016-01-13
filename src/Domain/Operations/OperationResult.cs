using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations
{
    public class OperationResult<T>
    {
        public T Element { get; set; }
        public bool Success { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
