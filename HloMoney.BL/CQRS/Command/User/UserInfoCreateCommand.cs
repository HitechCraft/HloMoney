namespace HloMoney.BL.CQRS.Command
{
    public class UserInfoCreateCommand
    {
        public string VkId { get; set; }

        public string Name { get; set; }

        public byte[] Avatar { get; set; }
    }
}
