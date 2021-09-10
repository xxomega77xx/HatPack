using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HatPack.Extensions
{
    public static class HatPackExtensions
    {
        /// <summary>
        /// Fully read <paramref name="input"/> stream, can be used as workaround for il2cpp streams.
        /// </summary>
        public static byte[] ReadFully(this Stream input)
        {
            using (var ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
