namespace Project.Base.Runtime
{
    using UnityEngine;
    
    public static class StringExtensions
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Converts a hex string to a Color object.
        /// </summary>
        /// <param name="str"> The default string value </param>
        /// <returns> Returns a color object with the converted value </returns>
        public static Color ToRGBColor(this string str)
        {
            str = str.Replace("0x", "");
            str = str.Replace("#", "");
            var r = byte.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = byte.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = byte.Parse(str.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            var a = str.Length == 8 ? byte.Parse(str.Substring(6, 2), System.Globalization.NumberStyles.HexNumber) : (byte)255;
            return new Color32(r, g, b, a);
        }

        #endregion

        #endregion
    }
}