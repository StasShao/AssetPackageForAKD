using UnityEngine;

namespace ProjectFiles.Core.Settings.PlayerControllerSettings
{
    [CreateAssetMenu(menuName = "PlayerControllSettings",fileName = "Settings")]
    public class PlayerControllerSettings : ScriptableObject
    {
        [SerializeField][Range(0.1f,200.0f)] private float _moveForce;
        [SerializeField][Range(0.1f,200.0f)] private float _lookSpeed;
        [SerializeField][Range(0,90.0f)] private float _clampYAxisLook;
        [SerializeField][Range(1.0f,20.0f)] private float _grabDistance;
        public float MoveForce { get { return _moveForce; } }
        public float LookSpeed { get { return _lookSpeed; } }
        public float ClampYAxisLook { get { return _clampYAxisLook; } }
        public float GrabDistance { get { return _grabDistance; } }
    }
}
