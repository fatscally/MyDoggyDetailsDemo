using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyDoggyDetails.Models;

public abstract partial class BaseTableModel : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public bool IsDirty { get; set; }
    public bool IsBusy { get; set; }
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
}


