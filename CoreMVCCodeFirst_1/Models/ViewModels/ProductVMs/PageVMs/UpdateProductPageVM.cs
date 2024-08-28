using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.ResponseModels;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.RequestModels;

namespace CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PageVMs
{
    public class UpdateProductPageVM
    {
        public List<CategoryResponseModel> Categories { get; set; }
        public UpdateProductRequestModel Product { get; set; }
    }
}
