using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
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

        [HttpPost]


        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newVaultKeep.CreatorId = userInfo.Id;
                VaultKeep vaultKeep = _VKService.Create(newVaultKeep);
                vaultKeep.Creator = userInfo;
                return Ok(vaultKeep);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }








    }
}