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

        public async Task<ActionResult<VaultKeepViewModel>> Create([FromBody] VaultKeep newVaultKeep)
        {
            try 
            {
              Account user = await HttpContext.GetUserInfoAsync<Account>();
              VaultKeepViewModel keep = _VKService.Create(newVaultKeep, user.Id);
              return Ok(keep);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }







    }
}