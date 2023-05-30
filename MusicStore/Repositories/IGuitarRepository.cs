using System.Collections.Generic;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public interface IGuitarRepository
    {
        List<Guitar> GetAll();

        Guitar GetById(int id);
        List<Guitar> GetByUserId(string firebaseId);
        void Add(Guitar guitar);
    }
}
