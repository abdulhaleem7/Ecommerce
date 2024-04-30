using Ecommerce.DTOs;
using Ecommerce.Interface.Repositories;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;
using Ecommerce.Models.Enums;

namespace Ecommerce.Implementation.Services;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    private readonly ICompanyRepository _companyRepository = companyRepository;

    public async Task<BaseResponse<CompanyDto>> CreateCompany(CompanyRequestModel companyRequest)
    {
        var getCompany = await _companyRepository.Get(x => x.Name == companyRequest.Name);
        if (getCompany != null)
        {
            return new BaseResponse<CompanyDto>
            {
                Mesaage = "Company already exist",
                Status = false,
            };
        }

        var createCompany = new Company
        {
            Address = companyRequest.Address,
            CacRegNumber = companyRequest.CacRegNumber,
            CompanyEmail = companyRequest.CompanyEmail,
            Logo = companyRequest.Logo,
            Name = companyRequest.Name,
            CompanyStatus = CompanyStatus.Pending,
        };
        await _companyRepository.CreateAsync(createCompany);
        await _companyRepository.SaveChangesAsync();
        return new BaseResponse<CompanyDto>
        {
            Mesaage = "Company successfully created",
            Status = true,
        };
    }

    public async Task<BaseResponse<CompanyDto>> GetCompany(string name )
    {
        var getCompany = await _companyRepository.Get(x => x.Name == name);
        if (getCompany == null)
        {
            return new BaseResponse<CompanyDto>
            {
                Mesaage = "company dose not exist",
                Status = false,
            };
        }

        return new BaseResponse<CompanyDto>
        {
            Mesaage = "sucessful",
            Status = true,
            Data = new CompanyDto()
            {
                Id = getCompany.Id,
                Address = getCompany.Address,
                CacRegNumber = getCompany.CacRegNumber,
                CompanyEmail = getCompany.CompanyEmail,
                Logo = getCompany.Logo,
                Name = getCompany.Name,
                CompanyStatus = getCompany.CompanyStatus
            },
        };
    }
    public async Task<BaseResponse<CompanyDto>> GetCompanyById(Guid id )
    {
        var getCompany = await _companyRepository.Get(x => x.Id == id);
        if (getCompany == null)
        {
            return new BaseResponse<CompanyDto>
            {
                Mesaage = "company dose not exist",
                Status = false,
            };
        }

        return new BaseResponse<CompanyDto>
        {
            Mesaage = "successful",
            Status = true,
            Data = new CompanyDto()
            {
                Id = getCompany.Id,
                Address = getCompany.Address,
                CacRegNumber = getCompany.CacRegNumber,
                CompanyEmail = getCompany.CompanyEmail,
                Logo = getCompany.Logo,
                Name = getCompany.Name,
                CompanyStatus = getCompany.CompanyStatus,
            },
        };
    }

    public async Task<BaseResponse<IEnumerable<CompanyDto>>> GetAllCompany(string filter = null)
    {
        var getAllCompany = await _companyRepository.GetAllAsync(x => x.Name.Contains(filter) || filter == null);

        return new BaseResponse<IEnumerable<CompanyDto>>
        {
            Mesaage = "successful",
            Status = true,
            Data = getAllCompany.Select(x => new CompanyDto()
            {
                Id = x.Id,
                Address = x.Address,
                CacRegNumber = x.CacRegNumber,
                CompanyEmail = x.CompanyEmail,
                CompanyStatus = x.CompanyStatus,
                Name = x.Name,
                Logo = x.Logo,
            }).ToList(),
        };

    }

    public async Task<BaseResponse<CompanyDto>> UpdateCompany(CompanyUpdateModel companyUpdateModel)
    {
        var updateCompany = await _companyRepository.Get(x => x.Id == companyUpdateModel.Id);
        if (updateCompany == null)
        {
            return new BaseResponse<CompanyDto>
            {
                Mesaage = "company does not exist",
                Status = false,
            };
        }

        if (updateCompany.Name == companyUpdateModel.Name)
        {
            var checkCompanyName = await _companyRepository.Get(x => x.Name == companyUpdateModel.Name);
            if (checkCompanyName != null)
            {
                return new BaseResponse<CompanyDto>
                {
                    Mesaage = "company name already exist, try another name",
                    Status = false,
                };
            }
        }
        updateCompany.Name = companyUpdateModel.Name ?? updateCompany.Name;
        updateCompany.Address = companyUpdateModel.Address ?? updateCompany.Address;
        await _companyRepository.UpdateAsync(updateCompany);
        await _companyRepository.SaveChangesAsync();
        return new BaseResponse<CompanyDto>
        {
            Status = true,
            Mesaage = "successful",
        };
    }

    public async Task<BaseResponse<CompanyDto>> UpdateCompanyStatus(CompanyUpdateStatus updateStatus)
    {
        var companyStatus = await _companyRepository.Get(x => x.Id == updateStatus.CompanyId);
        if (companyStatus is null)
        {
            return new BaseResponse<CompanyDto>
            {
                Mesaage = "company does not exist",
                Status = false
            };
        }

        companyStatus.CompanyStatus = updateStatus.CompanyStatus;
       await _companyRepository.UpdateAsync(companyStatus);
       await _companyRepository.SaveChangesAsync();
       return new BaseResponse<CompanyDto>
       {
           Mesaage = "successful",
           Status = true
       };

    }
}