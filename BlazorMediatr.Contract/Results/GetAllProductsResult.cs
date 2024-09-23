using BlazorMediatr.Contract.Models;
using Dunet;
namespace BlazorMediatr.Contract.Results;

[Union]
public partial record GetAllProductsResult
{
    partial record Result(List<Product> Products);

    partial record NoRecords();
}