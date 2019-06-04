using Microsoft.Extensions.Configuration;
using System;
using WebApiReaderMT.BusinessLogic;
using WebApiReaderMT.BusinessLogic.HackerNews;

namespace WebApiReader.Controllers
{
    /// <summary>
    /// Factory to select a NewsClientSource
    /// </summary>
    public class NewsClientFactory
    {
        private IConfiguration _configuration;

        public NewsClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Returns the appropriate NewsClientSource based on the source parameter
        /// </summary>
        public INewsClient GetClient(NewsClientSource source)
        {
            switch(source)
            {
                case NewsClientSource.HackerNews:
                    return new HackerNewsClient(new WebApiConnection(_configuration["HackerNewsBaseUri"]));
                    break;
            }

            throw new Exception("Invalid NewsClientSource");
        }
    }

    public enum NewsClientSource
    {
        HackerNews = 1
    }
}
