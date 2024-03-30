using API.Data;
using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface ILikesRepository
    {

         Task<UserLike> GetUserLike(int sourceUserId, int targedUserId);       
         Task<AppUser> GetUserWithLikes(int userId);       
         Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);       
    }
}