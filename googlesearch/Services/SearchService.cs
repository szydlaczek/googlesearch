using googlesearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace googlesearch.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearch _searchEngine;

        public SearchService(ISearch searchEngine)
        {
            this._searchEngine = searchEngine;
        }

        public async Task<List<SingleResult>> GetSearchResultAsync(string query)
        {
            return _searchEngine.GetSearchResults(query);
        }
    }
}