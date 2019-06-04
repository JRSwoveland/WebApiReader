using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiReaderMT.DataAccess;

namespace WebApiReaderMT.BusinessLogic.HackerNews
{
    /// <summary>
    /// Class to query the hacker-news Web API
    /// </summary>
    public class HackerNewsClient : BaseWebApiNewsClient, INewsClient
    {
        public HackerNewsClient(WebApiConnection newsConnection) : base(newsConnection)
        {
        }

        /// <summary>
        /// Returns a collection of the latest articles
        /// </summary>
        public GetMostRecentArticlesResponse GetMostRecentArticles(GetMostRecentArticlesRequest request)
        {
            var apiClient = new WebApiClient(new Uri(Connection.BaseUrl));

            var taskGetIds = apiClient.Get<List<int>>("newstories.json");
            var dataIds = taskGetIds.Result;

            if (request.ArticleCount > 0)
                dataIds = dataIds.Take(request.ArticleCount).ToList();

            var articles = new List<Article>();
            foreach(var id in dataIds)
            {
                var taskGetItem = apiClient.Get<HackerNewsItem>($"item/{id}.json");
                var item = taskGetItem.Result;
                var article = new Article
                {
                    Headline = item.Title,
                    Url = item.Url
                };
                articles.Add(article);
            }

            return new GetMostRecentArticlesResponse
            {
                Articles = articles
            };
        }

        /// <summary>
        /// Returns a collection of the latest articles that match a search string
        /// </summary>
        public GetSearchedArticlesResponse GetSearchedArticles(GetSearchedArticlesRequest request)
        {
            var apiClient = new WebApiClient(new Uri(Connection.BaseUrl));

            var taskGetIds = apiClient.Get<List<int>>("newstories.json");
            var dataIds = taskGetIds.Result;
            var searchTerm = request.SearchTerm.ToLower();

            var articles = new List<Article>();
            foreach (var id in dataIds)
            {
                var taskGetItem = apiClient.Get<HackerNewsItem>($"item/{id}.json");
                var item = taskGetItem.Result;

                if(item.Title.ToLower().Contains(searchTerm))
                {
                    var article = new Article
                    {
                        Headline = item.Title,
                        Url = item.Url
                    };
                    articles.Add(article);
                }

                if (request.ArticleCount > 0 && articles.Count() >= request.ArticleCount)
                    break;
            }

            return new GetSearchedArticlesResponse
            {
                Articles = articles
            };
        }

        private class HackerNewsItem
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }

    
}
