using CrocobitTask.BusinessLayer.IRepositories;
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
     public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Registration> Entity;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
            Entity = context.Set<Registration>();
        }

        public async Task<Response> InsertAsync(Registration model)
        {
            try
            {
                model.CreatedAt = DateTime.UtcNow;
                _context.Entry(model).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return new Response { StatusCode = 200 , Data= model };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
