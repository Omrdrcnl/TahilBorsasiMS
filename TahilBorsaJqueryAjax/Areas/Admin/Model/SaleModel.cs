namespace TahilBorsaJqeryAjax.Areas.Admin.Model
{
    public class SaleModel
    {
        public int SaleId { get; set; }
        public int EntryId { get; set; }
        public int LabId { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal BasePrice { get; set; }
        public int TradesmanId { get; set; }
        public bool Process { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
