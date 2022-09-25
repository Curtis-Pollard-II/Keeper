using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeeps : ControllerBase
    {
        private readonly VaultKeepsService _VKService;

        public VaultKeeps(VaultKeepsService vKService)
        {
            _VKService = vKService;
        }

        // [HttpPost]
      

        // public async Task<ActionResult<VaultKeepViewModel>> Create([FromBody] VaultKeep newVaultKeep)
        // {
        //     try 
        //     {
        //         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        //         VaultKeepViewModel vaultKeep = _VKService.Create(newVaultKeep, userInfo.Id);
        //         return Ok(vaultKeep);

        //     }
        //     catch (Exception e)
        //     {
        //       return BadRequest(e.Message);
        //     }
        // }







    }
}