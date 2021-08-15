using System;

namespace ImageProcessing.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        /// Get whether an int is between a range
        /// </summary>
        /// <param name="i"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool IsBetween(this int i, int min, int max, bool inclusive = true)
        {
            return (inclusive) ? (i >= min && i <= max) : (i >= min && i < max);
        }

        /// <summary>
        /// Get whether a float is between a range
        /// </summary>
        /// <param name="f"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool IsBetween(this float f, float min, float max, bool inclusive = true)
        {
            return (inclusive) ? (f >= min && f <= max) : (f >= min && f < max);
        }

        /// <summary>
        /// Get whether a double is between a range
        /// </summary>
        /// <param name="d"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="inclusive"></param>
        /// <returns></returns>
        public static bool IsBetween(this double d, double min, double max, bool inclusive = true)
        {
            return (inclusive) ? (d >= min && d <= max) : (d >= min && d < max);
        }



        /// <summary>
        /// Make sure that after math has been performed on a int that this number
        /// is at least 0 or at most 255
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static byte GetWithinByteRange(this int i)
        {
            if (i < Byte.MinValue)
            {
                return Byte.MinValue;
            }
            else if (i > Byte.MaxValue)
            {
                return Byte.MaxValue;
            }

            return Convert.ToByte(i);
        }


        /// <summary>
        /// Make sure that after math has been performed on a float that this number
        /// is at least 0 or at most 255
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static byte GetWithinByteRange(this float f)
        {
            if (f < Byte.MinValue)
            {
                return Byte.MinValue;
            }
            else if (f > Byte.MaxValue)
            {
                return Byte.MaxValue;
            }

            return Convert.ToByte(f);
        }

        /// <summary>
        /// Make sure that after math has been performed on a double that this number
        /// is at least 0 or at most 255
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static byte GetWithinByteRange(this double d)
        {
            if (d < Byte.MinValue)
            {
                return Byte.MinValue;
            }
            else if (d > Byte.MaxValue)
            {
                return Byte.MaxValue;
            }

            return Convert.ToByte(d);
        }



    }
}
