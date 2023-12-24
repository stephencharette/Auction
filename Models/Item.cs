using Postgrest.Attributes;
using Postgrest.Models;

namespace Auction.ReadModels;

[Table("items")]
public class Item : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Reference(typeof(Brand))]
    public Brand? Brand { get; set; }

    [Column("price")]
    public decimal Price { get; set; }
}