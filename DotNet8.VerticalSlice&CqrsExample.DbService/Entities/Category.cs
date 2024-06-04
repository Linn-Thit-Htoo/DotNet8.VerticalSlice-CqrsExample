namespace DotNet8.VerticalSlice_CqrsExample.DbService.Entities;

public partial class Category
{
    public long CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}