using UnityEngine;

namespace ProjectFiles.Core.Services
{
    public interface IPlayer
    {
        Rigidbody PlayerRigidbody { get; }
        Transform LookTransform { get; }
        Transform AttractPoint { get; }
        void Init();
    }
}