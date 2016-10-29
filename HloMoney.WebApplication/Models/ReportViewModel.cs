namespace HloMoney.WebApplication.Models
{
    using System;

    public class ReportViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Text { get; set; }
        
        public string AuthorName { get; set; }

        public byte[] AuthorAvatar { get; set; }

        public float Mark { get; set; }

        public DateTime Date { get; set; }
    }
}