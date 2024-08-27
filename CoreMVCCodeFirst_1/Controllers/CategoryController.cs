using CoreMVCCodeFirst_1.Models.ContextClasses;
using CoreMVCCodeFirst_1.Models.Entities;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.RequestModels;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCCodeFirst_1.Controllers
{
    //!!!!Cok onemli
    //Bir sayfanın sadece 1 modeli olabilir
    public class CategoryController : Controller
    {


        //ViewModels 

        //Kullanıcıların Entity'lere  direkt ulasması saglıksız oldugu icin bizim yarattıgımız ve bir filtreleme yapmayı saglayan yapılardır

        //RequestModels
        //ResponseModels


        MyContext _db;

        public CategoryController(MyContext db)
        {
            _db = db;
        }
        public IActionResult GetCategories()
        {
            //CategoryResponseModel

            //db Category

            //CategorResponseModel

            //Category    =>   CategoryResponseModels    //Mapping


            #region Mappin
            //Category c = new()
            //{
            //    CategoryName = "Tatlılar",
            //    Description = "Test Verisi"
            //};

            //CategoryResponseModel crm = new();
            //crm.CategoryName = c.CategoryName;
            //crm.Description = c.Description; 
            #endregion



            List<CategoryResponseModel> categories = _db.Categories.Select(x => new CategoryResponseModel
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();

            return View(categories);
        }


        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryRequestModel model)
        {
            //Mapping
            Category c = new()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };

            _db.Categories.Add(c);
            _db.SaveChanges();

            return RedirectToAction("GetCategories"); //Burada Action'a yönlendirme yaptıgımıza lütfen dikkat ediniz...İstedigimiz View BackEnd'den yani Action'dan bir veri almak zorunda oldugu icin direkt onu cagıramayız...
        }

        public IActionResult UpdateCategory(int id)
        {
            Category c = _db.Categories.Find(id);
            UpdateCategoryRequestModel uCVM = new()
            {
                CategoryName=c.CategoryName,
                Description=c.Description,
                CategoryID = c.ID
            };


            TempData["guncellenecek"] = id; 

            return View(uCVM);
        }


        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryRequestModel model)
        {
            if (Convert.ToInt32(TempData["guncellenecek"]) != model.CategoryID)
            {
                TempData["message"] = "Ne yapıyorsun arkadasım!!";
                return RedirectToAction("GetCategories");
            }

            Category original = _db.Categories.Find(model.CategoryID);
            original.CategoryName = model.CategoryName;
            original.Description = model.Description;
            _db.SaveChanges();
            return RedirectToAction("GetCategories");
        }
    }
}
