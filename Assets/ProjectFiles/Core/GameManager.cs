using System;
using System.Collections;
using System.Collections.Generic;
using ProjectFiles.Core.GameCoreibrary;
using ProjectFiles.Core.Installers;
using ProjectFiles.Core.Mono;
using ProjectFiles.Core.Services;
using ProjectFiles.Core.Settings.PlayerControllerSettings;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private IInput _input;
    [Inject] private IControllable _controllable;
    [Inject] private PlayerSpawnInstaller _playerSpawner;
    [Inject] private IGameData _gameData;
    private GameCoreLibrary.InputManager _inputManager;
    private GameCoreLibrary.GrabAttractor _grabAttractor;
    [SerializeField] private Joystick _moveJoystick, _lookJoystick;
    [SerializeField] private PlayerControllerSettings _playerControllerSettings;
    private void Awake()
    {
        _inputManager = new GameCoreLibrary.InputManager(_input,_moveJoystick,_lookJoystick);
        _grabAttractor = new GameCoreLibrary.GrabAttractor(_gameData,_input
            , _playerSpawner._instancePlayer.LookTransform,
            _playerSpawner._instancePlayer.AttractPoint,_playerControllerSettings.GrabDistance);
    }
    private void Update()
    {
        _inputManager.MobileInput();
    }
    private void FixedUpdate()
    {
        _controllable.OnMove(_playerSpawner._instancePlayer.PlayerRigidbody,
            _input,_playerControllerSettings.MoveForce);
        _controllable.OnLook(
            _playerSpawner._instancePlayer.PlayerRigidbody,
            _playerSpawner._instancePlayer.LookTransform,_input,_playerControllerSettings.LookSpeed,
            _playerControllerSettings.ClampYAxisLook);
        _grabAttractor.OnGrab();
    }
}
