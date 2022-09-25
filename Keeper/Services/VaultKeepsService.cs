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
}