using AutoMapper;
using CrocobitTask.BusinessLayer.IRepositories;
using CrocobitTask.CommonUtilities.DTO;
using CrocobitTask.CommonUtilities.Helpers;
using CrocobitTask.Data_Access.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }
        [HttpPost]

        public async Task<ActionResult> InsertCompany(CompanyDTO model)
        {
            if (ModelState.IsValid)
            {
                var setModel = mapper.Map<Company>(model);
                try
                {
                    var result = await companyRepository.InsertAsync(setModel);
                    return StatusCode(result.StatusCode, result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public ActionResult GetAllCompanies()
        {
            if (ModelState.IsValid)
            {
                var result = companyRepository.GetAllCompanies();
                if (result == null)
                    return StatusCode(404, new { massge = "empty" });
                return StatusCode(200, result);
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}

