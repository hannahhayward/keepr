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