using System.Collections.Generic;
using System.Data;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Vault> GetAll()
        {
            
        }
    }
}