using System.Net;
using BlazorMediatr.Client.RestClients.Api;
using BlazorMediatr.Contract.Queries;
using BlazorMediatr.Contract.Results;
using MediatR;

namespace BlazorMediatr.Client.Features;



public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResult>
{
    private readonly IApiClient _client;

    public GetAllProductsQueryHandler(IApiClient client)
    {
        _client = client;
    }
    
    public async Task<GetAllProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handling from WASM");
        
        try
        {
            var result = await _client.ProductsAsync(cancellationToken);
            return new GetAllProductsResult.Result(result.Select(ToProduct).ToList());
        }
        catch (ApiException e) when (e.StatusCode == 404)
        {
            return new GetAllProductsResult.NoRecords();
        }
    }

    private BlazorMediatr.Contract.Models.Product ToProduct(Product arg) => new(arg.Name, arg.Price);
}