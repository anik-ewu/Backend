using System.Security.Claims;

namespace API.Extentions
{
    public static class ClaimsPrincipalsExtentions
    {
        public static string Getusername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
        public static string GetuserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}