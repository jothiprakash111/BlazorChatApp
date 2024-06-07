using Microsoft.AspNetCore.Identity;

namespace SignalRChat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ConnectionId { get; set; }
    }
}
