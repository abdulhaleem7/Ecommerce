using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;

namespace Ecommerce.Implementation.Services;

public class PaymentHistoryService(IPaymentHistoryRepository paymentHistoryModel) :IPaymentHistoryService
{
    private readonly IPaymentHistoryRepository _paymentHistoryModel = paymentHistoryModel;
    public  async Task<BaseResponse<PaymentHistoryDto>> Create(PaymentHistoryRequestModel paymentHistory)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<PaymentHistoryDto>> GetPaymenthistory(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResponse<IEnumerable<PaymentHistoryDto>>> GetAllPaymentHistory(string filter = null)
    {
        throw new NotImplementedException();
    }
}