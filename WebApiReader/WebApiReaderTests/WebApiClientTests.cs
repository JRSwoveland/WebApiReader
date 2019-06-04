using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiReaderMT.DataAccess;

namespace WebApiReaderTests
{
    [TestClass]
    public class WebApiClientTests
    {
        [TestMethod]
        public async Task GetArticleIdsFromHackerNews()
        {
            var apiClient = new WebApiClient(new Uri("https://hacker-news.firebaseio.com/v0/"));
            var data = await apiClient.Get<List<int>>("newstories.json");
            // this is not a great test since it depends on hacker-news always returning data
            data.Count.ShouldBeGreaterThan(0);
        }
    }
}
