using BaseComManager;
using MultiComExample.Package;
using PackageManager; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdpComManager;

namespace MultiComExample.Services
{
    public class UdpCommunicateService : CommunicateService<UdpDestInfo, UdpInitInfo>
    {
        public UdpCommunicateService(IBaseListener<UdpDestInfo, UdpInitInfo> listener) : base(listener)
        {

        }

        public override void OnListenerBuilding()
        {
            Listener.Initialize(new MyNetworkPackageGenerator(), new UdpInitInfo() { IpAddress = "192.168.1.34", Port = 1258 });
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
