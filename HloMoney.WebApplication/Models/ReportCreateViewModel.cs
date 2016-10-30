using System.ComponentModel.DataAnnotations;

namespace HloMoney.WebApplication.Models
{
    using System;

    public class ReportCreateViewModel
    {
        [Required(ErrorMessage = "Необходимо заполнить заголовок")]
        [Display(Name = "Заголовок")]
        [MaxLength(50, ErrorMessage = "Максимальная длина заголовка - 50 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить текст отзыва")]
        [Display(Name = "Текст")]
        [MaxLength(200, ErrorMessage = "Максимальная длина текста - 200 символов")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать оценку")]
        [Display(Name = "Оценка сервиса (кликните, чтобы оценить)")]
        public float Mark { get; set; }
    }
}