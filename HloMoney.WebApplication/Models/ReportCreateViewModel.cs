using System.ComponentModel.DataAnnotations;

namespace HloMoney.WebApplication.Models
{
    using System;

    public class ReportCreateViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить заголовок")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить текст отзыва")]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать оценку")]
        [Display(Name = "Оценка сервиса (кликните, чтобы оценить)")]
        public float Mark { get; set; }
    }
}