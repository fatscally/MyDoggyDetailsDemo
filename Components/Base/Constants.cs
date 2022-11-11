using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoggyDetails.Components.Base
{
    public static class Constants
    {
        public const string DatabaseFileName = "doggy.db3";
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);


    }
}
