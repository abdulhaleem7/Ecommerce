using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;

namespace Ecommerce.Implementation.Services;

public class CategoryService(ICategoryRepository categoryRepository): ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async  Task<BaseResponse<CategoryDto>> CreateCategory(CategoryRequestModel requestModel)
    {
        var getCategory = await _categoryRepository.Get(x => x.Name == requestModel.Name);
        if (getCategory is not null)
        {
            return new BaseResponse<CategoryDto>
            {
                Mesaage = "Category exist",
                Status = false
            };
        }

        var createCategory = new Category
        {
            Name = requestModel.Name,
            Description = requestModel.Description,
        };
        await _categoryRepository.CreateAsync(createCategory);
        await _categoryRepository.SaveChangesAsync();
        return new BaseResponse<CategoryDto>
        {
            Mesaage = "Successful",
            Status = true,
        };
    }

    public  async Task<BaseResponse<CategoryDto>> GetCategory(string name)
    {
        var getCategory = await _categoryRepository.Get(x => x.Name == name);
        if (getCategory is null)
        {
            return new BaseResponse<CategoryDto>
            {
                Mesaage = "Category dose not exist",
                Status = false,
            };
        }

        return new BaseResponse<CategoryDto>
        {
            Mesaage = "Successful",
            Status = true,
            Data = new CategoryDto
            {
                Name = getCategory.Name,
                Description = getCategory.Description,
            }
        };
    }

    public async  Task<BaseResponse<IEnumerable<CategoryDto>>> GetAllCategories(string filter = null)
    {
        var getAllCategories = await _categoryRepository.GetAllAsync(x => x.Name.Contains(filter) || filter == null);
        return new BaseResponse<IEnumerable<CategoryDto>>
        {
            Mesaage = "successful",
            Status = true,
            Data = getAllCategories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList(),
        };
    }

    public async  Task<BaseResponse<CategoryDto>> UpdateCategory(UpdateCategoryRequestModel updateModel)
    {
        var getCategory = await _categoryRepository.Get(x => x.Name == updateModel.OldValue);
        if (getCategory is null)
        {
            return new BaseResponse<CategoryDto>
            {
                Mesaage = "category dose not exist ",
                Status = false,
            };
        }

        if (getCategory.Name != updateModel.Name)
        {
            var checkCategory = await _categoryRepository.Get(x => x.Name == updateModel.Name);
            if (checkCategory is not null)
            {
                return new BaseResponse<CategoryDto>
                {
                    Mesaage = "Category name already exist, try another one",
                    Status = false,
                };
            }
        }
        getCategory.Name = updateModel.Name ?? getCategory.Name;
       getCategory.Description = updateModel.Description ?? getCategory.Description;
        await _categoryRepository.UpdateAsync(getCategory);
        await _categoryRepository.SaveChangesAsync(); 
        return new BaseResponse<CategoryDto>
        {
            Mesaage = "successful",
            Status = true,
        };
    }
}