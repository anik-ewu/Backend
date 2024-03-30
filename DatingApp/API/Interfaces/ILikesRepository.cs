using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
         Task<UserLike> GerUserLike(int sourceUserId, int targedUserId);       
         Task<AppUser> GerUserWithLikes(int userId);       
         Task<LikeDto> GetUserLikes(string predicate, int userId);       
    }
}