using PackageManager.Converters.ByteConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiComExample.Package
{
    public class TempratureToByteConverter : ObjectConverter<Temprature>
    {
        public override byte ToByte(Temprature value)
        {
            return Convert.ToByte(value.Degree);
        }
        public override byte[] ToByteArray(Temprature value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value.Degree) };
        }
    }
}
