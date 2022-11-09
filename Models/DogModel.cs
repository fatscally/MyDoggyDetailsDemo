using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoggyDetails.Models
{
    internal enum Genders
    {
        Male,
        Female
    }

    internal enum Breeds
    {
        Schnauzer,
        Greyhound,
        JackRussel
    }

    internal class DogModel
    {

        public Breeds Breed { get; set; }

        /// <summary>
        /// Name given to the dog
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The date of birth recorded
        /// </summary>
        public DateOnly DateOfBirth { get; set; }

        public string ChipId { get; set; }


        public Genders Gender{ get; set; }

    }
}
