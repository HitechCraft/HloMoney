namespace HloMoney.WebApplication.Models
{
    using System;

    public class UserInfoViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public byte[] Avatar { get; set; }

        public bool IsSynchron { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}