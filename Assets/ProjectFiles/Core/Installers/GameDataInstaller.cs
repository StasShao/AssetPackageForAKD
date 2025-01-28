using System.Collections.Generic;
using ProjectFiles.Core.Base;
using ProjectFiles.Core.Services;
using UnityEngine;
using Zenject;

namespace ProjectFiles.Core.Installers
{
    public class GameDataInstaller:MonoInstaller,IGameData
    {
        public List<IItem> CachedElements { get; private set; } = new();
        public List<Collider> CachedColliders { get;private set; } = new();
        public override void InstallBindings()
        {
            Container.Bind<IGameData>().To<GameDataInstaller>().FromComponentInNewPrefab(this).AsSingle();
        }
    }
}