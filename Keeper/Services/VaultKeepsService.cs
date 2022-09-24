using System;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _VKRepo;
        private readonly VaultsService _vService;
        private readonly KeepsService _kService;

        public VaultKeepsService(VaultKeepsRepository vKRepo, VaultsService vService, KeepsService kService)
        {
            _VKRepo = vKRepo;
            _vService = vService;
            _kService = kService;
        }

        internal VaultKeepViewModel Create(VaultKeep newVaultKeep, string userId)
        {
            Vault vault = _vService.Getone(newVaultKeep.vaultId);
            if (vault.CreatorId != userId)
            {
                throw new Exception("you are not the creator of that Vault, can't add a keep");
            }
            // create the collection pieces
            int id = _VKRepo.Create(newVaultKeep);
            //   Get the original piece
            VaultKeepViewModel vaultKeep = _kService.GetViewModelById(newVaultKeep.KeepId);
            //   attach collectionpiece id to it for the view model
            vaultKeep.VaultKeepId = id;
            //   return to user
            return vaultKeep;
        }
    }
}