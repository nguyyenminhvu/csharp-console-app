using PetManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.repository
{
    public interface PetRepository
    {
        public List<Pet> FindPet(Func<Pet, Pet> petDelegate, List<Pet> listPet);
        public List<Pet> ReadToFilePet(string path);
        public Boolean WriteToFilePet(List<Pet> listPet, string path);
        public List<Category> ReadToFileCategory(string path);
        public Boolean WriteToFileCategory(List<Category> listCategory, string path);

    }
}
