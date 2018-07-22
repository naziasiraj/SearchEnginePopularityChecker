using System;
using System.Collections.Generic;

namespace SearchEnginePopularityChecker
{
    public class PopularityEvaluator
    {
        private readonly ISearchEngine _searchEngine;

        public PopularityEvaluator(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine ?? throw new ArgumentNullException(nameof(searchEngine));
        }

        public List<int> EvaluatePopularity(string keyword, string URL, int searchCount)
        {

            if (string.IsNullOrEmpty(keyword))
                throw new ArgumentNullException(nameof(keyword));

            if (string.IsNullOrEmpty(URL))
                throw new ArgumentNullException(nameof(URL));

            if (searchCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(searchCount));

            if (_searchEngine == null)
                throw new ArgumentNullException(nameof(_searchEngine));
            try
            {
                List<SearchResult> output = _searchEngine.Search(keyword, searchCount);//get list of search results
                List<int> indices = new List<int>();

                foreach (SearchResult searchResult in output)//create list of matched search result indexes
                {
                    if (searchResult.SearchContent.Contains(URL))
                        indices.Add(searchResult.Index);
                }

                if (indices.Count == 0)//if search is not matched in any of the result results
                    indices.Add(0);

                return indices;
            }
            catch
            {
                throw;
            }

        }
    }
}
