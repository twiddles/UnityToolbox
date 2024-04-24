using UnityEngine;

namespace UnityToolBox
{
    /// <summary>
    /// Auto destroy the game object after a certain amount of time.
    /// </summary>
    public class AutoDestroy : MonoBehaviour
    {
        private float timeLeft;

        /// <summary>
        /// The time after which the game object will be destroyed.
        /// </summary>
        [Tooltip("The time after which the game object will be destroyed.")]
        public float destroyAfter = 1.0f;

        private void Start()
        {
            timeLeft = destroyAfter;
        }

        public void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
                Destroy(gameObject);
        }
    }
}