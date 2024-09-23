using BlazorMediatr.Contract.Queries;
using BlazorMediatr.Contract.Results;
using BlazorMediatr.Service;
using MediatR;

namespace BlazorMediatr.Features;



public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResult>
{
    private readonly IProductService _productService;

    public GetAllProductsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<GetAllProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Handling from Server");
        var results = await _productService.GetProducts(request.Location);

        await Task.Delay(2000, cancellationToken);

        if (results.Count == 0)
        {
            return new GetAllProductsResult.NoRecords();
        }
        
        return new GetAllProductsResult.Result(results.ToList());
    }
}