using System.Collections.Generic;

namespace AcuTestRestAPI.Domain.v1.auth
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public string ProfileId { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
