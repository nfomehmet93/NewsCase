using NewsCaseApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCaseApi.Business.Abstract
{
    public interface INewsService
    {
        ResponseViewModel GetNewsList();
        ResponseViewModel GetNewsDetails(int id, bool amp = false);
    }
}
