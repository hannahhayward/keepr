using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
        public List<Keep> GetAllKeeps()
    {
        string sql = @"
        SELECT
        k.*,
        a.*
        FROM keeps k;
        JOIN accounts a ON k.creatorId = a.id;";
        return _db.Query<Keep, Profile, Keep>(sql, (k, p)=>
        {
            k.Creator = p;
            return k;
        }, splitOn: "id").ToList(); 
    }
    internal Keep GetKeepById(int id)
    {
      string sql = @"
      SELECT * FROM keeps
      WHERE id = @id;";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal int CreateKeep(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps(creatorId, name, description, img, views, shares, keeps)
      VALUES (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
    internal int Update(Keep newKeep)
    {
      string sql = @"
      UPDATE keeps SET
      name = @Name,
      description = @Description.
      img = @Img,
      views = @Views,
      shares = @Shares,
      keeps = @Keeps
      WHERE id = @Id;";
      return _db.Execute(sql, newKeep);
    }
    internal int Delete(int id)
    {
      string sql = @"
      DELETE FROM keeps 
      WHERE id = @id;";
      return _db.Execute(sql, new { id });
    }
  }
}