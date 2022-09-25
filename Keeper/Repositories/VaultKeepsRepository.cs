using System.Data;

namespace Keeper.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        // internal int Create(VaultKeep newVaultKeep)
        // {
        //     string sql = @"
        //     INSERT INTO vaultkeeps
        //     (keepId, creatorId, vaultId)
        //     VALUES
        //     (@keepId, @creatorId, @vaultId);
        //     SELECT LAST_INSERT_ID();
        //     ";
        //     int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
        //     return id;
        // }


    }
}