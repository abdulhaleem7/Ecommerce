using Ecommerce.DTOs;

namespace Ecommerce.Interface.Services;

public interface IPaymentHistoryService
{
    Task<BaseResponse<PaymentHistoryDto>> Create(PaymentHistoryRequestModel paymentHistory);
    Task<BaseResponse<PaymentHistoryDto>> GetPaymenthistory(Guid id);
    Task<BaseResponse<IEnumerable<PaymentHistoryDto>>> GetAllPaymentHistory(string filter = null);
    
}