using System.Linq;
using System.Security.Claims;

namespace TodoListAPI.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumerable<Claim> _claims;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _claims = httpContextAccessor.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
        }

        public string? Id => _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    }
}
