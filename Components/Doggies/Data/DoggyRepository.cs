using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Components.Base;
using MyDoggyDetails.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Data
{
    public static class DoggyRepository
    {
        private static readonly SQLiteConnection conn;
        public static string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFileName);
        static DoggyRepository()
        {
            conn = new SQLiteConnection(dbPath);
        }

        public static int Save(DoggyTableModel model)
        {
            if (model.Id == 0)
            {
                return Insert(model);
            } else
            {
                return Update(model);
            }
        }

        public static ObservableCollection<DoggyTableModel> SelectAll()
        {
            var results = conn.Table<DoggyTableModel>().ToObservableCollection();

            return results;
        }

        public static int Insert(DoggyTableModel model)
        {
                return conn.Insert(model);
        }

        public static int Update(DoggyTableModel model)
        {
                return conn.Update(model);
        }   

        public static int Delete(DoggyTableModel model)
        {
            return conn.Delete(model);
        }

    }
}
