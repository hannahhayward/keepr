using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vr;

    public VaultsService(VaultsRepository vr)
    {
      _vr = vr;
    }
    public Vault GetVaultById(int id)
    {
        return _vr.GetVaultById(id);
    }
    public Vault Create(Vault newVault)
    {
        int id = _vr.CreateVault(newVault);
        newVault.Id = id;
        return newVault;
    }
    internal Vault Update(int id, Vault newVault)
    {
        Vault original = GetVaultById(id);
        if (original.CreatorId == newVault.CreatorId)
        {
            original.Name = newVault.Name != null ? newVault.Name : original.Name;
            original.Description = newVault.Description != null ? newVault.Description : original.Description;
            original.IsPrivate = newVault.IsPrivate !=false ? newVault.IsPrivate : original.IsPrivate;
        }
        throw new Exception("cannot edit something that is not yours");
    }
    internal string Delete(int id, string userId)
    {
        Vault vault = GetVaultById(id);
        if(vault?.CreatorId == userId)
        {
            _vr.Delete(id);
            return "the post has been deleted";
        }
        throw new Exception("nice try buddy");
    }
  }
}