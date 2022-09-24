using System.Data;
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
        }
    }
}