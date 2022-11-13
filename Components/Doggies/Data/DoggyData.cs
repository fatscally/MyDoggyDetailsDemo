using Dapper;
using MyDoggyDetails.Models;
using System.Data;

namespace MyDoggyDetails.Data
{
    public class DoggyData
    {
        public long Save(DoggyTableModel model)
        { 
            if (model.Id <= 0)
                return Insert(model);
            else
                return Update(model);
        }

        private long Update(DoggyTableModel model)
        {

            string sql = "Update MyDoggies Set GivenName = @GivenName, DateOfBirth = @DateOfBirth WHERE id = @Id";

            return Execute(sql, model);
        }

        private long Insert(DoggyTableModel model)
        {
            string sql = "INSERT INTO MyDoggies (GivenName, DateOfBirth) Values (@GivenName, @DateOfBirth)";

            using (var db = new Connection().LocalConnection())
            {
                var affectedRows = db.Execute(sql, model);

                return affectedRows;
            }
        }

        private long Execute(string sql, DoggyTableModel model)
        {
            using (var db = new Connection().LocalConnection())
            {
                var affectedRows = db.Execute(sql, model);

                return affectedRows;
            }
        }




        public IEnumerable<DoggyTableModel> SelectAll()
        {
            try
            {
                IEnumerable<DoggyTableModel> recordset;
                using (var db = new Connection().LocalConnection())
                {
                    recordset = db.Query<DoggyTableModel>("select * from MyDoggies");
                }

                return recordset;
            }
            catch
            {
                throw;
            }
        }

    }
}
