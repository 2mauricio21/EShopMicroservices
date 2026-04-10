
namespace Basket.API.Basket.StoreBasket
{

    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResult(string UserName);

    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();

                var result = await sender.Send(command);

                var response  = result.Adapt<StoreBasketResult>();

                return Results.Created($"/basket/{response.UserName}", response);
            }).WithName("CreatedProduct")
              .Produces<StoreBasketResult>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Created Product")
              .WithDescription("Created Product");
        }
    }
}
