using BaseComManager;
using MultiComExample.Package;
using PackageManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcpComManager;

namespace MultiComExample.Services
{
    public class TcpCommunicateService : CommunicateService<TcpDestInfo, TcpInitInfo>
    {
        public TcpCommunicateService(IBaseListener<TcpDestInfo, TcpInitInfo> listener) : base(listener)
        {

        }

        public override void OnListenerBuilding()
        {
            Listener.Initialize(new MyNetworkPackageGenerator(), new TcpInitInfo() { IpAddress = "192.168.1.34", Port = 1259 });
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
