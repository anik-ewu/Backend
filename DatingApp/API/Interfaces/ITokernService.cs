
using API.Entities;

namespace API.Interfaces
{
    public interface ITokernService
    {
        string CreateToken(AppUser user);
    }
}