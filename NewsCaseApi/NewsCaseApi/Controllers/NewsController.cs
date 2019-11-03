using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsCaseApi.Business.Abstract;

namespace NewsCaseApi.Controllers
{
    [Route("contents")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var response=_newsService.GetNewsList();
            if (response.IsSuccess)
                return Ok(response);

            else
                return BadRequest(response);     
        }
        [HttpGet("{Id}")]
        public IActionResult GetNews(int id,bool amp=false)
        {
            var response = _newsService.GetNewsDetails(id,amp);
            if (response.IsSuccess)
                return Ok(response);

            else
                return BadRequest(response);
        }
    }
}