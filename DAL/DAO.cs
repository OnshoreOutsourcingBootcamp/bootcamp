using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{

    public class DAO
    {
        public void Write(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DogHouse;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Dog> Read(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DogHouse;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<Dog> dogs = new List<Dog>();
                    while (data.Read())
                    {
                        Dog dog = new Dog();
                        dog.DogId = Convert.ToInt32(data["DogId"]);
                        dog.Name = data["Name"].ToString();
                        dog.Age = Convert.ToInt32(data["Age"]);
                        dog.Weight = Convert.ToInt32(data["Weight"]);
                        dog.Breed = data["Breed"].ToString();
                        dogs.Add(dog);
                    }
                    return dogs;
                }
            }
        }
        public void CreateDog(Dog dog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", dog.Name),
                new SqlParameter("@Age", dog.Age),
                new SqlParameter("@Weight", dog.Weight),
                new SqlParameter("@Breed", dog.Breed),
                new SqlParameter("@Active", 1)
            };
            Write("AddDog", parameters);
        }
        public void UpdateDog(Dog dog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DogId", dog.DogId),
                new SqlParameter("@Name", dog.Name),
                new SqlParameter("@Age", dog.Age),
                new SqlParameter("@Weight", dog.Weight),
                new SqlParameter("@Breed", dog.Breed)
            };
            Write("UpdateDog", parameters);
        }
        public void DeleteDog(int dogId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DogID", dogId)
            };
            Write("DeleteDog", parameters);
        }
        public List<Dog> GetAllDogs()
        {
            return Read("ReadAll", null);
        }
        public Dog GetDogById(Dog dog)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DogId", dog.DogId)
            };
            return Read("GetDogById", parameters).SingleOrDefault();
        }
        public Dog GetDogByName(string name)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name)
            };
            return Read("GetDogByName", parameters).SingleOrDefault();
        }
    }
}
