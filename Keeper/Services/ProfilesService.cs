using System;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class ProfilesService
    {
        private readonly AccountsRepository _ARepo;

        public ProfilesService(AccountsRepository aRepo)
        {
            _ARepo = aRepo;
        }









        internal object GetProfileById(string id)
        {
            Profile profile = _ARepo.GetProfileById(id);
            if (profile == null)
            {
                throw new Exception("No profile be that Id");
            }
            return profile;
        }


    }
}