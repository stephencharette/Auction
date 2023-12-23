using Postgrest.Attributes;
using Postgrest.Models;

namespace Auction.ReadModels;

[Table("brands")]
public class Brand : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}