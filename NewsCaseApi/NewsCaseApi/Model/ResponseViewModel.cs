using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCaseApi.Model
{
    [Serializable]
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
