using AlaBackEnd.BLL.dto.UserDto;
using System.Text.Json.Serialization;


namespace AlaBackEnd.BLL.dto.UserDto
{
    public class AcceptRieltorRoleDto
    {
        public int RequestId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestStatus Status { get; set; }
    }
}
