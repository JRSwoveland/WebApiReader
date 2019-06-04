using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiReaderMT.BusinessLogic
{
    public abstract class BaseWebApiNewsClient
    {
        public WebApiConnection Connection { get; set; }

        public BaseWebApiNewsClient(WebApiConnection newsConnection)
        {
            Connection = newsConnection;
        }
    }

    public class WebApiConnection
    {
        public string BaseUrl { get; set; }
        
        public WebApiConnection(string baseUri)
        {
            BaseUrl = baseUri;
        }
    }

}
