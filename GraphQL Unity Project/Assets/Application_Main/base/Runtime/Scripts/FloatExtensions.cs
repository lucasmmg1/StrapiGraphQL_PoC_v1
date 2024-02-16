namespace Project.Base.Runtime
{
    public static class FloatExtensions
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Compares two float values with a pre-defined tolerance.
        /// </summary>
        /// <param name="value"> The default float value </param>
        /// <param name="comparison">The comparison value </param>
        /// <param name="tolerance"> The allowed tolerance </param>
        /// <returns> Returns a boolean based on the comparison. If the two values are equals, returns true. If not, returns false </returns>
        public static bool Equals(this float value, float comparison, float tolerance = 0.0001f) => System.Math.Abs(value - comparison) < tolerance;

        #endregion

        #endregion
    }
}
