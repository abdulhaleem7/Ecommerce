using System.Collections;
using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.Implementation.Services;

public class ProductService(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    ICompanyRepository companyRepository) : IProductService
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

        var getCompany = await _companyRepository.Get(x => x.Id == productRequestModel.CompanyId);
        if (getCompany is null)
        {
            return new BaseResponse<ProductDto>()
            {
                Mesaage = "company does not exist",
                Status = false,
            };
        }

        var createProduct = new Product
        {
            DisCount = productRequestModel.DisCount,
            Name = productRequestModel.Name,
            CategoryId = getCategory.Id,
            CompanyId = getCompany.Id,
            Description = productRequestModel.Description,
            Price = productRequestModel.Price,
            QuantityAvailable = productRequestModel.QuantityAvailable,
            ProductStatus = ProductStatus.Pending,
            Company = getCompany,
            Category = getCategory,
            Image = productRequestModel.Image
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
        var getProduct = await _productRepository.GetProduct(x => x.Id == id);
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
                Id = getProduct.Id,
                Image = getProduct.Image,
                Status = getProduct.QuantityAvailable > 0 ? $"{getProduct.QuantityAvailable} Left" : "Out Of Stock"
            },
        };
    }

    public async Task<BaseResponse<ProductDto>> GetProductByName(string name)
    {
        var getProduct = await _productRepository.GetProduct(x => x.Name == name);
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
                Image = getProduct.Image
            },
        };
    }

    public async Task<BaseResponse<IEnumerable<ProductDto>>> GetAllProduct(string filter = null)
    {
        var getAllProducts =
            await _productRepository.GetAllProductAsync(x => x.Name.Contains(filter) || filter == null);
        return new BaseResponse<IEnumerable<ProductDto>>
        {
            Mesaage = "successful",
            Status = true,
            Data = getAllProducts.Select(x => new ProductDto()
            {
                Id = x.Id,
                DisCount = x.DisCount,
                Name = x.Name,
                CategoryName = x.Category.Name,
                CompanyName = x.Company.Name,
                Description = x.Description,
                Price = x.Price,
                QuantityAvailable = x.QuantityAvailable,
                ProductStatus = x.ProductStatus,
                Image = x.Image,
                Status = x.QuantityAvailable > 0 ? $"{x.QuantityAvailable} Left" : "Out Of Stock"
            }).ToList(),
        };
    }
    public async Task<BaseResponse<IEnumerable<ProductDto>>> GetAllPendingProduct(string filter = null)
    {
        var getAllProducts =
            await _productRepository.GetAllProductAsync(x => x.ProductStatus == ProductStatus.Pending &&  x.Name.Contains(filter) || filter == null);
        return new BaseResponse<IEnumerable<ProductDto>>
        {
            Mesaage = "successful",
            Status = true,
            Data = getAllProducts.Select(x => new ProductDto()
            {
                Id = x.Id,
                DisCount = x.DisCount,
                Name = x.Name,
                CategoryName = x.Category.Name,
                CompanyName = x.Company.Name,
                Description = x.Description,
                Price = x.Price,
                QuantityAvailable = x.QuantityAvailable,
                ProductStatus = x.ProductStatus,
                Image = x.Image,
                Status = x.QuantityAvailable > 0 ? $"{x.QuantityAvailable} Left" : "Out Of Stock"
            }).ToList(),
        };
    }

    public async Task<PageBaseResponse<IList<ProductDto>>> GetPaginatedProduct(int page, int pageSize,
        string filter = null)
    {
        return await _productRepository.GetPaginatedProductAsync(x => x.Name.Contains(filter) || filter == null, page,
            pageSize);
    }

    public async Task<BaseResponse<ProductDto>> UpdateProduct(UpdateRequestModel updateRequestModel)
    {
        var getProduct = await _productRepository.GetProduct(x => x.Id == updateRequestModel.Id);
        if (getProduct is null)
        {
            return new BaseResponse<ProductDto>
            {
                Mesaage = "product does not  exist",
                Status = false,
            };
        }

        if(getProduct.Image != null) 
        {
            getProduct.Image = updateRequestModel.Image;
        }
        getProduct.Description = updateRequestModel.Description ?? getProduct.Description;
        getProduct.Price = updateRequestModel.Price;
        getProduct.QuantityAvailable = getProduct.QuantityAvailable += updateRequestModel.QuantityAvailable;
        getProduct.DisCount = updateRequestModel.DisCount;
        await _productRepository.UpdateAsync(getProduct);
        await _productRepository.SaveChangesAsync();


        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
        };
    }


    public async Task<BaseResponse<ProductDto>> ApproveProduct(Guid productId)
    {
        var getProduct = await _productRepository.GetProduct(x => x.Id == productId);
        if (getProduct is null)
        {
            return new BaseResponse<ProductDto>
            {
                Mesaage = "product does not  exist",
                Status = false,
            };
        }

        getProduct.ProductStatus = ProductStatus.Approved;
        await _productRepository.UpdateAsync(getProduct);
        await _productRepository.SaveChangesAsync();
        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
        };
    }

    public async Task<BaseResponse<ProductDto>> RejectProduct(Guid productId)
    {
        var getProduct = await _productRepository.GetProduct(x => x.Id == productId);
        if (getProduct is null)
        {
            return new BaseResponse<ProductDto>
            {
                Mesaage = "product does not  exist",
                Status = false,
            };
        }

        getProduct.ProductStatus = ProductStatus.Reject;
        await _productRepository.UpdateAsync(getProduct);
        await _productRepository.SaveChangesAsync();
        return new BaseResponse<ProductDto>
        {
            Mesaage = "successful",
            Status = true,
        };
    }
}