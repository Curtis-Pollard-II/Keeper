using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vRepo;

        public VaultsService(VaultsRepository vRepo)
        {
            _vRepo = vRepo;
        }

        internal Vault Create(Vault newVault)
        {
            return _vRepo.Create(newVault);
        }


        internal Vault GetOne(int id)
        {
            Vault vault = _vRepo.GetOne(id);
            if (vault == null)
            {
                throw new Exception("no vault at that id");
            }
            return vault;
        }

        internal Vault Update(Vault update, string userId)
        {
            Vault original = GetOne(update.Id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You are not the creator, therefore you can not update");
            }
            original.Name = update.Name ?? original.Name;
            original.Description = update.Description ?? original.Description;
            original.Img = update.Img ?? original.Img;
            return _vRepo.Update(original);

        }

        internal string Delete(int id, string userId)
        {
            Vault original = GetOne(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You are not the Creator of this Vault, therefore you cannot delete it");
            }
            _vRepo.Delete(id);
            return "Vault Successfully Deleted";
        }

        internal List<Vault> GetPublicVaultsByProfileId(string profileId)
        {
            
            return _vRepo.GetPublicVaultsByProfileId(profileId);
        }
    }
}