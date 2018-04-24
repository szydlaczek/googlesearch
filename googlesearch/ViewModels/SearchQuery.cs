using System.ComponentModel.DataAnnotations;

namespace googlesearch.ViewModels
{
    public class SearchQuery
    {
        [MinLength(1)]
        [RegularExpression(@"^\S*$", ErrorMessage = "Bez białych spacji")]
        public string Query { get; set; }
    }
}