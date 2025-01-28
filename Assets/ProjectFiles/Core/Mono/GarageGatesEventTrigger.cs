using System;
using ProjectFiles.Core.GameCoreibrary;
using ProjectFiles.Core.Services;
using UnityEngine;

namespace ProjectFiles.Core.Mono
{
    public class GarageGatesEventTrigger:MonoBehaviour
    {
        private GameCoreLibrary.ZoneEvent.GateEvent _gateEvent;
        [SerializeField] private Transform _gateLeft, _gateRight;
        [SerializeField] private float _openSpeed;

        private void Awake()
        {
            _gateEvent = new GameCoreLibrary.ZoneEvent.GateEvent(_gateLeft,_gateRight,GetComponent<Collider>(),_openSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            _gateEvent.OnGateOpenZoneEnter<IPlayer>(other);
        }

        private void Update()
        {
            _gateEvent.OnGateEventTick();
        }
    }
}