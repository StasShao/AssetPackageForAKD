namespace ProjectFiles.Core.Services
{
    public interface IInput
    {
        float ForwardMoveDirection { get; }
        float SideMoveDirection { get; }
        float XLookAxis { get; }
        float YLookAxis { get; }
        bool Select { get; }
        void SetMoveDirection(float forwardMove, float sideMove);
        void SetLookDirection(float xLookDirection, float yLookDirection);
        void SelectButtonDown(bool selectButton);
    }
}