using System.Collections.Generic;
using ProjectFiles.Core.Base;
using ProjectFiles.Core.Services;
using Unity.Mathematics;
using UnityEngine;

namespace ProjectFiles.Core.GameCoreibrary
{
    public class GameCoreLibrary
    {
        #region Input
        public class InputManager
        {
            private IInput _input;
            private  Joystick _moveJoystick;
            private  Joystick _lookJoystick;
            public InputManager(IInput input)
            {
                _input = input;
            }

            public InputManager(IInput input,Joystick moveJoystick,Joystick lookJoystick)
            {
                _input = input;
                _moveJoystick = moveJoystick;
                _lookJoystick = lookJoystick;
            }

            public void MobileInput()
            {
                var verticalMoveDir = _moveJoystick.Vertical;
                var horizontalMoveDir = _moveJoystick.Horizontal;
                var yAxisLook = _lookJoystick.Vertical;
                var xAxisLook = _lookJoystick.Horizontal;
                _input.SetMoveDirection(verticalMoveDir,horizontalMoveDir);
                _input.SetLookDirection(xAxisLook,yAxisLook);
            }
        }
        #endregion
        
        #region Grab
        public class GrabAttractor
        {
            private Transform _grabRayPoint;
            private Transform _attractPoint;
            private float _grabDistance;
            private IGameData _gameData;
            private IInput _input;
            private IItem _item;
            public GrabAttractor(IGameData gameData,IInput input,Transform grabRayPoint,Transform attractPoint,float grabDistance)
            {
                _gameData = gameData;
                _input = input;
                _grabRayPoint = grabRayPoint;
                _attractPoint = attractPoint;
                _grabDistance = grabDistance;
            }
            private RaycastHit Hit()
            {
                var ray = new Ray(_grabRayPoint.position, _grabRayPoint.forward * _grabDistance);
                Debug.DrawRay(ray.origin,ray.direction * _grabDistance,Color.red);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, _grabDistance);
                return hit;
            }
            private bool TryGetGrabItem(out IItem item)
            {
                var collider = Hit().collider;
                var gameDataCachedElements = _gameData.CachedElements;
                var gameDataCachedColliders = _gameData.CachedColliders;
                if (collider !=null&&ColliderCacher.TryGetCacheElement<IItem>(ref gameDataCachedElements, ref gameDataCachedColliders,
                        collider, out IItem gettedItem))
                {
                    item = gettedItem;
                    return true;
                }
                item = null;
                return false;
            }
            public void OnGrab()
            {
                if (TryGetGrabItem(out IItem item))
                {
                    _item = item;
                    _item.Grab();
                }
                if (!_input.Select&&_item != null)
                {
                    _item.Drop();
                    _item = null;
                }
                if (_item != null)
                {
                    _item.OnGrab(_attractPoint.position,_input.Select);
                }
            }
        }
        #endregion

        #region TriggerZoneEvents
        public class ZoneEvent
        {
            public class GateEvent
            {
                private Transform _gateLeft, _gateRight;
                private bool _isOpen;
                private float _leftGateYAxis, _rightGateYAxis,_openSpeed;
                private Collider _triggerCollider;
                public GateEvent(Transform gateLeft,Transform gateRight,Collider triggerCollider,float openSpeed)
                {
                    _gateLeft = gateLeft;
                    _gateRight = gateRight;
                    _openSpeed = openSpeed;
                    _triggerCollider = triggerCollider;
                }

                public void OnGateOpenZoneEnter<T>(Collider other)
                {
                    if (other.TryGetComponent<T>(out T element))
                    {
                        _isOpen = true;
                        _triggerCollider.enabled = false;
                    }
                }

                public void OnGateEventTick()
                {
                    if (_isOpen)
                    {
                        var leftRotation = Quaternion.Euler(0, 90.0f, 0);
                        var rightRotation = Quaternion.Euler(0, -90.0f, 0);
                        _gateLeft.localRotation = Quaternion.Lerp(_gateLeft.localRotation,leftRotation,_openSpeed * Time.deltaTime);
                        _gateRight.localRotation = Quaternion.Lerp(_gateRight.localRotation,rightRotation,_openSpeed * Time.deltaTime);
                    }
                   
                }
            }
        }
        #endregion
        
        #region Collider cacher
        public class ColliderCacher
        {
            public static bool TryGetCacheElement<T>(ref List<T> elements,ref List<Collider> colliders,Collider other,out T element)
            {
                if(elements.Count == 0&&other.TryGetComponent<T>(out T firstElement))
                {
                    element = firstElement;
                    colliders.Add(other);
                    elements.Add(firstElement);
                    return true;
                }
                for(int i = 0; i < colliders.Count; i++) 
                { 
                    var cachedCollider = colliders[i];
                    if(other ==  cachedCollider)
                    {
                        element = elements[i];
                        return true;
                    }
                }
                if(!colliders.Contains(other)&&other.TryGetComponent<T>(out T newElement))
                {
                    element = newElement;
                    colliders.Add(other);
                    elements.Add(newElement);
                    return true;
                }
                element = default;
                return false;
            }
        }
        #endregion

    }
}
