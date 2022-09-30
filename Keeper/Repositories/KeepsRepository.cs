using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Keep> GetKeepsByProfileId(string id)
        {
        string sql = @"
            SELECT 
                k.*,
                a.*
            FROM keeps k
            JOIN accounts a ON a.id = k.creatorId
            WHERE a.id = @id;
            ";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }, new { id }).ToList();
        }

        internal List<Keep> GetAll()
        {
            string sql = @"
            SELECT 
                k.*,
                a.*
            FROM keeps k
            JOIN accounts a ON a.id = k.creatorId;
            ";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile;
                return keep;
            }).ToList();
        }

        internal Keep Increase(Keep keep)
        {
            string sql = @"
            UPDATE keeps k SET
                k.kept = k.kept + 1
            WHERE k.id = @id;
            ";
            _db.Execute(sql, keep);
            return keep;
        }

        internal Keep GetOne(int id)
        {
            string sql = @"
            SELECT
                k.*,
                a.*
            FROM keeps k
            JOIN accounts a ON a.id = k.creatorId
            WHERE k.id = @id;
            "; 
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => 
            {
                keep.Creator = profile;
                return keep;
            }, new { id }).FirstOrDefault();
        }

        internal Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
                (name, description, img, creatorId)
            VALUES
                (@name, @description, @img, @creatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newKeep);
            newKeep.Id = id;
            return newKeep;
        }

        internal VaultKeepViewModel GetAllViewModelById(int keepId)
        {
            string sql = @"
            SELECT * FROM keeps
            WHERE id = @id;
            ";
            VaultKeepViewModel keep = _db.Query<VaultKeepViewModel>(sql, new { keepId }).FirstOrDefault();
            return keep;
        }



        internal Keep Update(Keep keepData)
        {
            string sql = @"
            UPDATE keeps SET
                name = @name,
                description = @description,
                img = @img,
                views = @views
            WHERE id = @id;
            ";
            _db.Execute(sql, keepData);
            return keepData;
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM keeps WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }
    }
}