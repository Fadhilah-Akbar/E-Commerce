namespace ViewModel
{
    public partial class VMMShippingMethod
    {
        public int ShippingMethodId { get; set; }
        public string MethodName { get; set; } = null!;
        public decimal Cost { get; set; }
        public string? EstimatedDeliveryTime { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
