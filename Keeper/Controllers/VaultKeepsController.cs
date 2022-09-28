using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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


        [HttpGet("{id}")]
        public async Task<ActionResult<VaultKeep>> GetOne(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                VaultKeep vaultKeep = _VKService.GetOne(id);
                return Ok(vaultKeep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                string message = _VKService.Delete(id, user.Id);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}