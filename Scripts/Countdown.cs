using UnityEngine;

namespace UnityToolBox
{
    /// <summary>
    /// A Timer component that can be used to track time for in-game events.
    /// This timer supports pause/resume functionality if it's designated as an in-game timer.
    /// </summary>
    public class Countdown : MonoBehaviour
    {
        [Tooltip("The total duration of the timer in seconds.")]
        public float duration;

        [Tooltip("The current remaining duration of the timer in seconds.")]
        public float currentDuration;

        /// <summary>
        /// Updates the timer's current duration each frame, respecting the game's pause state if applicable.
        /// </summary>
        private void Update()
        {
            // Decrease the current duration based on the elapsed time since the last frame.
            currentDuration -= Time.deltaTime;
        }

        /// <summary>
        /// Starts or restarts the timer with the duration specified in the 'duration' field.
        /// </summary>
        public void StartTimer()
        {
            currentDuration = duration;
        }

        /// <summary>
        /// Checks if the timer has completed its countdown.
        /// </summary>
        /// <returns>True if the timer's current duration is less than zero; otherwise, false.</returns>
        public bool IsReady()
        {
            return currentDuration < 0;
        }

        /// <summary>
        /// Checks if the timer is currently running.
        /// </summary>
        /// <returns>True if the timer's current duration is non-negative; otherwise, false.</returns>
        public bool IsRunning()
        {
            return !IsReady();
        }

        /// <summary>
        /// Determines whether the remaining time is greater than a specified percentage of the total duration.
        /// </summary>
        /// <param name="p">The percentage of the duration to compare against, as a decimal (e.g., 0.5 for 50%).</param>
        /// <returns>True if the remaining time is greater than the specified percentage; otherwise, false.</returns>
        public bool PercentRemaining(float p)
        {
            // Ensure we don't divide by zero in case duration is not set or set to zero.
            if (duration <= 0) return false;
            return currentDuration / duration > p;
        }
    }
}