using AtpApi.Dtos;
using AtpApi.Interfaces;
using AtpApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AtpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IBaseRepo<Country> repo;
        private readonly IMapper mapper;

        public CountryController(IBaseRepo<Country> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Getall()
        {
            return Ok(await repo.GetAll());
        }

        [HttpGet("GetOneById")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await repo.Get(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CountryDtos country)
        {
            var result = mapper.Map<Country>(country);
            var addResult = await repo.Create(result);
            if (addResult != 0)
            {
                return Ok(country);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var addResult = await repo.Delete(id);
            if (addResult != 0)
            {
                return Ok("Successfully Deleted");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id,CountryDtos country)
        {
            var result = mapper.Map<Country>(country);

            var EditResult = await repo.Update(id,result);
            if (EditResult != 0)
            {
                return Ok(country);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
