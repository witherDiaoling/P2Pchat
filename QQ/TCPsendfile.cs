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
                    //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(userClass.publicIP), 54321);
                    //socketSend.Bind(iPEndPoint);
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    //int length = message.Length;
                    byte[] buffer = Encoding.UTF8.GetBytes("Request");
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
                    //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(userClass.publicIP), 54321);
                    //socketSend.Bind(iPEndPoint);
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    //int length = message.Length;
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
            /// 发送文件
            /// </summary>
            /// <param name="friendIP"></param>
            /// <param name="filePath"></param>
            /// <param name="fileType"></param>
            public void SendFileway(string friendIP,string filePath)
            {
                int sendByteLength = sendByte.Length;
                FileInfo fileInfo = new FileInfo(filePath);
                
                //文件长度
                long fileLength = fileInfo.Length;
                //总块数
                long Sum = fileLength / sendByteLength;
                //块数编号
                long Number = 0;
                
                //与对方建立连接
                Socket sendsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                FileStream fileStream = File.OpenRead(filePath);
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(friendIP), 54322);
                sendsocket.Connect(iPEndPoint);
                NetworkStream networkStream = new NetworkStream(sendsocket);
                //BufferedStream buffered = new BufferedStream(networkStream);
                try
                {
                    using (fileStream)
                    {
                        using (networkStream)
                        {
                            /*using (buffered)
                            {*/
                                while ((sendByteLength = fileStream.Read(sendByte, 0, sendByteLength)) > 0)//如果有一次读入缓冲区的字节数是0，说明文件读取完毕
                                {
                                    networkStream.Write(sendByte, 0, sendByteLength);//向对方发送字节数组
                                    //networkStream.Flush();
                                    Number++;
                                    Percentage = (int)(((double)Number / Sum) * 100);//计算传输百分比

                                }
                            //}
                           
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

                    }
                    #endregion

                 finally
                {
                    sendsocket.Dispose();
                    sendsocket.Close();
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
            public void SendFilestart(string friendIP, string filePath,string fileName)
            {
                //发送文件信息
                SendFileInformation(friendIP,filePath,fileName);
                //发送文件
                SendFileway(friendIP, filePath);
                

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
            byte[] blockBuffer = new byte[100 * 1400];
            //构造方法
            public ReceiveFile()
            {

            }
            public void ListenFile()
            {

            }
            public void SendOKorNO(string friendIP,string OKorNO)
            {
                try
                {
                    Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(userClass.publicIP), 54321);
                    //socketSend.Bind(iPEndPoint);
                    socketSend.Connect(IPAddress.Parse(friendIP), 54323);
                    NetworkStream networkstream = new NetworkStream(socketSend);
                    //int length = message.Length;
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
            /// 接收文件
            /// </summary>
            public void ListenReceiveFile(long fileLength,long fileNumber,string saveFilepath,string FileName)
            {
                int fragmentBufferLength = fragmentBuffer.Length;
                int blockBufferBufferLength = blockBuffer.Length;
                int blockElementsNums = 0;//指示 blockBuffer 中有多少个字节

                Socket socketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketListen.Bind(new IPEndPoint(userClass.IPv4Address, 54322));//与对方连接
                socketListen.Listen(10);
                long Number = 0;
                try
                {
                    Socket socketWrite = socketListen.Accept();
                    FileStream fStream = new FileStream(saveFilepath+"\\"+FileName, FileMode.Create);
                    NetworkStream networkStream = new NetworkStream(socketWrite);
                    BufferedStream bufferedStream = new BufferedStream(networkStream);
                    using(fStream)
                    {
                        using(networkStream)
                        {
                            using(bufferedStream)
                            {
                                if (networkStream.CanRead==true)
                                {
                                    while (Number<=fileNumber)//判断文件发送情况
                                    {
                                        if (Number==fileNumber)//如果是最后一块
                                        {

                                        }
                                        bufferedStream.Read(fragmentBuffer, 0, fragmentBuffer.Length);
                                        Buffer.BlockCopy(fragmentBuffer, 0, blockBuffer, blockElementsNums, fragmentBufferLength);//把数据片中的数据追加到数据块缓存中
                                        Number++;
                                        
                                            fStream.Write(blockBuffer, 0, blockBufferBufferLength);
                                            blockElementsNums = 0;
                                        
                                        if (blockElementsNums == blockBuffer.Length)//缓存块满，需要写入到文件
                                        {
                                            fStream.Write(blockBuffer, 0, blockBufferBufferLength);
                                            blockElementsNums = 0;
                                        }
                                    }

                                    if (blockElementsNums != 0)//缓存块里有东西，需要最后一次写入
                                    {
                                        fStream.Write(blockBuffer, 0, blockElementsNums);
                                    }
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
                    
                }

            }
        }
    }
}
