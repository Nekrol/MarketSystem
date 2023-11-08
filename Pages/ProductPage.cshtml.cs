using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductSite.DAL;
using ProductSite.Models;

namespace ProductSite.Pages
{
    public class ProductPageModel : PageModel
    {
        public Product product { get; set; }
        public int rate { get; set; }
        public int[] stars = new int[5] {1, 2, 3, 4, 5};
        public int Star { get; set; } = 0;

        public readonly ProductDAL _productDAL;
        public ProductPageModel()
        {
            _productDAL = new ProductDAL();
        }
        public IActionResult OnPost(int id)
        {         
            product = _productDAL.ChoiceProduct(id);
            rate = Star;
            return Page();
        }
        public void OnGet(int id)
        {
            product = _productDAL.ChoiceProduct(id);
            rate = Utils.RoundUpRating(_productDAL.GetAverageRating(id));      
        }
    }
}
