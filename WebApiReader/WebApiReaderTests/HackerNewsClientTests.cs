using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Linq;
using WebApiReaderMT.BusinessLogic;
using WebApiReaderMT.BusinessLogic.HackerNews;

namespace WebApiReaderTests.MT
{
    [TestClass]
    public class HackerNewsClientTests
    {
        [TestMethod]
        public void GetMostRecentArticlesTest()
        {
            var conn = new WebApiConnection("https://hacker-news.firebaseio.com/v0/");
            var client = new HackerNewsClient(conn);
            var request = new GetMostRecentArticlesRequest
            {
                ArticleCount = 20
            };

            var response = client.GetMostRecentArticles(request);

            response.Articles.Count.ShouldBe(20);
        }

        [TestMethod]
        public void GetSearchedArticlesTest()
        {
            var conn = new WebApiConnection("https://hacker-news.firebaseio.com/v0/");
            var client = new HackerNewsClient(conn);
            var request = new GetSearchedArticlesRequest
            {
                ArticleCount = 500,
                SearchTerm = "the" // we are assuming at least one article will include the word "the", which may not always be the case
            };

            var response = client.GetSearchedArticles(request);

            response.Articles.Where(x => x.Headline.Contains(request.SearchTerm)).Count().ShouldBe(response.Articles.Count());
        }
    }
}
