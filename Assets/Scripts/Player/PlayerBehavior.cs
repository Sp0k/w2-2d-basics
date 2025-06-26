using UnityEngine;

namespace Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        [SerializeField]
        protected float m_Speed = 3.5f;
        protected const float k_LimitHorizontal = 7.4f;
        protected const float k_LimitTop = 3.2f;
        protected const float k_LimitBottom = -3.5f;
    }
}