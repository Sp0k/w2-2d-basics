using UnityEngine;

namespace Util
{
    public class MouseUtil : MonoBehaviour
    {
        // Returns the mouse's world position as a vector 2
        public static Vector2 GetMouseWorldPosition(PlayerControls controls, Camera cam)
        {
            // Get the position of the mouse on the screen (in pixels)
            Vector2 screenPos = controls.Gameplay.Point.ReadValue<Vector2>();
            
            // Return the position of the mouse in the game world
            return cam.ScreenToWorldPoint(screenPos);
        }
    }
}