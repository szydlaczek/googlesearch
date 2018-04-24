using googlesearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace googlesearch.Services
{
    public interface ISearchService
    {
        Task<List<SingleResult>> GetSearchResultAsync(string query);
    }
}