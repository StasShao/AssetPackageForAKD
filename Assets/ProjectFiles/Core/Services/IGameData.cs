using System.Collections.Generic;
using System.ComponentModel;
using ProjectFiles.Core.Base;
using UnityEngine;

namespace ProjectFiles.Core.Services
{
    public interface IGameData
    {
        List<IItem> CachedElements { get; }
        List<Collider> CachedColliders { get; }
    }
}