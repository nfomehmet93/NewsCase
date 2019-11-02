using NewsCaseApi.Business.Abstract;
using NewsCaseApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCaseApi.Business.Concrete
{
    public class NewsManager : INewsService
    {
        public ResponseViewModel GetNewsDetails(int Id)
        {
            var jsonString = System.IO.File.ReadAllText("Content/news.json");
            var news = JsonConvert.DeserializeObject<List<News>>(jsonString);
            var _new = news.FirstOrDefault(x=>x.Id==Id);
            if (_new==null)
                return new ResponseViewModel() { Message = "Haber Bulunamadı!", IsSuccess = false };

            return new ResponseViewModel() { Data = _new, IsSuccess = true };
        }

        public ResponseViewModel GetNewsList()
        {
            var jsonString = System.IO.File.ReadAllText("Content/news.json");
            var news = JsonConvert.DeserializeObject<List<NewsLight>>(jsonString);
            if (!news.Any())
                return new ResponseViewModel() { Message = "Listelenecek Haber Bulunamadı!", IsSuccess = false };

            return new ResponseViewModel() { Data = news, IsSuccess = true };
        }
    }
}
