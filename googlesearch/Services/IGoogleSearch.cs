using googlesearch.Models;
using System.Collections.Generic;

namespace googlesearch.Services
{
    public interface ISearch
    {
        List<SingleResult> GetSearchResults(string query);
    }
}