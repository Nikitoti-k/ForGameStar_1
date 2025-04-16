using UnityEngine;

namespace Codebase.Services.Inputs
{
    public class DesktopInput : IInputService
    {
        public bool Left => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        public bool Right => Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        public bool Escape => Input.GetKeyDown(KeyCode.Escape);
    }
}
