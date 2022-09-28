using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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

        internal Vault GetOne(int id)
        {
            string sql = @"
            SELECT
                v.*,
                a.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.id = @id;
            "; 
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => 
            {
                vault.Creator = profile;
                return vault;
            }, new { id }).FirstOrDefault();
        }

        internal Vault Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
                (name, description, img, isPrivate, creatorId)
            VALUES
                (@name, @description, @img, @isPrivate, @creatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVault);
            newVault.Id = id;
            return newVault;
        }

        internal Vault Update(Vault vaultData)
        {
            string sql = @"
            UPDATE vaults SET
                name = @name,
                description = @description,
                img = @img,
                isPrivate = @isPrivate
            WHERE id = @id;
            ";
            _db.Execute(sql, vaultData);
            return vaultData;
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM vaults WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }

        internal List<Vault> GetVaultsByProfileId(string id)
        {
        string sql = @"
            SELECT 
                v.*,
                a.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.creatorId = @id;
            ";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }).ToList();
        }

        internal List<Vault> GetPublicVaultsByProfileId(string profileId)
        {
            string sql = @"
            SELECT 
                v.*,
                a.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.creatorId = @id AND v.isPrivate = false;
            ";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { profileId }).ToList();
        }
    }
}