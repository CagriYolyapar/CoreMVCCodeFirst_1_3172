using CoreMVCCodeFirst_1.Models.Entities;

namespace CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.RequestModels
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
      
    }
}
