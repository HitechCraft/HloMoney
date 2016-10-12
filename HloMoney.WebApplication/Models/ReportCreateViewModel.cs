using System.ComponentModel.DataAnnotations;

namespace HloMoney.WebApplication.Models
{
    using System;

    public class ReportCreateViewModel
    {
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Display(Name = "Оценка сервиса (кликните, чтобы оценить)")]
        public float Mark { get; set; }
    }
}