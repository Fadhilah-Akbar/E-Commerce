namespace ViewModel
{
    public partial class VMMMerchant
    {
        public int MerchantId { get; set; }
        public int? UserId { get; set; }

        public string MerchantName { get; set; } = null!;
        public string? MerchantPhone { get; set; }
        public string? MerchantAddress { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual VMMUser? User { get; set; }
        public virtual ICollection<VMMProduct> MProducts { get; set; }
    }
}
