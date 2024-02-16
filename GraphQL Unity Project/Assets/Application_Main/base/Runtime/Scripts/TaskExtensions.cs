namespace Project.Base.Runtime
{
    using System.Collections;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Converts a Task into an IEnumerator.
        /// </summary>
        /// <param name="task"> The Task to be converted </param>
        /// <returns> Ends the coroutine when the task is completed </returns>
        public static IEnumerator ToIEnumerator(this Task task)
        {
            while (!task.IsCompleted) yield return null;
        }

        #endregion

        #endregion
    }
}