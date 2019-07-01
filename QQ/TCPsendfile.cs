using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Net;



using System.Windows.Forms;

using System.Threading;

namespace QQ
{
    public class TCPsendfile
    {
        public class SendFile
        {
            /// <summary>
            /// 已经发送的百分比。范围是 0~100。
            /// </summary>
            public int Percentage { get; private set; } = 0;
            /// <summary>
            /// 缓冲区大小
            /// </summary>
            byte[] sendByte = new byte[1400];
        

            //构造函数
            public SendFile()
            {

            }
           
            /// <summary>
            /// 发送请求信息
            /// </summary>
            /// <param name="friendIP"></param>
            public void SendFileRequest(string friendIP)
            {
                try
                {
                    Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    //int length = message.Length;
                    byte[] buffer = Encoding.UTF8.GetBytes("UID"+":"+userClass.publicUserUID+"!"+"Request");
                    networkstream.Write(buffer, 0, buffer.Length);
                    networkstream.Dispose();
                    networkstream.Close();
                    socketSend.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            /// <summary>
            /// 发送文件信息
            /// </summary>
            public void SendFileInformation(string friendIP,string filePath,string fileName)
            {
                try
                {
                    int sendByteLength = sendByte.Length;
                    FileInfo fileInfo = new FileInfo(filePath);
                    //文件长度
                    long fileLength = fileInfo.Length;
                    //总块数
                    long Sum = fileLength / sendByteLength;
                    Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //与对方连接
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    //发送文件信息
                    byte[] buffer = Encoding.UTF8.GetBytes("Information" +"?"+fileLength+"!"+Sum+"/"+fileName);
                    networkstream.Write(buffer, 0, buffer.Length);
                    networkstream.Dispose();
                    networkstream.Close();
                    socketSend.Close();
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            /// <summary>
            /// 发送信息，说明已选择保存路径
            /// </summary>
            /// <param name="friendIP"></param>
            public void SendFilePathOK(string friendIP)
            {
                try
                {
                    Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //与对方连接
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    byte[] buffer = Encoding.UTF8.GetBytes("SetPathOK");
                    networkstream.Write(buffer, 0, buffer.Length);
                    networkstream.Dispose();
                    networkstream.Close();
                    socketSend.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            /// <summary>
            /// 发送结束传输请求，中断目前文件传输
            /// </summary>
            /// <param name="friendIP"></param>
            public void SendStop(string friendIP)
            {
                try
                {
                    Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //与对方连接
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    byte[] buffer = Encoding.UTF8.GetBytes("StopSend");
                    networkstream.Write(buffer, 0, buffer.Length);
                    networkstream.Dispose();
                    networkstream.Close();
                    socketSend.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            /// <summary>
            /// 接收确认信息
            /// </summary>
            /// <param name="signalStream"></param>
            public bool Receiveconform(ref NetworkStream ConformStream,int length)
            {
                while(true)
                {
                    try
                    {
                        byte[] buffer = new byte[length];
                        //读取流中的数据
                        ConformStream.Read(buffer, 0, length);
                        string message = Encoding.UTF8.GetString(buffer).Trim('\0');
                        if (message == "OK")
                        {
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
               
            }
            /// <summary>
            /// 发送文件
            /// </summary>
            /// <param name="friendIP"></param>
            /// <param name="filePath"></param>
            /// <param name="fileType"></param>
            public void SendFileway(string friendIP,string filePath,ref int percentage,ref bool stopSendtrueORfalse)
            {
                int sendByteLength = sendByte.Length;
                FileInfo fileInfo = new FileInfo(filePath);
                
                //文件长度
                long fileLength = fileInfo.Length;
                //总块数
                long Sum = 0;
                
                if (fileLength<sendByteLength)//如果文件大小小于一个块的长度，说明值发送一个块
                {
                    Sum = 1;
                }
                else
                {
                    Sum = fileLength / sendByteLength;
                }
                
                //块数编号
                
                //与对方建立连接
                Socket sendsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                FileStream fileStream = File.OpenRead(filePath);
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(friendIP), 54322);
                sendsocket.Connect(iPEndPoint);


                Socket receiveconfrom = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint confromiPEendPoint = new IPEndPoint(IPAddress.Parse(friendIP), 54325);
                receiveconfrom.Connect(confromiPEendPoint);


                
                //创建网络流
                NetworkStream networkStream = new NetworkStream(sendsocket);
                NetworkStream confromnetworkStream1 = new NetworkStream(receiveconfrom);
                //用缓冲流封装网络流，增加发送速度
                BufferedStream buffered = new BufferedStream(networkStream);
                try
                {
                    using (fileStream)
                    {
                        using (networkStream)
                        {
                            using (buffered)
                            {
                                while ((sendByteLength = fileStream.Read(sendByte, 0, sendByteLength)) > 0)//如果有一次读入缓冲区的字节数是0，说明文件读取完毕
                                {

                                    if (stopSendtrueORfalse == true)//如果中断请求发生，则跳出循环
                                    {
                                        break;
                                    }
                                    buffered.Write(sendByte, 0, sendByteLength);//向对方发送字节数组
                                    buffered.Flush();
                                    //Number++;
                                    Form2.Number++;
                                    Percentage = (int)(((double)Form2.Number / Sum) * 100);//计算传输百分比
                                    if (Percentage>100)
                                    {
                                        Percentage = 100;
                                    }
                                    percentage = Percentage;
                                    Receiveconform(ref confromnetworkStream1, receiveconfrom.ReceiveBufferSize);
                                }
                            }
                        }
                    }
                }
                #region
                catch (ArgumentNullException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (NotSupportedException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (ObjectDisposedException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("未知错误" + e.ToString());
                }
                #endregion

                 finally//关闭套接字
                {
                    confromnetworkStream1.Dispose();
                    confromnetworkStream1.Close();
                    receiveconfrom.Dispose();
                    receiveconfrom.Close();
                    sendsocket.Dispose();
                    sendsocket.Close();
                    Form2.Number = 0;
                }
                

               


            }
            /// <summary>
            /// 文件发送
            /// </summary>
            /// <param name="friendIP"></param>
            /// <param name="filePath"></param>
            /// <param name="fileType"></param>
            /// <param name="fileLength"></param>
            /// <param name="sum"></param>
            public void SendFilestart(string friendIP, string filePath,string fileName,ref int percentage,ref bool sentStoptrueORfalse)
            {
                //发送文件信息
                SendFileInformation(friendIP,filePath,fileName);
                //发送文件
                SendFileway(friendIP, filePath,ref percentage,ref sentStoptrueORfalse);
                

            }

        }
        public class ReceiveFile
        {
            /// <summary>
            /// 数据片缓存
            /// </summary>
            byte[] fragmentBuffer = new byte[1400];
            /// <summary>
            /// 数据块缓存
            /// </summary>
            byte[] blockBuffer = new byte[100*1400];
          
            /// <summary>
            /// 已经发送的百分比。范围是 0~100。
            /// </summary>
            public int Percentage { get; private set; } = 0;
            //构造方法
            public ReceiveFile()
            {

            }
            public void ListenFile()
            {

            }
            /// <summary>
            /// 发送同意或拒绝信息
            /// </summary>
            /// <param name="friendIP"></param>
            /// <param name="OKorNO"></param>
            public void SendOKorNO(string friendIP,string OKorNO)
            {
                try
                {
                    Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    byte[] buffer = Encoding.UTF8.GetBytes(OKorNO);
                    networkstream.Write(buffer, 0, buffer.Length);
                    networkstream.Dispose();
                    networkstream.Close();
                    socketSend.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            /// <summary>
            /// 发送收到文件块的确认信息
            /// </summary>
            /// <param name="sendStoptrueORfalse"></param>
            public void  Sendconfrom(ref NetworkStream sendStream, string message)
            {
                try
                {
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                    sendStream.Write(sendBytes, 0, sendBytes.Length);
                    sendStream.Flush();
                }
                catch
                {
                }
            }
            /// <summary>
            /// 接收文件
            /// </summary>
            public void ListenReceiveFile(long fileLength,long fileNumber,string saveFilepath,string FileName,ref int percentage,ref bool sendStoptrueORfalse)
            {
                int fragmentBufferLength = fragmentBuffer.Length;
                int blockBufferBufferLength = blockBuffer.Length;
                int blockElementsNums = 0;//指示 blockBuffer 中有多少个字节

                //由于监听socket在方法结束后会自动关闭，所以无需手动关闭
                Socket socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketListen.Bind(new IPEndPoint(userClass.IPv4Address, 54322));//与对方连接
                socketListen.Listen(10);

                Socket ConformsocketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ConformsocketListen.Bind(new IPEndPoint(userClass.IPv4Address, 54325));//与对方连接
                ConformsocketListen.Listen(10);
                try
                {
                    Socket socketWrite = socketListen.Accept();
                    Socket conformSocket = ConformsocketListen.Accept();
                    FileStream fStream = new FileStream(saveFilepath+"\\"+FileName, FileMode.Create);
                    NetworkStream networkStream = new NetworkStream(socketWrite);
                    NetworkStream conformNetworkStream = new NetworkStream(conformSocket);
                    BufferedStream bufferedStream = new BufferedStream(networkStream);
                    using(fStream)
                    {
                        using(networkStream)
                        {
                            using(bufferedStream)
                            {
                                if (networkStream.CanRead==true)
                                {
                                    while (Form2.Number <= fileNumber)//判断文件发送情况
                                    {
                                        if (sendStoptrueORfalse == true)
                                        {
                                            break;
                                        }
                                        if (Form2.Number == fileNumber)//如果是最后一块
                                        {
                                            int mod = (int)(fileLength % fragmentBufferLength);//最后一次传输有多少字节
                                            if (mod == 0)//文件总字节长度是 数据片 的整数倍，即本次传输没有任何有效字节
                                            {
                                                fragmentBufferLength = 0;
                                                break;//放弃本次的无效数据，退出循环
                                            }
                                            else//不是整数倍
                                            {
                                                fragmentBufferLength = mod;
                                            }
                                        }
                                        Percentage= (int)(((double)Form2.Number / fileNumber) * 100);//计算传输百分比
                                        if (Percentage > 100)
                                        {
                                            Percentage = 100;
                                        }
                                        percentage = Percentage;
                                        //读取缓冲流数据
                                        bufferedStream.Read(fragmentBuffer, 0, fragmentBuffer.Length);
                                        //把数据片中的数据追加到数据块缓存中
                                        Buffer.BlockCopy(fragmentBuffer, 0, blockBuffer, blockElementsNums, fragmentBufferLength);
                                        //片数加一
                                        Form2.Number++;
                                        //缓冲区长度增加
                                        blockElementsNums += fragmentBufferLength;
                                        if (blockElementsNums == blockBuffer.Length)//缓存块满，需要写入到文件
                                        {
                                            fStream.Write(blockBuffer, 0, blockBufferBufferLength);
                                            blockElementsNums = 0;
                                        }
                                        //线程停止1毫秒，方便接收
                                        Thread.Sleep(1);
                                        //向发送方发送确认信息，让发送方发下一个报文
                                        Sendconfrom(ref conformNetworkStream, "OK");
                                    }

                                    
                                }
                                if (blockElementsNums != 0)//缓存块里有东西，需要最后一次写入
                                {
                                    fStream.Write(blockBuffer, 0, blockElementsNums);
                                }
                            }
                        }
                        
                    }
                    if (sendStoptrueORfalse == true)
                    {
                        File.Delete(saveFilepath + "\\" + FileName);
                    }
                    conformNetworkStream.Dispose();
                    conformNetworkStream.Close();
                    conformSocket.Dispose();
                    conformSocket.Close();
                    //关闭与对方连接的socket
                    socketWrite.Dispose();
                    socketWrite.Close();

                }
                #region
                catch (ArgumentNullException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (NotSupportedException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (FileNotFoundException e)///File.OpenRead
                {
                    MessageBox.Show(e.ToString());
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (ObjectDisposedException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (InvalidOperationException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (SocketException e)
                {
                    MessageBox.Show(e.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("未知错误！\r\n" + e.ToString());
                }
                #endregion
                finally//收尾工作
                {
                    
                    Form2.Number = 0;
                }

            }
        }
    }
}
