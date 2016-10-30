namespace HloMoney.WebApplication.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core.Models.Enum;

    public class ContestEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Описание конкурса (требования)")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Приз")]
        public string Gift { get; set; }

        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Кол-во победителей в конкурсе (1 - 3)")]
        public int WinnerCount { get; set; }
        
        [Display(Name = "Время, прибавляемое при добавлении комментария (в минутах)")]
        public float Increment { get; set; }

        [Display(Name = "Тип конкурса")]
        public ContestType Type { get; set; }
        
        [Display(Name = "Дата окончания")]
        public DateTime? EndTime { get; set; }
    }
}