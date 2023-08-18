namespace TahilBorsaJqeryAjax.Areas.Admin.Model
{
    public class EntryProductModel
    {
        public int EntryProductId { get; set; }
        public int FarmerId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Process { get; set; }
    }
}
