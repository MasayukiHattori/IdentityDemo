using System.Security.Claims;

namespace IdentityDemo.Client.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetCustomClaim(this ClaimsPrincipal principal, string type)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.Claims
                .Where(x => x.Type == type)
                .Select(x => x.Value)
                .FirstOrDefault()!;
        }

        public static string GetUserName(this ClaimsPrincipal principal)
            => principal.GetCustomClaim("employeeID");

        public static string GetFullName(this ClaimsPrincipal principal)
            => principal.GetCustomClaim("fullName");
    }
}
