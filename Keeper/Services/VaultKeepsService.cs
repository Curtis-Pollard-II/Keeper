using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _VKRepo;
        private readonly VaultsService _vService;
        private readonly KeepsService _kService;
        private readonly VaultsRepository _VRepo;

        public VaultKeepsService(VaultKeepsRepository vKRepo, VaultsService vService, KeepsService kService, VaultsRepository vRepo)
        {
            _VKRepo = vKRepo;
            _vService = vService;
            _kService = kService;
            _VRepo = vRepo;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            Vault vault = _VRepo.GetOne(newVaultKeep.VaultId);
            if (vault.CreatorId != newVaultKeep.CreatorId)
            {
                throw new Exception("Not allowed to add a keep here silly");
            }
            return _VKRepo.Create(newVaultKeep);
        }

        internal List<VaultKeepViewModel> GetKeepsByVault(int vaultId)
        {
            return _VKRepo.GetKeepsByVault(vaultId);
        }

        internal string Delete(int id, string userId)
        {

                VaultKeep original = GetOne(id);
                if (original.CreatorId != userId)
                {
                    throw new Exception("Cannot delete. Not your Vault Keep");
                }
                _VKRepo.Delete(id);
                return "VaultKeeps Successfully deleted";


            }

        internal VaultKeep GetOne(int id)
        {
            VaultKeep vaultKeep = _VKRepo.GetOne(id);
            if (vaultKeep == null)
            {
                throw new Exception("No VaultKeep be that id...Sorry");
            }
            return vaultKeep;
        }
    }




        // internal VaultKeep Create(VaultKeep newVaultKeep, string userId)
        // {
        //     Vault vault = _vService.GetOne(newVaultKeep.VaultId);
        //     if (vault.CreatorId != userId)
        //     {
        //         throw new Exception("you are not the creator of that Vault, can't add a keep");
        //     }
        //     int id = _VKRepo.Create(newVaultKeep);
        //     VaultKeepViewModel vaultKeep = _kService.GetViewModelById(newVaultKeep.KeepId);
        //     vaultKeep.VaultKeepId = id;
        //     return vaultKeep;
        // }



        // internal VaultKeep Create(VaultKeep newVaultKeep)
        // {
        //     Vault vault = _vService.GetOne(newVaultKeep.VaultId);
        //     if (vault.CreatorId != userId)
        //     {
        //         throw new Exception("you are not the creator of that Vault, can't add a keep");
        //     }

        // }


    }
