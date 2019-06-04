using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiReaderMT.BusinessLogic
{
    public interface INewsClient
    {
        GetMostRecentArticlesResponse GetMostRecentArticles(GetMostRecentArticlesRequest request);

        GetSearchedArticlesResponse GetSearchedArticles(GetSearchedArticlesRequest request);
    }

    public class GetMostRecentArticlesRequest
    {
        public int ArticleCount { get; set; }
    }

    public class GetMostRecentArticlesResponse
    {
        public List<Article> Articles { get; internal set; }
    }

    public class GetSearchedArticlesRequest
    {
        public int ArticleCount { get; set; }

        public string SearchTerm { get; set; }
    }

    public class GetSearchedArticlesResponse
    {
        public List<Article> Articles { get; internal set; }
    }
}