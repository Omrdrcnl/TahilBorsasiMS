namespace TahilBorsaJqeryAjax.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Process { get; set; }
        public bool Archive { get; set; }
        public bool Deleted { get; set; }
        public bool Spam { get; set; }
        public bool İmportant { get; set; }
        public DateTime Date { get; set; }
    }
}
