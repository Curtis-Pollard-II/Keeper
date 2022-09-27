using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _PService;
        private readonly KeepsService _KService;
        private readonly VaultsService _VService;

        public ProfilesController(ProfilesService pService, KeepsService kService, VaultsService vService)
        {
            _PService = pService;
            _KService = kService;
            _VService = vService;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfileById(string id)
        {
            try
            {
                return Ok(_PService.GetProfileById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]

        public ActionResult<Keep> GetKeepsByProfileId(string id)
        {
            try
            {
                List<Keep> keeps = _KService.GetKeepsByProfileId(id);
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/vaults")]

        public ActionResult<Vault> GetVaultsByProfileId(string id)
        {
            try
            {
                List<Vault> vaults = _VService.GetVaultsByProfileId(id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}