using Microsoft.Win32;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace QQ
{

    public static class userClass
    {
        public static IPAddress IPv4Address
        {
            get
            {
                IPAddress ipv4 = new IPAddress(0);
                NetworkInterface[] fNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();//创建网卡数组
                foreach (NetworkInterface adapter in fNetworkInterfaces)
                {
                    //读取本机注册表
                    string FRegistryKey = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + adapter.Id + "\\Connection";
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(FRegistryKey, false);
                    if (rk != null)
                    {
                        // 区分 PnpInstanceID      
                        // 如果前面有 PCI 就是本机的真实网卡          
                        string FPnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                        int fMediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", 0));
                        if (FPnpInstanceID.Length > 3 && FPnpInstanceID.Substring(0, 3) == "PCI")
                        {
                            if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet && adapter.OperationalStatus == OperationalStatus.Up)//以太网
                            {
                                IPInterfaceProperties iP = adapter.GetIPProperties();//获取网卡接口信息
                                UnicastIPAddressInformationCollection unicastIPs = iP.UnicastAddresses;//获取单播地址表
                                foreach (UnicastIPAddressInformation ipAddress in unicastIPs)
                                {
                                    if (ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)//如果是ipv4地址，ipv6是InterNetworkv6
                                    {
                                        ipv4 = ipAddress.Address;
                                    }
                                }
                            }
                            else if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && adapter.OperationalStatus == OperationalStatus.Up)//无线网络
                            {
                                IPInterfaceProperties iP = adapter.GetIPProperties();//获取网卡接口信息
                                UnicastIPAddressInformationCollection unicastIPs = iP.UnicastAddresses;//获取单播地址表
                                foreach (UnicastIPAddressInformation ipAddress in unicastIPs)
                                {
                                    if (ipAddress.Address.AddressFamily == AddressFamily.InterNetwork)//如果是ipv4地址，ipv6是InterNetworkv6
                                    {
                                        ipv4 = ipAddress.Address;
                                    }
                                }
                            }
                        }
                    }
                }
                return ipv4;
            }
        }
        /// <summary>
        /// 本机用户名
        /// </summary>
        public static string publicUsername = "";
        /// <summary>
        /// 本机用户的密码
        /// </summary>
        public static string publicUserpassword = "";
        /// <summary>
        /// 本机用户IP
        /// </summary>
        public static string publicIP = IPv4Address.ToString();
        /// <summary>
        /// 本机用户UID
        /// </summary>
        public static string publicUserUID = "";

    }
}
