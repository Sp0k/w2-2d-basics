using UnityEngine;

namespace Environment.Soccer
{
    public class PuckBehavior : MonoBehaviour
    {
        #region Position Limits

        private const float k_LimitVertical = 5.5f;
        private const float k_LimitHorizontal = 9.3f;

        #endregion

        #region References

        private Transform m_Transform;
        private Rigidbody2D m_Rigidbody;

        #endregion

        #region Main

        // Start is called at the start of the scene
        void Start()
        {
            // Set the references through the game object's components
            m_Transform = gameObject.GetComponent<Transform>();
            m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Check if the ball is outside the bounds
            if (IsOutsideBounds())
                // Reset its position
                ResetPosition();
        }

        // OnCollisionEnter2D is called when the object's collider detects a collision with another 2D collider
        void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the other object in the collision is the net based on the tag
            if (collision.collider.gameObject.CompareTag("Net"))
            {
                // Print to the debug console
                Debug.Log("GOAL!");

                // Reset the ball
                ResetPosition();
            }
        }

        #endregion

        #region Helpers

        // Resets the position and velocity of the ball
        void ResetPosition()
        {
            // Set the velocity (movement speed) to 0
            m_Rigidbody.linearVelocity = Vector2.zero;

            // Set position to center
            m_Rigidbody.MovePosition(Vector2.zero);
        }

        // Checks if the ball is outside the bounds and return a boolean value
        bool IsOutsideBounds()
        {
            return m_Transform.position.x <= -k_LimitHorizontal || m_Transform.position.x >= k_LimitHorizontal ||
                m_Transform.position.y <= -k_LimitVertical || m_Transform.position.y >= k_LimitVertical;
        }

        #endregion
    }
}