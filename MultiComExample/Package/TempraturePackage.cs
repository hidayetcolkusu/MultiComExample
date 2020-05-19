using PackageManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiComExample.Package
{
    public class TempraturePackage : NetworkPackage
    {
        public NetworkPackageValue Temprature { get; set; }

        public override void OnPackageValuesBuilding()
        {
            GetDefaultTemprature();
        }

        public override void OnPackageConvertersBuilding()
        {
            base.OnPackageConvertersBuilding();
            AddConverter(new TempratureToByteConverter());
        }

        public override byte OnCustomObjectConverting(dynamic converter, dynamic value)
        {
            return converter.ToByte(value);
        }

        public override byte[] OnCustomObjectConverting(dynamic converter, dynamic value, int byteCount)
        {
            return converter.ToByteArray(value, byteCount);
        }

        private void GetDefaultTemprature()
        {
            Temprature = new NetworkPackageValue()
            {
                Name = "Temprature"
               ,RowNumber = 4
               ,Value = new Temprature()
            };

            Checksum.RowNumber = 5;
            Etx.RowNumber      = 7;
        }
    }
}
