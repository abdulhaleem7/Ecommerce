using System.Linq.Expressions;
using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;

namespace Ecommerce.Implementation.Services;

public class CartService(ICartRepository cartRepository, IProductRepository productRepository) :ICartService
{
    private readonly ICartRepository _cartRepository = cartRepository;
    private readonly IProductRepository _productRepository = productRepository;
    public  async Task<BaseResponse<CartDto>> CreateCart(CartRequestModel cartRequestModel)
    {
        var createCart = await _cartRepository.GetCart(x => x.Id == cartRequestModel.ProductId);
        
        if (createCart is not null)
        {
            return new BaseResponse<CartDto>
            {
                Mesaage = "cart already exist",
                Status = false,
            };
        }

        var getProduct = _productRepository.GetProduct(x => x.Name == cartRequestModel.ProductName);
        if (getProduct is null)
        {
            return new BaseResponse<CartDto>
            {
                Mesaage = "product is not available",
                Status = false,
            };
        }

        return new BaseResponse<CartDto>
        {
            Mesaage = "product is available",
            Status = true,
        };

        var newCart = new Cart
        {
            CustomerId = cartRequestModel.CustomerId,
            TotalAmount = cartRequestModel.TotalAmount,
            
        };
        _cartRepository.CreateAsync(newCart);
        _cartRepository.SaveChangesAsync();
        return new BaseResponse<CartDto>
        {
            Status = true,
            Mesaage = "Successful",
        };

    }

    public async Task<BaseResponse<CartDto>> GetCart(Guid id)
    {
        var getCart = await _cartRepository.GetCart(x =>x.Id == id );
        if (getCart is null)
        {
            return new BaseResponse<CartDto>
            {
                Mesaage = "cart does not exist",
                Status = false,

            };
        }

        return new BaseResponse<CartDto>
        {
            Mesaage = "successful",
            Status = true,
            Data = new CartDto
            {
                CustomerId = getCart.CustomerId,
                TotalAmount = getCart.TotalAmount,
                // ProductName = getCart.

            }
        };

    }

   
}