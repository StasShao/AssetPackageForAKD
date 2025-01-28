using UnityEngine;

namespace ProjectFiles.Core.Services
{
    public interface IItem
    {
        Rigidbody ItemRigidbody { get; }
        bool Grabbed { get; }
        void Init();
        void OnGrab(Vector3 grabPoint, bool isGrab);
        void Grab();
        void Drop();
    }
}