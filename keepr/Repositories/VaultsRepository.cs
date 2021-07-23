using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Vault> GetAllVaults()
    {
        string sql = @"
        SELECT
        v.*,
        a.*
        FROM vaults v;
        JOIN accounts a ON v.creatorId = a.id;";
        return _db.Query<Vault, Profile, Vault>(sql, (v, p)=>
        {
            v.Creator = p;
            return v;
        }, splitOn: "id").ToList(); 
    }
    internal int CreateVault(Vault newVault)
    {
        string sql = @"
        INSERT INTO vaults (name, description, isPrivate, creatorId)
        VALUES (@Name, @Descripton, @IsPrivate, @CreatorId);
        SELECT LAST_INSERT_ID();";
        return _db.ExecuteScalar<int>(sql, newVault);
    }
    internal Vault GetVaultById(int id)
    {
        string sql = @"
        SELECT * FROM vaults 
        WHERE id = @id;";
        return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }
    internal int Update(Vault newVault)
    {
        string sql = @"
        UPDATE vaults SET
        name = @Name,
        descriptoin = @Description,
        isPrivate = @IsPrivate
        WHERE id = @Id;";
        return _db.Execute(sql, newVault);
    }
    internal int Delete(int id)
    {
        string sql = @"
        DELETE FROM vaults
        WHERE id = @id;";
        return _db.Execute(sql, new { id });
    }
    }
  }