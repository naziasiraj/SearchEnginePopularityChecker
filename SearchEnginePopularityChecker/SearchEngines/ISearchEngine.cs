using System.Collections.Generic;

namespace SearchEnginePopularityChecker
{
    public interface ISearchEngine
    {
        List<SearchResult> Search(string keyword, int searchCount);
    }
}
