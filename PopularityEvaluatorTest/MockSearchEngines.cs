using System.Collections.Generic;
using SearchEnginePopularityChecker;

namespace PopularityEvaluatorTest
{
    class MockSearchEngine : ISearchEngine
    {
        public List<SearchResult> Search(string keyword, int searchCout)
        {
            return new List<SearchResult>();
        }
    }

    class MockSearchEngine_URLNotFound : ISearchEngine
    {
        public List<SearchResult> Search(string keyword, int searchCout)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            searchResults.Add(new SearchResult() { SearchContent = "First search result", Index = 1 });
            searchResults.Add(new SearchResult() { SearchContent = "Second search result", Index = 2 });
            searchResults.Add(new SearchResult() { SearchContent = "Third search result", Index = 3 });

            return searchResults;
        }
    }

    class MockSearchEngine_URLFoundOnce : ISearchEngine
    {
        public List<SearchResult> Search(string keyword, int searchCout)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            searchResults.Add(new SearchResult() { SearchContent = "First search result", Index = 1 });
            searchResults.Add(new SearchResult() { SearchContent = "www.smokeball.com.au", Index = 2 });
            searchResults.Add(new SearchResult() { SearchContent = "Third search result", Index = 3 });

            return searchResults;
        }
    }

    class MockSearchEngine_URLFoundMoreThanOnce : ISearchEngine
    {
        public List<SearchResult> Search(string keyword, int searchCout)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            searchResults.Add(new SearchResult() { SearchContent = "www.smokeball.com.au", Index = 1 });
            searchResults.Add(new SearchResult() { SearchContent = "Second search result", Index = 2 });
            searchResults.Add(new SearchResult() { SearchContent = "www.smokeball.com.au", Index = 3 });

            return searchResults;
        }
    }

}
