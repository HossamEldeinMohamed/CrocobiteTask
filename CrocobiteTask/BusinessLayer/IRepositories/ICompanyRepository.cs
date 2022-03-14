using CrocobitTask.CommonUtilities.DTO;
using CrocobitTask.CommonUtilities.Helpers;
using CrocobitTask.Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.BusinessLayer.IRepositories
{
   public interface ICompanyRepository
    {
        IQueryable<Company> GetAllCompanies();
        IQueryable<Company> GetAllRegistrstionsForCompany(Guid CompanyId);
        IQueryable<CompanyQuantitiesSumDTO> QuantitiesSumoOfRegistrstions(Guid CompanyId);
        Task<Response> InsertAsync(Company model);
    }
}
