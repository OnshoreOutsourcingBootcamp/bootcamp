using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Logic
    {
        public void AddDog(DogVM dog)
        {
            DAO dao = new DAO();
            dao.CreateDog(ConvertDog(dog));
        }
        public void UpdateDog(DogVM dog)
        {
            DAO dao = new DAO();
            dao.UpdateDog(ConvertDog(dog));
        }
        public void DeleteDog(int dogId)
        {
            DAO dao = new DAO();
            dao.DeleteDog(dogId);
        }
        public List<DogVM> GetAllDogs()
        {
            DAO dao = new DAO();
            return ConvertDogList(dao.GetAllDogs());
        }
        public DogVM GetDogByName(string name)
        {
            DAO dao = new DAO();
            return ConvertDog(dao.GetDogByName(name));
        }
        public List<DogVM> ConvertDogList(List<Dog> dogs)
        {
            List<DogVM> dogVMS = new List<DogVM>();
            foreach (Dog dog in dogs)
            {
                dogVMS.Add(ConvertDog(dog));
            }
            return dogVMS;
        }
        public DogVM ConvertDog(Dog dog)
        {
            DogVM dogDo = new DogVM();
            DAO dao = new DAO();
            dogDo.DogId = dog.DogId;
            dogDo.Name = dog.Name;
            dogDo.Age = dog.Age;
            dogDo.Weight = dog.Weight;
            dogDo.Breed = dog.Breed;
            return dogDo;
        }
        public Dog ConvertDog(DogVM dog)
        {
            Dog dogDo = new Dog();
            DAO dao = new DAO();
            dogDo.DogId = dog.DogId;
            dogDo.Name = dog.Name;
            dogDo.Age = dog.Age;
            dogDo.Weight = dog.Weight;
            dogDo.Breed = dog.Breed;
            return dogDo;
        }
    }
}