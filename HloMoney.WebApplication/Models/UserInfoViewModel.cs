﻿namespace HloMoney.WebApplication.Models
{
    using System;
    using Core.Models.Enum;

    public class UserInfoViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string AvatarLink { get; set; }

        public VkUserStatus Status { get; set; }
    }
}