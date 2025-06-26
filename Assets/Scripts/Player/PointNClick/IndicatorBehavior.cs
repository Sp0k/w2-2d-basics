using UnityEngine;
using Util;

namespace Player.PointNClick
{
    public class IndicatorBehavior : MonoBehaviour
    {
        #region Referneces

        [SerializeField]
        private Camera m_MainCam;
        private PlayerControls m_Controls;

        #endregion

        #region Main

        // Awake is called when the object's instance is generated
        void Awake()
        {
            // Create a new PlayerControl object to access the global player controls
            m_Controls = new PlayerControls();

            // Set a callback to move the indicator when a mouse click is performed
            m_Controls.Gameplay.Click.performed += ctx => MoveIndicator();
        }

        // Set Enable/Disable functions for the controls
        private void OnEnable() => m_Controls.Gameplay.Enable();
        private void OnDisable() => m_Controls.Gameplay.Disable();

        // Start is called when the scene is first loaded
        void Start()
        {
            // Get the main camera if it wasn't set in the editor
            if (m_MainCam == null)
                m_MainCam = Camera.main;
        }

        #endregion

        #region Helper

        // MoveIndicator moves the indicator to the position when the player clicked
        private void MoveIndicator()
        {
            // Set the object's position to the mouse's world position
            transform.position = MouseUtil.GetMouseWorldPosition(m_Controls, m_MainCam);
        }

        #endregion
    }
}