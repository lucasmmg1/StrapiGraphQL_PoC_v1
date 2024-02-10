namespace Project.Base.Runtime
{
    using UnityEngine;
    
    public static class Color
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Converts a hex string to a Color object.
        /// </summary>
        public static UnityEngine.Color HexToRGB(this string hex)
        {
            hex = hex.Replace("0x", "");
            hex = hex.Replace("#", "");
            var r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            var g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            var b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            var a = hex.Length == 8 ? byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber) : (byte)255;
            return new Color32(r, g, b, a);
        }

        #endregion

        #endregion
    }
}