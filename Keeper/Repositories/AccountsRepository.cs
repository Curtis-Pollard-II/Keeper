using System.Data;
using Keeper.Models;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Keeper.Repositories
{
    public class AccountsRepository
    {
        private readonly IDbConnection _db;

        public AccountsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Account GetByEmail(string userEmail)
        {
            string sql = "SELECT * FROM accounts WHERE email = @userEmail";
            return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
        }

        internal Profile GetProfileById(string id)
        {
            string sql = "SELECT * FROM accounts WHERE id =@id";
            return _db.QueryFirstOrDefault<Profile>(sql, new { id });
        }

        internal Account GetById(string id)
        {
            string sql = "SELECT * FROM accounts WHERE id = @id";
            return _db.QueryFirstOrDefault<Account>(sql, new { id });
        }

        internal Account Create(Account newAccount)
        {
            string sql = @"
            INSERT INTO accounts
            (name, picture, email, id)
            VALUES
            (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, newAccount);
            return newAccount;
        }

        internal Account Edit(Account update)
        {
            string sql = @"
            UPDATE accounts
            SET 
            name = @Name,
            picture = @Picture
            WHERE id = @Id;";
            _db.Execute(sql, update);
            return update;
        }

        internal List<Vault> GetMyVaults(string id)
        {
            string sql = @"
            SELECT
            v.*,
            a.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId 
            WHERE a.id = @id;
            ";
            return _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
            {
                vault.Creator = account;
                return vault;
            }).ToList();
        }
    }
}
