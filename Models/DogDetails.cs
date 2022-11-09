using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDogsAge.Models
{
    internal class DogDetails
    {
        /// <summary>
        /// Name given to the dog
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The date of birth recorded
        /// </summary>
        public DateOnly DateOfBirth { get; set; }

        public string ChipId { get; set; }



    }
}
