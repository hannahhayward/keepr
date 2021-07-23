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
    public class VaultController : ControllerBase
    {
        private readonly VaultsService _vs;
        public VaultController(VaultsService vs)
        {
        _vs = vs;
        }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetVaultById(int id)
    {
        try
        {
            return Ok(_vs.GetVaultById(id));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
        try
        {
            Account account = await HttpContext.GetUserInfoAsync<Account>();
            newVault.CreatorId = account.Id;
            return Ok(_vs.Create(newVault));
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<string>> Delete(int id)
    {
        try
        {
            Account account = await HttpContext.GetUserInfoAsync<Account>();
            return Ok(_vs.Delete(id, account.Id));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }
    }
}