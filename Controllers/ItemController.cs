using Auction.ReadModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly Supabase.Client _database;

    public ItemController(ILogger<ItemController> logger, Supabase.Client database)
    {
        _logger = logger;
        _database = database;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Ok), 200)]
    [ProducesResponseType(typeof(StatusCodeHttpResult), 500)]
    public async Task<ActionResult<IEnumerable<Item>>> Search()
    {
        var result = await _database.From<Item>().Get();
        if (result != null)
        {
            return result.Models!;
        }

        return StatusCode(500, "Internal Server Error");
    }

    [HttpPost]
    [ProducesResponseType(typeof(Task<Item>), 201)]
    [ProducesResponseType(typeof(UnprocessableEntity), 422)]
    public async Task<ActionResult<Item>> Create(
            [FromQuery] string title,
            [FromQuery] string? description)
    {
        var item = new Item
        {
            Title = title,
            Description = description
        };

        var result = await _database.From<Item>().Insert(item);

        if (result != null)
        {
            return CreatedAtAction("", result.Model);
        }

        return StatusCode(500, "Internal Server Error");
    }
}