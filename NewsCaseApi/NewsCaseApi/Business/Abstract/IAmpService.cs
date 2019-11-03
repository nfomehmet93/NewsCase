using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCaseApi.Business.Abstract
{
    public interface IAmpService
    {
        string AmpValidation(string html);
    }
}
