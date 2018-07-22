using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;

namespace SearchEnginePopularityChecker
{
    public class Google : ISearchEngine
    {
        #region Private Methods
        private const string GoogleUrl = "https://www.google.com.au";
        private string GetHtml(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] buffer = webClient.DownloadData(url);
                string searchResults = Encoding.UTF8.GetString(buffer);
                return searchResults;
            }
        }
        private int FindStartIndex(string htmlString, int startIndex)//returns starting index of a search result
        {
            string tag = "<div class=\"g\">";
            return htmlString.IndexOf(tag, startIndex);
        }
        private int FindEndIndex(string htmlString, int index)//returns ending index of a search result
        {
            string startTag = "<div";
            string endTag = "/div>";
            int tagCount = 0;
            int startTagIndex = 0;
            int endTagIndex = 0;

            do
            {
                startTagIndex = htmlString.IndexOf(startTag, index);
                endTagIndex = htmlString.IndexOf(endTag, index);
                if (startTagIndex < endTagIndex)
                {
                    tagCount++;
                    index = startTagIndex + startTag.Length;
                }
                else
                {
                    tagCount--;
                    index = endTagIndex + startTag.Length;
                }
            } while (tagCount != 0);

            return index;

        }
        #endregion
        public List<SearchResult> Search(string keyword, int searchCount)
        {
            if (string.IsNullOrEmpty(keyword))
                throw new ArgumentNullException(nameof(keyword));

            if (searchCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(searchCount));

            try
            {
                List<SearchResult> resultArray = new List<SearchResult>();

                string url = String.Format("{0}/search?num={1}&q={2}",GoogleUrl, searchCount,keyword);
                //e.g. "https://www.google.com.au/search?num=100&q=conveyancing+software"

                string searchResults = GetHtml(url);
                
                int startIndex = 0;
                int endIndex = 0;

                for (int i = 1; i <= searchCount; i++)
                {
                    startIndex = FindStartIndex(searchResults, endIndex);
                    if (startIndex == -1)
                        return resultArray;

                    endIndex = FindEndIndex(searchResults, startIndex);
                    if (endIndex == -1)
                        return resultArray;

                    string searchResult = searchResults.Substring(startIndex, endIndex - startIndex + 1);

                    //creates a list of all search results
                    resultArray.Add(new SearchResult() { SearchContent = searchResult, Index = i });
                }

                return resultArray;

            }
            catch
            {
                throw;
            }
        }
    }
}
