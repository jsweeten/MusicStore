using System.Collections.Generic;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public interface IGuitarRepository
    {
        List<Guitar> GetAll();

        Guitar GetById(int id);
        void Add(Guitar guitar);
    }
}
