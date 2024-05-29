using Ecommerce.DTOs;
using Ecommerce.Models.Entities;

namespace Ecommerce.Interface.Services;

public interface IProductService
{
    Task<BaseResponse<ProductDto>> CreateProduct(ProductRequestModel productRequestModel);
    Task<BaseResponse<ProductDto>> GetProduct(Guid id);
    Task<BaseResponse<ProductDto>> GetProductByName(string name);
    Task<BaseResponse<IEnumerable<ProductDto>>> GetAllProduct(string filter = null);
    Task<BaseResponse<ProductDto>> UpdateProduct(UpdateRequestModel updateRequestModel);



}