namespace MyStore.Models
{
    public class UpdateStoreReportRequest
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string MobName { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}
