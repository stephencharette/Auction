using Auction.ReadModels;
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
    public async Task<IEnumerable<Item>> Search()
    {
        var result = await _database.From<Item>().Get();
        var items = result.Models;

        return items;
    }
}