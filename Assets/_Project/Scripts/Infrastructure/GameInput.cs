using UnityEngine;

namespace _Project.Infrastructure
{
    public static class GameInput
    {
        public static bool JumpButtonPressed => 
            Input.GetKey(KeyCode.Space) 
            || Input.GetMouseButton(0) 
            || Input.GetMouseButton(1) 
            || Input.GetMouseButton(2);
    }
}