using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AvaloniaMasterDetail.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel() 
    {
        MasterRows = new ObservableCollection<MasterRow>();
        for (int i = 0; i < 3; i++)
        {
            MasterRows.Add(new MasterRow(i));
        }
    }

    public ObservableCollection<MasterRow> MasterRows { get; }

    private MasterRow _selectedItem;

    public MasterRow SelectedItem 
    { 
        get { return  _selectedItem; }
        set { this.RaiseAndSetIfChanged(ref _selectedItem, value); }
    }
}

/// <summary>
/// Represents a row in the upper DataGrid
/// </summary>
public class MasterRow
{
    private readonly int rowId;

    public MasterRow(int rowId)
    {
        this.rowId = rowId;

        Children = new ObservableCollection<DetailRow>();

        for (int i = 0; i < 3; i++)
        {
            Children.Add(new DetailRow(rowId, i));
        }
    }

    public string MasterName => $"Master M{rowId}";

    public ObservableCollection<DetailRow> Children { get; private set; }
}

/// <summary>
/// Represents one of many rows in the child grid beneath the masterrow
/// </summary>
public class DetailRow
{
    private readonly int masterRowId;
    private readonly int rowId;

    public DetailRow(int masterRowId, int rowId)
    {
        this.masterRowId = masterRowId;
        this.rowId = rowId;
    }

    public string DetailName => $"Detail M{masterRowId}R{rowId}";

}