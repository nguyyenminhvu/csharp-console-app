using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.model
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dob { get; set; }
        public int idCate { get; set; }
        public Boolean Vaccin { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }

        public Pet(int id, string name, int dob, int idCate, bool vaccin, float weight, float price)
        {
            Id = id;
            Name = name;
            Dob = dob;
            this.idCate = idCate;
            Vaccin = vaccin;
            Weight = weight;
            Price = price;
        }

        public Pet()
        {
        }
    }
}
