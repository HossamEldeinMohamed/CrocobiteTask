using CrocobitTask.CommonUtilities.DTO;
using CrocobitTask.CommonUtilities.Helpers;
using CrocobitTask.Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.BusinessLayer.IRepositories
{
   public interface IRegistrationRepository
    {
          Task<Response> InsertAsync(Registration model);
    }
}
