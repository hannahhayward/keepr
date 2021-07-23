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
    internal List<Keep> GetAllKeeps()
    {
    string sql = @"
    SELECT 
    k.*,
    FROM keeps k;";
    }
  }
}