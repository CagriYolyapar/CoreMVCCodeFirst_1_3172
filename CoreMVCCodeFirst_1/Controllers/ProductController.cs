using CoreMVCCodeFirst_1.Models.ContextClasses;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.ResponseModels;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PageVMs;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCCodeFirst_1.Controllers
{
    //Product icin fark edeceksiniz ki PureVM'ler(RequestModel, ResponseModellerle)  ile Category kısmında oldugu kadar hasssas davranılarak calısılmamıstır...Burada direkt Domain Entity (Product entity'si) kullanılmıstır...Bu bilerek sadece simulasyon icin zaman kazanmak adına uyguladıgımız bir yöntemdir...Normal şartlarda Category'deki gibi hassas davranılması gerekir...
    public class ProductController : Controller
    {

        MyContext _db;

        public ProductController(MyContext db)
        {
            _db = db;
        }

        public IActionResult GetProducts()
        {
            #region Mapping
            //Mapping

            List<ProductResponseModel> products = _db.Products.Select(x => new ProductResponseModel
            {
                ID = x.ID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice
            }).ToList();

            List<CategoryResponseModel> categories = _db.Categories.Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                ID = x.ID,
                Description = x.Description
            }).ToList();
            #endregion

            ProductResponsePageVM pvm = new()
            {
                Products = products,
                Categories = categories
            };
           

            return View(pvm);
        }



    }
}
