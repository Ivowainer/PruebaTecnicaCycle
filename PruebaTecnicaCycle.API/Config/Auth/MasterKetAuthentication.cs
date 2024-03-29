// MasterKeyAuthenticationHandler.cs

using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace PruebaTecnicaCycle.API.Config.Auth
{
    public class MasterKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;
        public MasterKeyAuthenticationHandler(IConfiguration configuration, IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var masterKeySecret = _configuration["Auth:MasterKey"];

            if (!Request.Headers.TryGetValue("MasterKey", out var masterKey) || string.IsNullOrWhiteSpace(masterKey))
            {
                return AuthenticateResult.Fail("A master key was not provided");
            }

            if (masterKey != masterKeySecret)
            {
                return AuthenticateResult.Fail("Invalid master key");
            }

            var claims = new[] { new Claim(ClaimTypes.Name, "master") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
