
namespace Catalog.APICatalog.API.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name, 
        List<string> Category, 
        string Description, 
        string ImageFile, 
        decimal Price);

    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender Sender) =>
            {
                // faz o mapeamento do request para o comando usando o Mapster
                var command = request.Adapt<CreateProductCommand>();

                // envia o comando para o MediatR processar e aguarda o resultado
                var result = await Sender.Send(command);
                // mapeia o resultado para a resposta usando o Mapster
                var response = result.Adapt<CreateProductResponse>();
                // retorna a resposta com o status 201 Created e o local do recurso criado
                return Results.Created($"/products/{result.Id}", response);
            }).WithName("CreateProduct")
              .Produces<CreateProductResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Create Product")
              .WithDescription("Create Product");
        }
    }
}
