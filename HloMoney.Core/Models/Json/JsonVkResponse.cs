using HloMoney.Core.Models.Enum;

namespace HloMoney.Core.Models.Json
{
    public class JsonVkResponse
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string bdate { get; set; }

        public string photo_200_orig { get; set; }

        public VkUserStatus online { get; set; }
    }
}
