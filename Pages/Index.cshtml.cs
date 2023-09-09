using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductSite.DAL;
using ProductSite.Models;

namespace ProductSite.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ProductDAL _productDAL;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _productDAL = new ProductDAL();
        }

        public void OnGet()
        {
            var products = _productDAL.GetAllProducts();

        }
    }
}