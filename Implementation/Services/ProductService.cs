using System.Collections;
using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;

namespace Ecommerce.Implementation.Services;

public class ProductService (IProductRepository productRepository, ICategoryRepository categoryRepository, ICompanyRepository companyRepository): IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly ICompanyRepository _companyRepository = companyRepository;
    public async Task<BaseResponse<ProductDto>> CreateProduct(ProductRequestModel productRequestModel)
    {
        var getCategory = await _categoryRepository.Get(x => x.Id == productRequestModel.CategoryId);
        if (getCategory is null)
        {
            return new BaseResponse<ProductDto>()
            {
                Mesaage = "category does not exist",
                Status = false,
            };
        }
        return new BaseResponse<ProductDto>
        {
            Mesaage = "category exists",
            Status = true,
        };
        
        var getCompany = await _companyRepository.Get(x => x.Id == productRequestModel.CompanyId);
        if (getCompany is null)
        {
            return new BaseResponse<ProductDto>()
            {
                Mesaage = "company does not exist",
                Status = false,
            };
        }
        return new BaseResponse<ProductDto>
        {
            Mesaage = "company exists",
            Status = true,
        };
        var createProduct = new Product
        {
            DisCount = productRequestModel.DisCount,
            Name = productRequestModel.Name,
            CategoryId = getCategory.Id,
            CompanyId = getCompany.Id,
            Description = productRequestModel.Description,
            Price = productRequestModel.Price,
            QuantityAvailable = productRequestModel.QuantityAvailable,
            ProductStatus = productRequestModel.ProductStatus,
        };
        await _productRepository.CreateAsync(createProduct);
        await _productRepository.SaveChangesAsync();
        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
        };
    }

    public async Task<BaseResponse<ProductDto>> GetProduct(Guid id)
    {
        var getProduct = await _productRepository.GetProduct(x=> x.Id == id);
        if (getProduct is null)
        {
            return new BaseResponse<ProductDto>
            {
                Mesaage = "product already exist",
                Status = false,
            };
        }

        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
            Data = new ProductDto
            {
                DisCount = getProduct.DisCount,
                Name = getProduct.Name,
                CategoryName = getProduct.Category.Name,
                CompanyName = getProduct.Company.Name,
                Description = getProduct.Description,
                Price = getProduct.Price,
                QuantityAvailable = getProduct.QuantityAvailable,
                ProductStatus = getProduct.ProductStatus,

            },
        };

    }

    public async Task<BaseResponse<ProductDto>> GetProductByName(string name)
    {
        var getProduct = await _productRepository.GetProduct(x=> x.Name == name);
        if (getProduct is null)
        {
            return new BaseResponse<ProductDto>
            {
                Mesaage = "product already exist",
                Status = false,
            };
        }

        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
            Data = new ProductDto
            {
                DisCount = getProduct.DisCount,
                Name = getProduct.Name,
                CategoryName = getProduct.Category.Name,
                CompanyName = getProduct.Company.Name,
                Description = getProduct.Description,
                Price = getProduct.Price,
                QuantityAvailable = getProduct.QuantityAvailable,
                ProductStatus = getProduct.ProductStatus,

            },
        };
    }

    public  async Task<BaseResponse<IEnumerable<ProductDto>>> GetAllProduct(string filter = null)
    {
        var getAllProducts = await _productRepository.GetAllAsync(x => x.Name.Contains(filter) || filter == null);
        return new BaseResponse<IEnumerable<ProductDto>>
        {
            Mesaage = "successful",
            Status = true,
            Data = getAllProducts.Select(x => new ProductDto()
            {
                DisCount = x.DisCount,
                Name = x.Name,
                CategoryName = x.Category.Name,
                CompanyName = x.Company.Name,
                Description = x.Description,
                Price = x.Price,
                QuantityAvailable = x.QuantityAvailable,
                ProductStatus = x.ProductStatus,
                
            }).ToList(),
        };
    }

    public  async Task<BaseResponse<ProductDto>> UpdateProduct(UpdateRequestModel updateRequestModel)
    {
        var getProduct = await _productRepository.GetProduct(x=> x.Id == updateRequestModel.Id);
        if (getProduct is null)
        {
            return new BaseResponse<ProductDto>
            {
                Mesaage = "product does not  exist",
                Status = false,
            };
        }

        if (getProduct.Name == updateRequestModel.Name)
        {
            var checkProductName = _productRepository.GetProduct(x => x.Name == updateRequestModel.Name);
            if (checkProductName is not null)
            {
                return new BaseResponse<ProductDto>
                {
                    Mesaage = "product already exist",
                    Status = false,
                };
            }

            getProduct.Name = updateRequestModel.Name ?? getProduct.Name;
            getProduct.Description = updateRequestModel.Description ?? getProduct.Description;
            getProduct.Price = updateRequestModel.Price ;
            getProduct.QuantityAvailable = updateRequestModel.QuantityAvailable ;
            getProduct.ProductStatus = updateRequestModel.ProductStatus ;
            await _productRepository.UpdateAsync(getProduct);
            await _productRepository.SaveChangesAsync();

        }

        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
        };

    }
}