using Ecommerce.DTOs;

namespace Ecommerce.Interface.Services;

public interface ICompanyService
{
    Task<BaseResponse<CompanyDto>> CreateCompany(CompanyRequestModel companyRequest);
    Task<BaseResponse<CompanyDto>> GetCompany(string name);
    Task<BaseResponse<IEnumerable<CompanyDto>>> GetAllCompany(string filter = null);
    
    Task<BaseResponse<CompanyDto>> UpdateCompany(CompanyUpdateModel companyUpdateModel);
    Task<BaseResponse<CompanyDto>> UpdateCompanyStatus(CompanyUpdateStatus updateStatus);
    Task<BaseResponse<CompanyDto>> GetCompanyById(Guid id );
}