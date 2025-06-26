using UnityEngine;
using UnityEngine.SceneManagement;

namespace Environment
{
    public enum EDemoScenes : int
    {
        SoccerScene,
        PointNClickScene,
    }

    public class NextSceneTrigger : MonoBehaviour
    {
        public EDemoScenes m_NextScene;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player"))
            {
                Debug.Log("Loading next scene... Target: " + m_NextScene);
                SceneManager.LoadScene(m_NextScene.ToString(), LoadSceneMode.Single);
            }
        }
    }
}