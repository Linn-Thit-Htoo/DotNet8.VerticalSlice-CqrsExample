namespace DotNet8.VerticalSlice_CqrsExample.DbService.Entities;

public partial class Income
{
    public long IncomeId { get; set; }

    public long Amount { get; set; }

    public DateTime Date { get; set; }

    public bool IsActive { get; set; }
}