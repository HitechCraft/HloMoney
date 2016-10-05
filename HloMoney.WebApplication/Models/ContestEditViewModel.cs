using System.ComponentModel.DataAnnotations;

namespace HloMoney.WebApplication.Models
{
    public class ContestEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Приз")]
        public string Gift { get; set; }

        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }
    }
}