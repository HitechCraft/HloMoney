namespace HloMoney.WebApplication.Models
{
    using System;

    public class CommentViewModel
    {
        public string Text { get; set; }

        public int ContestId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorAvatar { get; set; }

        public DateTime Date { get; set; }
    }
}