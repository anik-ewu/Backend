
using API.Entities;

namespace API.Interfaces
{
    public interface ITokernService
    {
        Task<string> CreateToken(AppUser user);
    }
}