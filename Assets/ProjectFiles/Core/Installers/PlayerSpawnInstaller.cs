using ProjectFiles.Core.Mono;
using ProjectFiles.Core.Services;
using UnityEngine;
using Zenject;

namespace ProjectFiles.Core.Installers
{
    public class PlayerSpawnInstaller:MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _spawn;
        public Player _instancePlayer;
        public override void InstallBindings()
        {
            var inst = Container.InstantiatePrefabForComponent<Player>(_player, _spawn.position, _spawn.rotation,null);
            Container.BindInstance(inst);
            _instancePlayer = inst;
            inst.Init();
            Container.Bind<PlayerSpawnInstaller>().FromComponentsInNewPrefab(this).AsSingle();
        }
    }
}