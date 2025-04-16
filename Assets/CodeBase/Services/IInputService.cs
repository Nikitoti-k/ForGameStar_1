namespace Codebase.Services.Inputs
{
    public interface IInputService
    {
        public bool Left { get; }
        public bool Right { get; }
        public bool Escape { get; }
    }
}