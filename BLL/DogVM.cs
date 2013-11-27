using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DogVM
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Breed { get; set; }
        //public string Bark()
        //{
        //    return this.Name + " says: bark!";
        //}
    }
}
