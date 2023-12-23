namespace Auction.ReadModels;

public record ItemRm(
    Guid Id,
    string Title,
    string Description,
    BrandRm Brand
    );