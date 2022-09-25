using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int Create(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (keepId, vaultId)
            VALUES
            (@keepId, @vaultId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            return id;
        }

        internal List<VaultKeepViewModel> GetKeepsByVaultId(int vaultId)
        {
            string sql = @"
            SELECT
                vk.*,
                k.*,
                a.*
            FROM vaultkeeps vk
                JOIN keeps k ON vk.keepId = k.id
                JOIN accounts a ON k.creatorId = a.id
            WHERE vk.vaultId = @vaultId
            ";
            List<VaultKeepViewModel> keeps =_db.Query<VaultKeep, VaultKeepViewModel, Account, VaultKeepViewModel>(sql, (vk, k, a) => 
            {
                k.Creator = a;
                k.VaultKeepId = vk.Id;
                return k;
            }, new { vaultId }).ToList();
            return keeps;
        }
    }
}