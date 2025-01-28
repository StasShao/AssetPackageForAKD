using ProjectFiles.Core.Services;
using UnityEngine;

namespace ProjectFiles.Core.Mono
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player:MonoBehaviour,IPlayer
    {
        [SerializeField] private Transform _lookTransform,_attractPoint;
        public Rigidbody PlayerRigidbody { get; private set; }
        public Transform LookTransform { get;private set; }
        public Transform AttractPoint { get;private set; }

        public void Init()
        {
            PlayerRigidbody = GetComponent<Rigidbody>();
            LookTransform = _lookTransform;
            AttractPoint = _attractPoint;
        }
    }
}