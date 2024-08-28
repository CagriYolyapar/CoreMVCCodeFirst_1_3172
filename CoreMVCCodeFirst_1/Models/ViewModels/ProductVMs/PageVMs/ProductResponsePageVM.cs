using CoreMVCCodeFirst_1.Models.Entities;
using CoreMVCCodeFirst_1.Models.ViewModels.CategoryVMs.ResponseModels;
using CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.ResponseModels;

namespace CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PageVMs
{
    //PageVM , View'a gönderilecek bilgileri tutan bir VM'dir...PageVM aslıdna bir Encapsulation'dir...Böylece bu tarz bilgiler sorumluluk dısındaki yapılardan degil o bilgileri yonetmesi gereken class tarafından konteyn edilecektir...
    public class ProductResponsePageVM
    {
        public List<ProductResponseModel> Products { get; set; }
        public List<CategoryResponseModel> Categories { get; set; }
    }
}
