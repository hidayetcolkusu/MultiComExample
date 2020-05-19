using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaseComManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiComExample.Models;
using MultiComExample.Package;
using Newtonsoft.Json;
using TcpComManager;
using UdpComManager;

namespace MultiComExample.Controllers
{
    public class HomeController : Controller
    {
        IBaseListener<TcpDestInfo, TcpInitInfo> _tcpListener;
        IBaseListener<UdpDestInfo, UdpInitInfo> _udpListener;

        public HomeController(IBaseListener<TcpDestInfo, TcpInitInfo> tcpListener, IBaseListener<UdpDestInfo, UdpInitInfo> udpListener)
        {
            _tcpListener = tcpListener;
            _udpListener = udpListener;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        } 

        public void SendMessageToTcp(string message)
        {
            _tcpListener.SendFromApi(message, new TcpDestInfo() { IpAddress = "192.168.1.34", Port = 1256 });
        }

        public void SendPackageToTcp()
        {
            TempraturePackage package = new TempraturePackage();  
            package["Stx"]        = (byte)1;
            package["Lenght"]     = (byte)2;
            package["Type"]       = (byte)3;
            package["Temprature"] = new Temprature() { Degree = 4 };
            package["Checksum"]   = (ushort)47694;
            package["Etx"]        = (byte)6; 
             
            _tcpListener.SendFromApi(package, new TcpDestInfo() { IpAddress = "192.168.1.34", Port = 1256 });
        }


        public void SendMessageToUdp(string message)
        {
            _udpListener.SendFromApi(message, new UdpDestInfo() { IpAddress = "192.168.1.34", Port = 1256 });
        }

        public void SendPackageToUdp()
        {
            TempraturePackage package = new TempraturePackage();
            package["Stx"]        = (byte)1;
            package["Lenght"]     = (byte)2;
            package["Type"]       = (byte)3;
            package["Temprature"] = new Temprature() { Degree = 4 };
            package["Checksum"]   = (ushort)47694;
            package["Etx"]        = (byte)6;


            string json = JsonConvert.SerializeObject(package);

            TempraturePackage package2 = JsonConvert.DeserializeObject<TempraturePackage>(json);

            _udpListener.SendFromApi(package2, new UdpDestInfo() { IpAddress = "192.168.1.34", Port = 1256 });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
