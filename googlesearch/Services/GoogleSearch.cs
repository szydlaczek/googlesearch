using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using googlesearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace googlesearch.Services
{
    public class GoogleSearch : ISearch
    {
        private const string apiKey = "AIzaSyDAQzR8jMe_bk7WaREi4ouk_VXH1VHMB8M";
        private const string searchEngineId = "008469957442873031339:kyjrljwluoe";
        private readonly CustomsearchService _customSearchService;
        private CseResource.ListRequest _listRequest;
        private IList<Result> _paging;
        private readonly List<SingleResult> _results;

        public GoogleSearch()
        {
            _customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            _paging = new List<Result>();
            _results = new List<SingleResult>();
        }

        public List<SingleResult> GetSearchResults(string query)
        {
            _listRequest = _customSearchService.Cse.List(query);
            _listRequest.Cx = searchEngineId;

            int pageIndex = 0;

            while (_results.Count < 12 && _paging != null)
            {
                _listRequest.Start = pageIndex * 10 + 1;
                _paging = _listRequest.Execute().Items;
                foreach (var item in _paging)
                {
                    _results.Add(new SingleResult { Title = item.Title, Url = item.Link });
                }

                pageIndex++;
            }

            return _results.Take(12).ToList();
        }
    }
}