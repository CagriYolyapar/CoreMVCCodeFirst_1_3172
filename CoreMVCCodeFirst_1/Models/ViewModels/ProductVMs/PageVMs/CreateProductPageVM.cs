using CoreMVCCodeFirst_1.Models.Entities;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.ResponseModels;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.RequestModels;

namespace CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PageVMs
{
    public class CreateProductPageVM
    {
        public List<CategoryResponseModel> Categories { get; set; }
        public CreateProductRequestModel Product { get; set; }
       
    }
}
