using Dapper;
using MyDoggyDetails.Models;
using System.Data;

namespace MyDoggyDetails.Data
{
    internal class DoggyData
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

            string sql = "Update aircraft Set guid = @Guid, name = @Name, logo = @Logo, phone = @Phone, email = @Email WHERE id = @Id";

            return Execute(sql, model);
        }

        private long Insert(DoggyTableModel model)
        {
            string sql = "INSERT INTO aircraft (guid, name, logo, phone, email) Values (@Guid, @Name, @Logo, @Phone, @Email)";

            using (IDbConnection db = new Connection().LocalConnection())
            {
                var affectedRows = db.Execute(sql, model);

                return affectedRows;
            }
        }

        private long Execute(string sql, DoggyTableModel model)
        {
            using (IDbConnection db = new Connection().LocalConnection())
            {
                var affectedRows = db.Execute(sql, model);

                return affectedRows;
            }
        }




        public IEnumerable<DoggyTableModel> SelectAllAircraft()
        {
            try
            {
                IEnumerable<DoggyTableModel> recordset;
                using (IDbConnection db = new Connection().LocalConnection())
                {
                    recordset = db.Query<DogModel>("select * from MyDoggies");
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
