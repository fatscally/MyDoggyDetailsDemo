using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;



//There are 2 data access classes to demonstrate the two different styles
namespace MyDoggyDetails.Data;

public static class DoggyData 
{
    public static long Save(DoggyTableModel model)
    { 
        if (model.Id <= 0)
            return Insert(model);
        else
            return Update(model);
    }

    private static long Update(DoggyTableModel model)
    {

        //string sql = "Update MyDoggies Set " +
        //             "GivenName = @GivenName, " +
        //             "DateOfBirth = @DateOfBirth, " +
        //             "Sex= @Sex, " +
        //             "Colour = @Colour, " +
        //             "BreedId = @BreedId, " +
        //             "Mix1BreedId = @Mix1BreedId, " +
        //             "Mix2BreedId = @Mix2BreedId, " + 
        //             "ChipNumber = @ChipNumber, " +
        //             "ChipInsertedDate = @ChipInsertedDate, " +
        //             "ChipImplanterId = @ChipImplanterId, " +
        //             "NextVacDate = @NextVacDate, " +
        //             "CloudId = @CloudId " +
        //             " WHERE id = @Id";

        string sql = "Update MyDoggies Set " +
             "GivenName = @GivenName, " +
             "DateOfBirth = @DateOfBirth, " +
             "ChipNumber = @ChipNumber " +
             " WHERE Id = @Id";

        return Execute(sql, model);
    }

    private static long Insert(DoggyTableModel model)
    {
        string sql = "INSERT INTO MyDoggies (GivenName, DateOfBirth) Values (@GivenName, @DateOfBirth)";

        using (var db = new Connection().LocalConnection())
        {
            var affectedRows = db.Execute(sql, model);

            return affectedRows;
        }
    }

    private static long Execute(string sql, DoggyTableModel model)
    {
        using (var db = new Connection().LocalConnection())
        {
            var affectedRows = db.Execute(sql, model);

            return affectedRows;
        }
    }


    public static ObservableCollection<DoggyTableModel> SelectAll()
    {
        try
        {

            ObservableCollection<DoggyTableModel> recordset;
            using (var db = new Connection().LocalConnection())
            {
                recordset = db.Query<DoggyTableModel>("select * from MyDoggies").ToObservableCollection();
            }

            return recordset;
        }
        catch
        {
            throw;
        }
    }

    public static long Delete(long id)
    {
        throw new NotImplementedException();
    }
}
