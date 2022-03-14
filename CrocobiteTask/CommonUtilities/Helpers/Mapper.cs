using AutoMapper;
using CrocobitTask.CommonUtilities.DTO;
using CrocobitTask.Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.CommonUtilities.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CompanyDTO, Company>();
            CreateMap<RegisterationDTO, Registration>();           

        }
    }
}
