using System.Collections;
using UnityEngine;
using Util;

namespace Player.PointNClick
{
    public class PointNClickBehavior : PlayerBehavior
    {
        #region References

        [SerializeField]
        private Rigidbody2D m_Rigidbody;
        [SerializeField]
        private Camera m_MainCam;

        private Vector2 m_TargetPosition;
        private PlayerControls m_Controls;

        #endregion

        #region Main

        // Awake is called when the object's instance is first created
        void Awake()
        {
            // Create a new instance of the player controls
            m_Controls = new PlayerControls();

            // Set the RecordClick as the callback when the mouse is clicked
            m_Controls.Gameplay.Click.performed += ctx => RecordClick();
        }

        // Set the Enable/Disable functions for the gameplay controls
        private void OnEnable() => m_Controls.Gameplay.Enable();
        private void OnDisable() => m_Controls.Gameplay.Disable();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // Set the target position to the middle of the scene
            m_TargetPosition = Vector2.zero;
            
            // If the rigid body is not set in the editor, find it through the game object's components
            if (m_Rigidbody == null)
                m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();

            // If the main camera is not set in the editor, find it through the Camera system
            if (m_MainCam == null)
                m_MainCam = Camera.main;
        }

        #endregion

        #region Click Handling

        // RecordClick gets the position of the mouse in the world and starts moving
        // the player towards the target position
        private void RecordClick()
        {
            // Get the mouse position
            m_TargetPosition = MouseUtil.GetMouseWorldPosition(m_Controls, m_MainCam);

            // Start the coroutine to move the player to the new target
            StartCoroutine(MoveToTarget());
        }

        // Coroutine to move the player to the new target
        private IEnumerator MoveToTarget()
        {
            // Checks if the player is close to the wanted position
            while (Vector2.Distance(m_Rigidbody.position, m_TargetPosition) > 0.01f)
            {
                // Calculate the next position towards the target
                Vector2 nextPos = Vector2.MoveTowards(m_Rigidbody.position, m_TargetPosition, m_Speed * Time.deltaTime);

                // Move the player to the new position
                m_Rigidbody.MovePosition(nextPos);

                // Yield control back to main thread
                yield return new WaitForFixedUpdate();
            }

            // Move player to target position to make sure it is properly where it should be
            m_Rigidbody.MovePosition(m_TargetPosition);
        }

        #endregion
    }
}