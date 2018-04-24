using googlesearch.Models;
using googlesearch.Services;
using googlesearch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace googlesearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;

        public HomeController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchQuery viewmodel)
        {
            if (string.IsNullOrWhiteSpace(viewmodel.Query))
                return RedirectToAction("Index");

            var result = await _searchService.GetSearchResultAsync(viewmodel.Query);
            return View(result);

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}