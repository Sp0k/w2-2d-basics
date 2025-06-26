using UnityEngine;
using UnityEngine.SceneManagement;

namespace Environment
{
    #region Enumerator

    // DemoScenes is an enumerator that keeps track of the scenes in the game
    public enum EDemoScenes
    {
        SoccerScene,
        PointNClickScene,
    }

    #endregion

    public class NextSceneTrigger : MonoBehaviour
    {
        #region Reference

        // Enum value set in the editor
        public EDemoScenes m_NextScene;

        #endregion

        #region Main

        // OnTriggerEnter2D is called when an object with a collider 2D meets this object
        // (as long as this collider has 'isTrigger' enabled)
        void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if the object that collided is the player through the tag system
            if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player"))
            {
                // Write to the debug console saying the scene is changing
                Debug.Log("Loading next scene... Target: " + m_NextScene);

                // Load the specified scene in the editor in single mode
                SceneManager.LoadScene(m_NextScene.ToString(), LoadSceneMode.Single);
            }
        }

        #endregion
    }
}