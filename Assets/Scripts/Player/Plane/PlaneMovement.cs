using UnityEngine;

namespace Player.Plane
{
    public class PlaneMovement : PlayerBehavior
    {
        #region References

        [SerializeField]
        private Rigidbody2D m_Rigidbody;
        private PlayerControls controls;

        #endregion

        #region Main

        // This function runs when the object is initialized
        void Awake()
        {
            // Create a new `PlayerControls` instance
            controls = new PlayerControls();
        }

        // These functions are callbacks for the enabling and disabling of the Gameplay controls.
        void OnEnable() => controls.Gameplay.Enable();
        void OnDisable() => controls.Gameplay.Disable();

        // This function runs every frame
        void FixedUpdate()
        {
            // Get the input vector from the Player controls
            Vector2 input = controls.Gameplay.Move.ReadValue<Vector2>();

            // Calculate the new position of the player
            Vector2 delta = input * m_Speed * Time.fixedDeltaTime;
            Vector2 newPos = m_Rigidbody.position + delta;

            // Limit the position of the player horizontally
            if (newPos.x > k_LimitHorizontal)
                newPos.x = k_LimitHorizontal;
            else if (newPos.x < -k_LimitHorizontal)
                newPos.x = -k_LimitHorizontal;

            // Limit the position of the player vertically
            if (newPos.y > k_LimitTop)
                newPos.y = k_LimitTop;
            else if (newPos.y < k_LimitBottom)
                newPos.y = k_LimitBottom;

            // Move the player to the new position
            m_Rigidbody.MovePosition(newPos);
        }

        #endregion
    }
}