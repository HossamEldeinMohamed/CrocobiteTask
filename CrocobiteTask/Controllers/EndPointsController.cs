using AutoMapper;
using CrocobitTask.BusinessLayer.IRepositories;
using CrocobitTask.CommonUtilities.DTO;
using CrocobitTask.CommonUtilities.Helpers;
using CrocobitTask.Data_Access.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndPointsController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IRegistrationRepository registrationRepository;
        private readonly IMapper mapper;

        public EndPointsController(ICompanyRepository companyRepository, IRegistrationRepository registrationRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.registrationRepository = registrationRepository;
            this.mapper = mapper;
        }
        // POST: api/Company
        [HttpPost]

        public async Task<ActionResult> InsertRegisteration(RegisterationDTO model)
        {
            if (ModelState.IsValid)
            {
                var setModel = mapper.Map<Registration>(model);
                try
                {
                    var result = await registrationRepository.InsertAsync(setModel);
                    return StatusCode(result.StatusCode, result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet("{id}")]
        public ActionResult GetCompanyRegisterations(Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = companyRepository.GetAllRegistrstionsForCompany(id);
                if (result == null)
                    return StatusCode(404, new { massge = "Company is not exist please check the Id" });
                return StatusCode(200, result);
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors) });
        }
        [HttpGet("SumOfQuantities")]
        public  ActionResult GetTotalQuantitySumOfRegistrations(Guid CompanyId)
        {
            if (ModelState.IsValid)
            {
                var result = companyRepository.QuantitiesSumoOfRegistrstions(CompanyId);
                if (result == null)
                    return StatusCode(404, new { massge = "Company is not exist please check the Id" });
                return StatusCode(200, result);
            }
            return StatusCode(501, new Response { Data = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}
