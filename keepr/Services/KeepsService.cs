using System;
using System.Collections.Generic;
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

    internal List<Keep> GetAllKeeps()
    {
      return _kr.GetAllKeeps();
    }

    internal Keep GetKeepById(int id)
    {
      return _kr.GetKeepById(id);
    }

    public Keep Create(Keep newKeep)
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

    internal Keep Update(Keep newKeep)
    {
      Keep original = GetKeepById(newKeep.Id);
      if(original.CreatorId == newKeep.CreatorId)
      {
        newKeep.Name = newKeep.Name ?? original.Name;
        newKeep.Description = newKeep.Description ?? original.Description;
        newKeep.Img = newKeep.Img ?? original.Img;
        newKeep.Views = newKeep.Views > original.Views ? newKeep.Views : original.Views;
        newKeep.Shares = newKeep.Shares > original.Shares ? newKeep.Shares : original.Shares;
        newKeep.Keeps = newKeep.Keeps > original.Keeps ? newKeep.Keeps : original.Keeps;
        if(_kr.Update(newKeep) > 0 )
        {
          return newKeep;
        }
      }
      throw new Exception("you are not allowed to do this");
    }
  }
}