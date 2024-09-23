using BlazorMediatr.Contract.Results;
using MediatR;

namespace BlazorMediatr.Contract.Queries;

public record GetAllProductsQuery(string Location) : IRequest<GetAllProductsResult>
{
}