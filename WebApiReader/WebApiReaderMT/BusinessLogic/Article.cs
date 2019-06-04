using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiReaderMT.BusinessLogic
{
    /// <summary>
    /// Model representing a link to a news article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// The headline of the article
        /// </summary>
        public string Headline { get; internal set; }

        /// <summary>
        /// URL to the article
        /// </summary>
        public string Url { get; internal set; }
    }
}
