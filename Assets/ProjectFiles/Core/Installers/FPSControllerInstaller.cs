using ProjectFiles.Core.Services;
using UnityEngine;
using Zenject;

namespace ProjectFiles.Core.Installers
{
    public class FPSControllerInstaller:MonoInstaller,IControllable
    {
        private float _yAxisLook;
        public void OnMove(Rigidbody movableRigidbody,IInput input, float moveForce)
        {
            movableRigidbody.AddForce(movableRigidbody.transform.forward * input.ForwardMoveDirection * moveForce,ForceMode.Force);
            movableRigidbody.AddForce(movableRigidbody.transform.right * input.SideMoveDirection * moveForce,ForceMode.Force);
        }
        public void OnLook(Rigidbody movableRigidbody,Transform lookTransform,IInput input, float lookSpeed,float clampYAxis)
        {
            _yAxisLook = Mathf.Clamp(_yAxisLook -= input.YLookAxis, -clampYAxis, clampYAxis);
            var yLookRotation = Quaternion.Euler(_yAxisLook, 0, 0);
            movableRigidbody.transform.Rotate(0,input.XLookAxis,0);
            lookTransform.localRotation = Quaternion.Lerp(lookTransform.localRotation,yLookRotation,lookSpeed);
        }
        public override void InstallBindings()
        {
            Container.Bind<IControllable>().To<FPSControllerInstaller>().FromComponentsInNewPrefab(this)
                .AsSingle();
        }
    }
}