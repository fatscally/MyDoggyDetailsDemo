using MyDoggyDetails.Models;
using SQLite;

namespace MyDoggyDetails.Base;

public partial class BaseMapModel : BaseTableModel
{
    [Ignore]
    public NavigationMode NavigationMode { get; set; }

    public double Longitude { get; set; }
    public double Latitude { get; set; }

    [MaxLength(100)]
    public string Label { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Address { get; set; } = string.Empty;

    public int Type { get; set; }

    [MaxLength(50)]
    public string AddedByUserGUID { get; set; } = string.Empty;
}
