using BaseComManager;
using MultiComExample.Package;
using PackageManager;
using SerialComManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiComExample.Services
{
    public class SerialCommunicateService : CommunicateService<SerialDestInfo, SerialInitInfo>
    {
        public SerialCommunicateService(IBaseListener<SerialDestInfo, SerialInitInfo> listener) : base(listener)
        {

        }

        public override void OnListenerBuilding()
        {
            Listener.Initialize(new MyNetworkPackageGenerator(), new SerialInitInfo() { BaudRate = 9600, Port = "COM5" });
        }

        public override void TextReceived(string text)
        {

        }

        public override void PackageReceived(NetworkPackage package)
        {

        }

        public override void BytesPackageReceived(byte[] bytes)
        {

        }
    }
}
