using ProjectFiles.Core.Services;
using Zenject;

namespace ProjectFiles.Core.Installers
{
    public class InputInstaller:MonoInstaller,IInput
    {
        public float ForwardMoveDirection { get; private set; }
        public float SideMoveDirection { get;private set; }
        public float XLookAxis { get;private set; }
        public float YLookAxis { get;private set; }
        public bool Select { get;private set; }
        public void SetMoveDirection(float forwardMove, float sideMove)
        {
            ForwardMoveDirection = forwardMove;
            SideMoveDirection = sideMove;
        }
        public void SetLookDirection(float xLookDirection, float yLookDirection)
        {
            XLookAxis = xLookDirection;
            YLookAxis = yLookDirection;
        }
        public void SelectButtonDown(bool selectButton)
        {
            Select = selectButton;
        }
        public override void InstallBindings()
        {
            Container.Bind<IInput>().To<InputInstaller>().FromComponentsInNewPrefab(this).AsSingle();
        }
    }
}