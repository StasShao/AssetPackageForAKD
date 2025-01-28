    using UnityEngine;

    namespace ProjectFiles.Core.Services
    {
        public interface IControllable
        {
            void OnMove(Rigidbody movableRigidbody,IInput input,float moveForce);
            void OnLook(Rigidbody movableRigidbody,Transform lookTransform,IInput input, float lookSpeed,float clampYAxis);
        }
    }
