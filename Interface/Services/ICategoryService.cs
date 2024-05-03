using Ecommerce.DTOs;

namespace Ecommerce.Interface.Services;

public interface ICategoryService
{
    Task<BaseResponse<CategoryDto>> CreateCategory(CategoryRequestModel requestModel);
    Task<BaseResponse<CategoryDto>> GetCategory(string name);
    Task<BaseResponse<IEnumerable<CategoryDto>>> GetAllCategories(string filter = null);
    Task<BaseResponse<CategoryDto>> UpdateCategory(UpdateCategoryRequestModel updateModel);
}