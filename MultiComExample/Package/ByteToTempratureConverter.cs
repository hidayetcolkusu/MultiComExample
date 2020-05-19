using PackageManager.Converters.ByteArrayConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiComExample.Package
{
    public class ByteToTempratureConverter : ByteConverter<Temprature>
    {
        public override Temprature ToObject(byte[] value)
        {
            return new Temprature() { Degree = value[0] };
        }

        public override Temprature ToObject(byte value)
        {
            return new Temprature() { Degree = value };
        }
    }
}
