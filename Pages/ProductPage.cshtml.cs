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
        public int[] stars = new int[5] {5, 4, 3, 2, 1};
        [BindProperty]
        public int Star { get; set; } = 0;

        public readonly ProductDAL _productDAL;
        public ProductPageModel()
        {
            _productDAL = new ProductDAL();
        }
        public IActionResult OnPost(int id)
        {         
            product = _productDAL.ChoiceProduct(id);
            if(Star!=0)
            {
                _productDAL.RateProduct(Star, id);             
            }
            rate = Utils.RoundUpRating(_productDAL.GetAverageRating(id));
            return Page();
            
        }
        public void OnGet(int id)
        {
            product = _productDAL.ChoiceProduct(id);
            rate = Utils.RoundUpRating(_productDAL.GetAverageRating(id));      
        }
    }
}
