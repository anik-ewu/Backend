using API.DTO;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class LikesRepository : ILikesRepository
    {
        public Task<UserLike> GerUserLike(int sourceUserId, int targedUserId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GerUserWithLikes(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<LikeDto> GetUserLikes(string predicate, int userId)
        {
            throw new NotImplementedException();
        }
    }
}