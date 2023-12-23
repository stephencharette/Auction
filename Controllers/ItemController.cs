using Auction.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ItemRm> Search()
        => new ItemRm[]
        {
            new (Guid.NewGuid(), "2017 16\" Macbook Pro", "Test", new BrandRm(Guid.NewGuid(), "Apple")),
            new (Guid.NewGuid(), "2015 15\" Macbook Pro", "Test", new BrandRm(Guid.NewGuid(), "Apple")),
        };
}