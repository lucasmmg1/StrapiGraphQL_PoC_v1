namespace Project.Base.Runtime
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;

    public static class Enumerators
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Converts a Task into an IEnumerator.
        /// </summary>
        /// <param name="task"> The Task to be converted </param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        public static IEnumerator TaskToIEnumerator(Task task)
        {
            while (!task.IsCompleted) yield return null;
            if (!task.IsFaulted) yield break;
            if (task.Exception != null) throw task.Exception;
        }

        #endregion

        #endregion
    }
}