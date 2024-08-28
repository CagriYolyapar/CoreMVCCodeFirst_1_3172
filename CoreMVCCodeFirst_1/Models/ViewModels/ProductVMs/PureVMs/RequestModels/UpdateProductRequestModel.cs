namespace CoreMVCCodeFirst_1.Models.ViewModels.ProductVMs.PureVMs.RequestModels
{
    public class UpdateProductRequestModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
    }
}
