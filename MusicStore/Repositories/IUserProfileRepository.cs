using System.Collections.Generic;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        List<UserProfile> GetUsers();
        UserProfile GetById(int id);
        void Update(UserProfile userProfile);
    }
}