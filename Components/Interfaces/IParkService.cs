using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Services;

public interface IParkService
{
    Task<IEnumerable<ParkTableModel>> GetAllParksAsync();
}

