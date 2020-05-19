using PackageManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiComExample.Package
{
    public class MyNetworkPackageGenerator : NetworkPackageGenerator
    {
        public override void OnNetworkPackagesListBuilding()
        {
            AddPackage(new TempraturePackage());
        }

        public override void OnByteArrayConvertersBuilding()
        {
            AddConverter(new ByteToTempratureConverter());
        }

        public override dynamic OnCustomObjectConverting(dynamic converter, byte[] value)
        {
            return converter.ToObject(value);
        }

        public override dynamic OnCustomObjectConverting(dynamic converter, byte value)
        {
            return converter.ToObject(value);
        }
    }
}
