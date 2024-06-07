using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Shared.Models.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string ConnectionId { get; set; }
        public bool IsOnline { get; set; }
    }
}
