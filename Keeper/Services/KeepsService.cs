using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class KeepsService
    {

        private readonly KeepsRepository _kRepo;

        public KeepsService(KeepsRepository kRepo)
        {
            _kRepo = kRepo;
        }


// NOTE possibly need to add some FIND ALL action to filter out keeps that you are not an owner of. Also in the controller.
        internal List<Keep> GetAll()
        {
            return _kRepo.GetAll();
        }

        internal Keep Create(Keep newKeep)
        {
            return _kRepo.Create(newKeep);
        }

        internal Keep GetOne(int id)
        {
            Keep keep = _kRepo.GetOne(id);
            if (keep == null)
            {
                throw new Exception("no keep at that id");
            }
            return keep;
        }

        internal Keep Update(Keep update, string userId)
        {
            Keep original = GetOne(update.Id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You are not the creator, therefore you can not update");
            }
            original.Name = update.Name ?? original.Name;
            original.Description = update.Description ?? original.Description;
            original.Img = update.Img ?? original.Img;
            return _kRepo.Update(original);

        }

        internal List<Keep> GetKeepsByProfileId(string id)
        {
            return _kRepo.GetKeepsByProfileId(id);
        }

        internal string Delete(int id, string userId)
        {
            Keep original = GetOne(id);
            if(original.CreatorId != userId)
            {
                throw new Exception("You are not the Creator of this Keep, therefore you cannot delete it");
            }
            _kRepo.Delete(id);
            return "Keep Successfully Deleted";
        }
    }
}