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

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (keepId, creatorId, vaultId)
            VALUES
            (@keepId, @creatorId, @vaultId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        internal List<VaultKeepViewModel> GetKeepsByVault(int vaultId)
        {
            string sql = @"
            SELECT
                vk.*,
                k.*,
                a.*
            FROM vaultkeeps vk
                JOIN keeps k ON vk.keepId = k.id
                JOIN accounts a ON k.creatorId = a.id
            WHERE vk.vaultId = @vaultId;
            ";
            List<VaultKeepViewModel> keeps = _db.Query<VaultKeep, VaultKeepViewModel, Account, VaultKeepViewModel>(sql, (vk, k, a) =>
            {
                k.Creator = a;
                k.VaultKeepId = vk.Id;
                return k;
            }, new { vaultId }).ToList();
            return keeps;
        }

        internal VaultKeep GetOne(int id)
        {
            string sql = @"
            SELECT
                vk.*,
                a.*
            FROM vaultkeeps vk 
            JOIN accounts a ON a.id = vk.creatorId 
            WHERE vk.id = @id;
            ";
            return _db.Query<VaultKeep, Profile, VaultKeep>(sql, (vaultKeep, profile) =>
            {
                vaultKeep.Creator = profile;
                return vaultKeep;
            }, new { id }).FirstOrDefault();
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE from vaultkeeps WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }
    }
}