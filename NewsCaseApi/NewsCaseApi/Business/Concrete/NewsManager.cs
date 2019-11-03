using HtmlAgilityPack;
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
        private readonly IAmpService _ampService;
        public NewsManager(IAmpService ampService)
        {
            _ampService = ampService;
        }

        public ResponseViewModel GetNewsDetails(int id, bool amp = false)
        {
            var jsonString = System.IO.File.ReadAllText("Content/news.json");
            var news = JsonConvert.DeserializeObject<List<News>>(jsonString);
            var _new = news.FirstOrDefault(x => x.Id == id);
            if (_new == null)
                return new ResponseViewModel() { Message = "Haber Bulunamadı!", IsSuccess = false };

            if (amp)
                _new.Text = _ampService.AmpValidation(_new.Text);
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
