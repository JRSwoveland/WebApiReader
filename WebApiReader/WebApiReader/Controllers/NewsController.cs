using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiReaderMT.BusinessLogic;

namespace WebApiReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private IConfiguration _configuration;

        public NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/News
        [HttpGet("{source}", Name = "Get")]
        public IEnumerable<Article> Get(int source)
        {
            var factory = new NewsClientFactory(_configuration);
            var client = factory.GetClient((NewsClientSource)source);

            var request = new GetMostRecentArticlesRequest
            {
                ArticleCount = int.Parse(_configuration["ArticleCount"])
            };

            var response = client.GetMostRecentArticles(request);
            return response.Articles;
        }

        // GET: api/News
        [HttpGet("{source}/{searchTerm}", Name = "GetSearch")]
        public IEnumerable<Article> Get(int source, string searchTerm)
        {
            var factory = new NewsClientFactory(_configuration);
            var client = factory.GetClient((NewsClientSource)source);

            var request = new GetSearchedArticlesRequest
            {
                ArticleCount = int.Parse(_configuration["ArticleCount"]),
                SearchTerm = searchTerm
            };

            var response = client.GetSearchedArticles(request);
            return response.Articles;
        }
    }
}
