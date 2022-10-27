using System.Text.Json.Serialization;
using ToolBox.utils;

namespace CrowdFundingAPI.Models.User
{
    public class UserForm
    {
        public int Id { get; set; } 
        public string NickName { get; set; }
        public string Email { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; } = String.Empty;
        public int IdRole { get; set; }
    }
}
