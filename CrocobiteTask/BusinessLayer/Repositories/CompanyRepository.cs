using CrocobitTask.BusinessLayer.IRepositories;
using CrocobitTask.CommonUtilities.DTO;
using CrocobitTask.CommonUtilities.Helpers;
using CrocobitTask.Data_Access.Model;
using CrocobitTask.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.BusinessLayer.Repositories
{
    class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Company> Entity;

        public CompanyRepository(ApplicationDbContext contex)
        {
            _context = contex;
            Entity = contex.Set<Company>();
        }

        public IQueryable<Company> GetAllCompanies()
        {
            try
            {
                return Entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IQueryable<Company> GetAllRegistrstionsForCompany(Guid id)
        {
            try
            {
                return Entity.Include(x => x.ReceivingRegistrations).Include(z => z.SendingRegistrations).Where(x => x.Id == id);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public IQueryable<CompanyQuantitiesSumDTO> QuantitiesSumoOfRegistrstions(Guid id)
        {
            try
            {
                return Entity.Include(x => x.ReceivingRegistrations).Include(z => z.SendingRegistrations).Where(x=> x.Id==id).
                    Select(
                    e=>new CompanyQuantitiesSumDTO { 
                        TotalSumOfQuantities = e.ReceivingRegistrations.Sum(x=>x.Quantity)+ e.SendingRegistrations.Sum(x => x.Quantity),
                        Id=e.Id,Name=e.Name ,
                        SumOfSendingQuantity = e.SendingRegistrations.Sum(x => x.Quantity) ,
                        SumOfReceivingQuantity= e.ReceivingRegistrations.Sum(x => x.Quantity) 
                    });
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Response> InsertAsync(Company model)
        {
            try
            {               
                _context.Entry(model).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return new Response { StatusCode = 200 ,Data=model };
            }
            catch (Exception)
            {
                throw;  
            }
        } 

    }
}
