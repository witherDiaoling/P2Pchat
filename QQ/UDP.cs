using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QQ
{
    class UDP
    {
        /// <summary>
        /// 广播本机上下线
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userUID"></param>
        /// <param name="userIP"></param>
        public static void OnlineBroadcast(string userName, string userUID, string userIP,string UPorDN)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Broadcast, 10086);//规定本操作执行的端口，规定用于广播的IP地址
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 10086);//
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "!" + UPorDN + "?" + userName);
            socket.Bind(iepHost); //套接字绑定本机ip和端口                                                                                                                                              //需要绑定一块活动的网卡，不然无法发送信息
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, ipe);
            socket.Shutdown(SocketShutdown.Send);//发送完数据后关闭socket
            socket.Close();
        }

        /// <summary> 
        /// 广播本机下线。
        /// </summary> 
        /// <returns></returns> 
        public static void OfflineBroadcast(string userName, string userUID, string userIP)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 10086);//接收10086端口发来的广播
            IPEndPoint iepHost = new IPEndPoint(IPAddress.Parse(userIP), 10086);
            string hostname = Dns.GetHostName();
            byte[] data = Encoding.UTF8.GetBytes(userIP + "," + userUID + "," + "DN" + "," + userName);
            socket.Bind(iepHost);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(data, iep1);
            socket.Shutdown(SocketShutdown.Send);//发送完数据后关闭socket
            socket.Close();
        }
        public static void ListenBroadcast()
        {
            IPEndPoint ipEP1 = new IPEndPoint(IPAddress.Any, 10086);   //IPAddress.any即为所有活动主机
            UdpClient udpReceive = new UdpClient(ipEP1);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpReceive.Receive(ref ipEP1);//接收远程主机传来的信息
                    string message = Encoding.UTF8.GetString(bytRecv, 0, bytRecv.Length);
                    string IP = message.Substring(0, message.IndexOf(',')); //远程主机的IP
                    string UID = message.Substring(message.IndexOf(',') + 1, message.IndexOf('!') - message.IndexOf(',') - 1);   //远程主机的上下线状态字
                    string UPorDN = message.Substring(message.IndexOf('!') + 1, message.IndexOf('?') - message.IndexOf('!'));
                    string Name = message.Substring(message.IndexOf('?') + 1);
                    //Form2.ChangeFriendTable(Name, UID, IP, UPorDN);
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
