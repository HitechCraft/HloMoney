namespace HloMoney.BL.CQRS.Command
{
    using System;

    public class UserInfoCreateCommand
    {
        public string VkId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public byte[] Avatar { get; set; }
    }
}
