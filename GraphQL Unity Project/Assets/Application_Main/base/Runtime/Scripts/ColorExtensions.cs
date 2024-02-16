namespace Project.Base.Runtime
{
    using UnityEngine;
    
    public static class ColorExtensions
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Converts a color object to a hex string.
        /// </summary>
        /// <param name="color"> The default color value </param>
        /// <returns> Returns a string with the converted value </returns>
        public static string ToHexColor(this Color color)
        {
            return $"#{(byte)(color.r * 255):X2}{(byte)(color.g * 255):X2}{(byte)(color.b * 255):X2}{(byte)(color.a * 255):X2}";
        }

        #endregion

        #endregion
    }
}