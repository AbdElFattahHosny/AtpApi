using AtpApi.Dtos;
using AtpApi.Interfaces;
using AtpApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IBaseRepo<Player> repo;
        private readonly IMapper mapper;

        public PlayerController(IBaseRepo<Player> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
       [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = mapper.Map <IEnumerable<PlayerDtos>>(await repo.GetAll()) ;
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = mapper.Map<PlayerDtos>(await repo.Get(id));
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlayerDtos player)
        {
            var result = mapper.Map<Player>(player);
            var addresult= await  repo.Create(result);
            if (addresult != 0)
            {
                return Ok(player);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
           ;
            var result = await repo.Delete(id);
            if (result != 0)
            {
                return Ok("deleted Successfully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id,PlayerDtos newplayer)
        {
            var result = mapper.Map<Player>(newplayer);
            var Editresult = await repo.Update(id, result);
            if (Editresult != 0)
            {
                return Ok(newplayer);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
