using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class KeepController : ControllerBase
    {
        private readonly KeepsService _ks;
    public KeepController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<Keep> GetAllKeeps()
    {
        try
        {
            return Ok(_ks.GetAllKeeps());
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeepById(int id)
    {
        try
        {
            return Ok(_ks.GetKeepById(id));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
        try
        {
            Account account = await HttpContext.GetUserInfoAsync<Account>();
            newKeep.CreatorId = account.Id;
            return Ok(_ks.Create(newKeep));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<Keep>> Delete(int id)
    {
        try
        {
            Account account = await HttpContext.GetUserInfoAsync<Account>();
            return Ok(_ks.Delete(id, account.Id));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
  }
}