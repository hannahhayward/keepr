using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService
  {
      private readonly KeepsRepository _kr;
    public KeepsService(KeepsRepository kr)
    {
      _kr = kr;
    }

    internal object GetAllKeeps()
    {
      return _kr.GetAllKeeps();
    }

    internal object GetKeepById(int id)
    {
      return _kr.GetKeepById(id);
    }

    internal object Create(Keep newKeep)
    {
      int id = _kr.CreateKeep(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    internal string Delete(int id, string userId)
    {
      Keep keep = GetKeepById(id);
      if(keep?.CreatorId == userId)
      {
          _kr.Delete(id);
          return "the post has been deleted";
      }
    throw new Exception ("nice try buddy");
    }
  }
}