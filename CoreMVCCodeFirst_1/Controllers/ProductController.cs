using CoreMVCCodeFirst_1.Models.ContextClasses;
using CoreMVCCodeFirst_1.Models.Entities;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.RequestModels;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.ResponseModels;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PageVMs;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.RequestModels;
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
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category.CategoryName
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

        public IActionResult CreateProduct()
        {
            CreateProductPageVM cpVm = new()
            {
               Categories = _db.Categories.Select(x => new CategoryResponseModel
               {
                   CategoryName = x.CategoryName,
                   ID = x.ID,
                   Description =x.Description
               }).ToList()
            };
            return View(cpVm);
        }


        //Eger Front End'den size gelen tip icerisinde bir özel tipe yonelik ayrıstırma yapmak isterseniz ya almak istediginiz yapının Property ismini incasesensitive olarak Post Action'iniza parametre ismi olarak verirsiniz (aynısını kücük büyük harf önemsiz) ya da o ismi kullanmak istemiyorsanız Bind Prefix yöntemini kullanırsınız

        [HttpPost]
        public IActionResult CreateProduct([Bind(Prefix ="Product")]CreateProductRequestModel model)
        {
            #region Mapping

            Product p = new()
            {
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID
            };



            #endregion

            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("GetProducts");
        }


        public IActionResult UpdateProduct(int id)
        {
            UpdateProductPageVM uPvm = new()
            {
               Product = _db.Products.Where(x=>x.ID == id).Select(x=>new UpdateProductRequestModel
               {
                   ID = x.ID,
                   ProductName = x.ProductName,
                   UnitPrice = x.UnitPrice,
                   CategoryID = x.CategoryID
               }).FirstOrDefault(),
               Categories =_db.Categories.Select(x=> new CategoryResponseModel
               {
                   ID = x.ID,
                   CategoryName =x.CategoryName
               }).ToList()
            };
            return View(uPvm);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductRequestModel product)
        {
            Product p = _db.Products.Find(product.ID);
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.CategoryID = product.CategoryID;
            _db.SaveChanges();
            return RedirectToAction("GetProducts");
        }


        public IActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("GetProducts");
        }


    }
}
