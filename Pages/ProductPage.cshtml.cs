using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductSite.DAL;
using ProductSite.Models;

namespace ProductSite.Pages
{
    public class ProductPageModel : PageModel
    {
        public Product product { get; set; }

        public readonly ProductDAL _productDAL;
        public ProductPageModel()
        {
            _productDAL = new ProductDAL();
        }
        public void OnPost(int id)
        {         
            product = _productDAL.ChoiceProduct(id);
        }
        public void OnGet(int id)
        {
            product = _productDAL.ChoiceProduct(id);
        }
    }
}
